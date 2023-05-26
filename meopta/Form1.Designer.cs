namespace meopta
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.uploadButton = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.sensitivitySlider = new System.Windows.Forms.TrackBar();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.findSpot = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label_x = new System.Windows.Forms.Label();
            this.label_y = new System.Windows.Forms.Label();
            this.sensitivity = new System.Windows.Forms.Label();
            this.autoSensitivity = new System.Windows.Forms.Button();
            this.Time = new System.Windows.Forms.Label();
            this.time_label = new System.Windows.Forms.Label();
            this.export = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.info_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sensitivitySlider)).BeginInit();
            this.SuspendLayout();
            // 
            // uploadButton
            // 
            this.uploadButton.Location = new System.Drawing.Point(12, 12);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(143, 23);
            this.uploadButton.TabIndex = 0;
            this.uploadButton.Text = "Upload";
            this.uploadButton.UseVisualStyleBackColor = true;
            this.uploadButton.Click += new System.EventHandler(this.uploadButton_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Enabled = false;
            this.pictureBox.Location = new System.Drawing.Point(161, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1256, 693);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // sensitivitySlider
            // 
            this.sensitivitySlider.Location = new System.Drawing.Point(12, 54);
            this.sensitivitySlider.Maximum = 255;
            this.sensitivitySlider.Name = "sensitivitySlider";
            this.sensitivitySlider.Size = new System.Drawing.Size(143, 45);
            this.sensitivitySlider.TabIndex = 2;
            this.sensitivitySlider.ValueChanged += new System.EventHandler(this.SensitivitySlider_ValueChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // findSpot
            // 
            this.findSpot.Location = new System.Drawing.Point(12, 114);
            this.findSpot.Name = "findSpot";
            this.findSpot.Size = new System.Drawing.Size(143, 23);
            this.findSpot.TabIndex = 4;
            this.findSpot.Text = "Find spot";
            this.findSpot.UseVisualStyleBackColor = true;
            this.findSpot.Click += new System.EventHandler(this.findSpot_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(9, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Coordinates:";
            // 
            // label_x
            // 
            this.label_x.AutoSize = true;
            this.label_x.Location = new System.Drawing.Point(9, 229);
            this.label_x.Name = "label_x";
            this.label_x.Size = new System.Drawing.Size(0, 13);
            this.label_x.TabIndex = 6;
            // 
            // label_y
            // 
            this.label_y.AutoSize = true;
            this.label_y.Location = new System.Drawing.Point(9, 242);
            this.label_y.Name = "label_y";
            this.label_y.Size = new System.Drawing.Size(0, 13);
            this.label_y.TabIndex = 7;
            // 
            // sensitivity
            // 
            this.sensitivity.AutoSize = true;
            this.sensitivity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sensitivity.Location = new System.Drawing.Point(9, 38);
            this.sensitivity.Name = "sensitivity";
            this.sensitivity.Size = new System.Drawing.Size(80, 13);
            this.sensitivity.TabIndex = 8;
            this.sensitivity.Text = "Sensitivity: 0";
            // 
            // autoSensitivity
            // 
            this.autoSensitivity.Location = new System.Drawing.Point(12, 85);
            this.autoSensitivity.Name = "autoSensitivity";
            this.autoSensitivity.Size = new System.Drawing.Size(143, 23);
            this.autoSensitivity.TabIndex = 9;
            this.autoSensitivity.Text = "Auto sensitivity";
            this.autoSensitivity.UseVisualStyleBackColor = true;
            this.autoSensitivity.Click += new System.EventHandler(this.autoSensitivity_Click);
            // 
            // Time
            // 
            this.Time.AutoSize = true;
            this.Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Time.ForeColor = System.Drawing.Color.Black;
            this.Time.Location = new System.Drawing.Point(9, 271);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(38, 13);
            this.Time.TabIndex = 10;
            this.Time.Text = "Time:";
            // 
            // time_label
            // 
            this.time_label.AutoSize = true;
            this.time_label.Location = new System.Drawing.Point(12, 284);
            this.time_label.Name = "time_label";
            this.time_label.Size = new System.Drawing.Size(0, 13);
            this.time_label.TabIndex = 11;
            // 
            // export
            // 
            this.export.Enabled = false;
            this.export.Location = new System.Drawing.Point(12, 144);
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(143, 23);
            this.export.TabIndex = 12;
            this.export.Text = "Export to XML";
            this.toolTip1.SetToolTip(this.export, "Replace existing file for new entry or save new file");
            this.export.UseVisualStyleBackColor = true;
            this.export.Click += new System.EventHandler(this.export_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 0;
            this.toolTip1.AutoPopDelay = 0;
            this.toolTip1.InitialDelay = 0;
            this.toolTip1.ReshowDelay = 0;
            this.toolTip1.ShowAlways = true;
            this.toolTip1.UseAnimation = false;
            this.toolTip1.UseFading = false;
            // 
            // info_label
            // 
            this.info_label.AutoSize = true;
            this.info_label.Location = new System.Drawing.Point(12, 170);
            this.info_label.Name = "info_label";
            this.info_label.Size = new System.Drawing.Size(139, 26);
            this.info_label.TabIndex = 14;
            this.info_label.Text = "Replace existing file for new\r\nentry or save new file";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1417, 692);
            this.Controls.Add(this.info_label);
            this.Controls.Add(this.export);
            this.Controls.Add(this.time_label);
            this.Controls.Add(this.Time);
            this.Controls.Add(this.autoSensitivity);
            this.Controls.Add(this.sensitivity);
            this.Controls.Add(this.label_y);
            this.Controls.Add(this.label_x);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.findSpot);
            this.Controls.Add(this.sensitivitySlider);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.uploadButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Meopta - spot locator";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sensitivitySlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uploadButton;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TrackBar sensitivitySlider;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button findSpot;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_x;
        private System.Windows.Forms.Label label_y;
        private System.Windows.Forms.Label sensitivity;
        private System.Windows.Forms.Button autoSensitivity;
        private System.Windows.Forms.Label Time;
        private System.Windows.Forms.Label time_label;
        private System.Windows.Forms.Button export;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label info_label;
    }
}
