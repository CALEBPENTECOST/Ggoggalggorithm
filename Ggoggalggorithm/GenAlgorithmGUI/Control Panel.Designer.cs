namespace GenAlgorithmGUI
{
    partial class Control_Panel
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
            this.groupBox_parameters = new System.Windows.Forms.GroupBox();
            this.button_restoreParams = new System.Windows.Forms.Button();
            this.button_applyParams = new System.Windows.Forms.Button();
            this.comboBox_algorithms = new System.Windows.Forms.ComboBox();
            this.label_algorithms = new System.Windows.Forms.Label();
            this.pictureBox_imgPreview = new System.Windows.Forms.PictureBox();
            this.groupBox_preview = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button_openFile = new System.Windows.Forms.Button();
            this.openFileDialog_openSourceImage = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tableLayoutPanel_parameters = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_parameter = new System.Windows.Forms.TextBox();
            this.textBox_value = new System.Windows.Forms.TextBox();
            this.groupBox_parameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_imgPreview)).BeginInit();
            this.groupBox_preview.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel_parameters.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_parameters
            // 
            this.groupBox_parameters.Controls.Add(this.tableLayoutPanel_parameters);
            this.groupBox_parameters.Location = new System.Drawing.Point(12, 39);
            this.groupBox_parameters.Name = "groupBox_parameters";
            this.groupBox_parameters.Size = new System.Drawing.Size(249, 470);
            this.groupBox_parameters.TabIndex = 4;
            this.groupBox_parameters.TabStop = false;
            this.groupBox_parameters.Text = "Algorithm Parameters";
            // 
            // button_restoreParams
            // 
            this.button_restoreParams.Location = new System.Drawing.Point(616, 515);
            this.button_restoreParams.Name = "button_restoreParams";
            this.button_restoreParams.Size = new System.Drawing.Size(75, 23);
            this.button_restoreParams.TabIndex = 6;
            this.button_restoreParams.Text = "Defaults";
            this.button_restoreParams.UseVisualStyleBackColor = true;
            // 
            // button_applyParams
            // 
            this.button_applyParams.Location = new System.Drawing.Point(697, 515);
            this.button_applyParams.Name = "button_applyParams";
            this.button_applyParams.Size = new System.Drawing.Size(75, 23);
            this.button_applyParams.TabIndex = 5;
            this.button_applyParams.Text = "Apply";
            this.button_applyParams.UseVisualStyleBackColor = true;
            // 
            // comboBox_algorithms
            // 
            this.comboBox_algorithms.FormattingEnabled = true;
            this.comboBox_algorithms.Location = new System.Drawing.Point(71, 12);
            this.comboBox_algorithms.Name = "comboBox_algorithms";
            this.comboBox_algorithms.Size = new System.Drawing.Size(184, 21);
            this.comboBox_algorithms.TabIndex = 7;
            // 
            // label_algorithms
            // 
            this.label_algorithms.AutoSize = true;
            this.label_algorithms.Location = new System.Drawing.Point(15, 12);
            this.label_algorithms.Name = "label_algorithms";
            this.label_algorithms.Size = new System.Drawing.Size(50, 13);
            this.label_algorithms.TabIndex = 8;
            this.label_algorithms.Text = "Algorithm";
            // 
            // pictureBox_imgPreview
            // 
            this.pictureBox_imgPreview.Location = new System.Drawing.Point(3, 3);
            this.pictureBox_imgPreview.Name = "pictureBox_imgPreview";
            this.pictureBox_imgPreview.Size = new System.Drawing.Size(62, 58);
            this.pictureBox_imgPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_imgPreview.TabIndex = 9;
            this.pictureBox_imgPreview.TabStop = false;
            // 
            // groupBox_preview
            // 
            this.groupBox_preview.Controls.Add(this.flowLayoutPanel1);
            this.groupBox_preview.Location = new System.Drawing.Point(267, 39);
            this.groupBox_preview.Name = "groupBox_preview";
            this.groupBox_preview.Size = new System.Drawing.Size(505, 473);
            this.groupBox_preview.TabIndex = 10;
            this.groupBox_preview.TabStop = false;
            this.groupBox_preview.Text = "Image Preview";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.pictureBox_imgPreview);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(499, 454);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // button_openFile
            // 
            this.button_openFile.Location = new System.Drawing.Point(273, 12);
            this.button_openFile.Name = "button_openFile";
            this.button_openFile.Size = new System.Drawing.Size(499, 23);
            this.button_openFile.TabIndex = 11;
            this.button_openFile.Text = "Open Image...";
            this.button_openFile.UseVisualStyleBackColor = true;
            this.button_openFile.Click += new System.EventHandler(this.button_openFile_Click);
            // 
            // openFileDialog_openSourceImage
            // 
            this.openFileDialog_openSourceImage.DefaultExt = "bmp";
            this.openFileDialog_openSourceImage.FileName = "sourceimage.bmp";
            this.openFileDialog_openSourceImage.Filter = "Images|*.bmp;*.jpg;*.png";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 544);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tableLayoutPanel_parameters
            // 
            this.tableLayoutPanel_parameters.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel_parameters.ColumnCount = 2;
            this.tableLayoutPanel_parameters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_parameters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_parameters.Controls.Add(this.textBox_parameter, 0, 0);
            this.tableLayoutPanel_parameters.Controls.Add(this.textBox_value, 1, 0);
            this.tableLayoutPanel_parameters.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel_parameters.Name = "tableLayoutPanel_parameters";
            this.tableLayoutPanel_parameters.RowCount = 1;
            this.tableLayoutPanel_parameters.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_parameters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_parameters.Size = new System.Drawing.Size(237, 445);
            this.tableLayoutPanel_parameters.TabIndex = 7;
            // 
            // textBox_parameter
            // 
            this.textBox_parameter.Enabled = false;
            this.textBox_parameter.Location = new System.Drawing.Point(4, 4);
            this.textBox_parameter.Name = "textBox_parameter";
            this.textBox_parameter.ReadOnly = true;
            this.textBox_parameter.Size = new System.Drawing.Size(111, 20);
            this.textBox_parameter.TabIndex = 0;
            this.textBox_parameter.Text = "Parameter";
            this.textBox_parameter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_value
            // 
            this.textBox_value.Enabled = false;
            this.textBox_value.Location = new System.Drawing.Point(122, 4);
            this.textBox_value.Name = "textBox_value";
            this.textBox_value.ReadOnly = true;
            this.textBox_value.Size = new System.Drawing.Size(111, 20);
            this.textBox_value.TabIndex = 1;
            this.textBox_value.Text = "Value";
            this.textBox_value.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Control_Panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 566);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button_restoreParams);
            this.Controls.Add(this.button_openFile);
            this.Controls.Add(this.button_applyParams);
            this.Controls.Add(this.groupBox_preview);
            this.Controls.Add(this.label_algorithms);
            this.Controls.Add(this.comboBox_algorithms);
            this.Controls.Add(this.groupBox_parameters);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Control_Panel";
            this.Text = "Control_Panel";
            this.groupBox_parameters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_imgPreview)).EndInit();
            this.groupBox_preview.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutPanel_parameters.ResumeLayout(false);
            this.tableLayoutPanel_parameters.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_parameters;
        private System.Windows.Forms.Button button_restoreParams;
        private System.Windows.Forms.Button button_applyParams;
        private System.Windows.Forms.ComboBox comboBox_algorithms;
        private System.Windows.Forms.Label label_algorithms;
        private System.Windows.Forms.PictureBox pictureBox_imgPreview;
        private System.Windows.Forms.GroupBox groupBox_preview;
        private System.Windows.Forms.Button button_openFile;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog_openSourceImage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_parameters;
        private System.Windows.Forms.TextBox textBox_parameter;
        private System.Windows.Forms.TextBox textBox_value;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}