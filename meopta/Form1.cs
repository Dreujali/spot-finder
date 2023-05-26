using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml;

namespace meopta
{

    public partial class Form1 : Form
    {
        private int sensitivityValue;
        private Bitmap loadedImage;
        private byte[] buffer;
        private int imageWidth;
        private int imageHeigth;
        private double timeMs;
        private string fileName;
        private Point center;



        public Form1()
        {
            InitializeComponent();
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            sensitivityValue = 0;
            sensitivitySlider.Value = sensitivityValue;
            this.SizeChanged += Form1_SizeChanged;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            pictureBox.Size = new Size(this.ClientSize.Width, this.ClientSize.Height);
        }

        private void SensitivitySlider_ValueChanged(object sender, EventArgs e)
        {
            sensitivityValue = sensitivitySlider.Value;
            sensitivity.Text = "Sensitivity: " + sensitivitySlider.Value.ToString();
        }

        private void autoSensitivity_Click(object sender, EventArgs e)
        {
            setAutoSensitivity();
        }


        private void uploadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png; *.jpg; *.jpeg; *.gif; *.bmp)|*.png; *.jpg; *.jpeg; *.gif; *.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                fileName = Path.GetFileName(imagePath);

                pictureBox.Image = Image.FromFile(imagePath);

                loadedImage = new Bitmap(imagePath);

                //Bitmap to buffer
                imageWidth = loadedImage.Width;
                imageHeigth = loadedImage.Height;
                Rectangle rect = new Rectangle(0, 0, loadedImage.Width, loadedImage.Height);
                BitmapData bitmapData = loadedImage.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                int stride = bitmapData.Stride;
                int bufferSize = stride * loadedImage.Height;
                buffer = new byte[bufferSize];
                Marshal.Copy(bitmapData.Scan0, buffer, 0, bufferSize);
                loadedImage.UnlockBits(bitmapData);

                setAutoSensitivity();
            }
        }


        // finds coordination of every white pixel and avg the coordinations to find the center
        private void FindSpotCenter(byte[] buffer, int width, int height)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int sensitivityThreshold = 255 - sensitivityValue;
            int bytesPerPixel = 3;
            int stride = width * bytesPerPixel;
            int whitePixelsCount = 0;
            int sumX = 0;
            int sumY = 0;
            bool found = false;


            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int offset = y * stride + x * bytesPerPixel;

                    byte blue = buffer[offset];
                    byte green = buffer[offset + 1];
                    byte red = buffer[offset + 2];

                    if (red >= sensitivityThreshold &&
                        green >= sensitivityThreshold &&
                        blue >= sensitivityThreshold)
                    {
                        found = true;
                        sumX += x;
                        sumY += y;
                        whitePixelsCount++;
                    }
                }
            }

            // division by zero fix
            int centerX = whitePixelsCount > 0 ? sumX / whitePixelsCount : 0;
            int centerY = whitePixelsCount > 0 ? sumY / whitePixelsCount : 0;

            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;
            timeMs = elapsedTime.TotalMilliseconds;
            time_label.Text = timeMs.ToString() + " ms";



            if (found)
            {
                label_x.Text = "X: " + centerX.ToString();
                label_y.Text = "Y: " + centerY.ToString();
                export.Enabled = true;
                center = new Point(centerX, centerY);
            }
            else
            {
                MessageBox.Show("No spot found!", "Spot Detection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                label_x.Text = "X: none";
                label_y.Text = "Y: none";
                center = new Point();
            }
        }



        private void PrintCross(Point center, Bitmap image)
        {
            int crossSize = 20; 
            int halfCrossSize = crossSize / 2;

            using (Graphics graphics = Graphics.FromImage(image))
            {
                Pen pen = new Pen(Color.Red, 3);
                graphics.DrawLine(pen, center.X - halfCrossSize, center.Y - halfCrossSize, center.X + halfCrossSize, center.Y + halfCrossSize);
                graphics.DrawLine(pen, center.X - halfCrossSize, center.Y + halfCrossSize, center.X + halfCrossSize, center.Y - halfCrossSize);
            }

            pictureBox.Refresh();
        }



        private void findSpot_Click(object sender, EventArgs e)
        {
            Point centerPoint;

            if (loadedImage == null)
            {
                MessageBox.Show("No image loaded.", "Spot Detection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Bitmap editedImage = new Bitmap(loadedImage);
            FindSpotCenter(buffer, imageWidth, imageHeigth);
            PrintCross(center, editedImage);
            pictureBox.Image = editedImage;
        }

        // finds the brightest pixel and subtracts the average brightness of the whole image
        // brightness is calculated by sum of RGB values
        private void setAutoSensitivity()
        {
            if (loadedImage == null)
            {
                MessageBox.Show("No image loaded.", "Spot Detection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int bytesPerPixel = 3;
            int totalPixels = imageWidth * imageHeigth;
            int totalRed = 0;
            int totalGreen = 0;
            int totalBlue = 0;
            int maxRed = 0;
            int maxGreen = 0;
            int maxBlue = 0;

            for (int i = 0; i < buffer.Length; i += bytesPerPixel)
            {
                byte blue = buffer[i];
                byte green = buffer[i + 1];
                byte red = buffer[i + 2];

                totalRed += red;
                totalGreen += green;
                totalBlue += blue;

                if (red > maxRed)
                {
                    maxRed = red;
                }
                if (green > maxGreen)
                {
                    maxGreen = green;
                }
                if (blue > maxBlue)
                {
                    maxBlue = blue;
                }
            }

            int averageRed = totalRed / totalPixels;
            int averageGreen = totalGreen / totalPixels;
            int averageBlue = totalBlue / totalPixels;
            int averageColor = (averageRed + averageGreen + averageBlue) / 3;
            int MaxColor = (maxRed + maxGreen + maxBlue) / 3;
            sensitivityValue = MaxColor - averageColor - 1;
            sensitivitySlider.Value = sensitivityValue;
            sensitivity.Text = "Sensitivity: " + sensitivityValue.ToString();
        }

        // if same file found, add new entry, else create new file with the current entry
        private void export_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML Files (*.xml)|*.xml";
            saveFileDialog.Title = "Export Spot Data";
            saveFileDialog.FileName = "spot_data.xml";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                XmlDocument xmlDoc = new XmlDocument();
                XmlElement rootElement;

                if (File.Exists(filePath))
                {
                    xmlDoc.Load(filePath);
                    rootElement = xmlDoc.DocumentElement;
                }
                else
                {
                    rootElement = xmlDoc.CreateElement("SpotData");
                    xmlDoc.AppendChild(rootElement);
                }

                XmlElement spotElement = xmlDoc.CreateElement("Spot");
                XmlElement imageNameElement = xmlDoc.CreateElement("ImageName");
                imageNameElement.InnerText = fileName;
                spotElement.AppendChild(imageNameElement);
                XmlElement timeElement = xmlDoc.CreateElement("Time");
                timeElement.InnerText = timeMs.ToString();
                spotElement.AppendChild(timeElement);

                XmlElement coordinatesElement = xmlDoc.CreateElement("Coordinates");
                coordinatesElement.SetAttribute("X", center.X.ToString());
                coordinatesElement.SetAttribute("Y", center.Y.ToString());
                spotElement.AppendChild(coordinatesElement);
                rootElement.AppendChild(spotElement);
                xmlDoc.Save(filePath);
                MessageBox.Show("Spot data exported successfully.", "Spot Detection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
