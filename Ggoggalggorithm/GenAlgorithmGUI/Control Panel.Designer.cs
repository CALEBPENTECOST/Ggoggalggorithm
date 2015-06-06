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
            this.textBox_value = new System.Windows.Forms.TextBox();
            this.textBox_parameter = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel_parameters = new System.Windows.Forms.TableLayoutPanel();
            this.button_restoreParams = new System.Windows.Forms.Button();
            this.button_applyParams = new System.Windows.Forms.Button();
            this.comboBox_algorithms = new System.Windows.Forms.ComboBox();
            this.label_algorithms = new System.Windows.Forms.Label();
            this.groupBox_preview = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox_imgPreview = new System.Windows.Forms.PictureBox();
            this.button_openFile = new System.Windows.Forms.Button();
            this.openFileDialog_openSourceImage = new System.Windows.Forms.OpenFileDialog();
            this.groupBox_parameters.SuspendLayout();
            this.groupBox_preview.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_imgPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_parameters
            // 
            this.groupBox_parameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox_parameters.Controls.Add(this.textBox_value);
            this.groupBox_parameters.Controls.Add(this.textBox_parameter);
            this.groupBox_parameters.Controls.Add(this.tableLayoutPanel_parameters);
            this.groupBox_parameters.Location = new System.Drawing.Point(12, 39);
            this.groupBox_parameters.Name = "groupBox_parameters";
            this.groupBox_parameters.Size = new System.Drawing.Size(346, 483);
            this.groupBox_parameters.TabIndex = 4;
            this.groupBox_parameters.TabStop = false;
            this.groupBox_parameters.Text = "Algorithm Parameters";
            // 
            // textBox_value
            // 
            this.textBox_value.Enabled = false;
            this.textBox_value.Location = new System.Drawing.Point(229, 24);
            this.textBox_value.Name = "textBox_value";
            this.textBox_value.ReadOnly = true;
            this.textBox_value.Size = new System.Drawing.Size(111, 20);
            this.textBox_value.TabIndex = 1;
            this.textBox_value.Text = "Value";
            this.textBox_value.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_parameter
            // 
            this.textBox_parameter.Enabled = false;
            this.textBox_parameter.Location = new System.Drawing.Point(6, 24);
            this.textBox_parameter.Name = "textBox_parameter";
            this.textBox_parameter.ReadOnly = true;
            this.textBox_parameter.Size = new System.Drawing.Size(111, 20);
            this.textBox_parameter.TabIndex = 0;
            this.textBox_parameter.Text = "Parameter";
            this.textBox_parameter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tableLayoutPanel_parameters
            // 
            this.tableLayoutPanel_parameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tableLayoutPanel_parameters.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel_parameters.ColumnCount = 2;
            this.tableLayoutPanel_parameters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tableLayoutPanel_parameters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tableLayoutPanel_parameters.Location = new System.Drawing.Point(6, 50);
            this.tableLayoutPanel_parameters.Name = "tableLayoutPanel_parameters";
            this.tableLayoutPanel_parameters.RowCount = 1;
            this.tableLayoutPanel_parameters.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_parameters.Size = new System.Drawing.Size(334, 427);
            this.tableLayoutPanel_parameters.TabIndex = 7;
            // 
            // button_restoreParams
            // 
            this.button_restoreParams.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_restoreParams.Location = new System.Drawing.Point(616, 531);
            this.button_restoreParams.Name = "button_restoreParams";
            this.button_restoreParams.Size = new System.Drawing.Size(75, 23);
            this.button_restoreParams.TabIndex = 6;
            this.button_restoreParams.Text = "Defaults";
            this.button_restoreParams.UseVisualStyleBackColor = true;
            // 
            // button_applyParams
            // 
            this.button_applyParams.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_applyParams.Location = new System.Drawing.Point(697, 531);
            this.button_applyParams.Name = "button_applyParams";
            this.button_applyParams.Size = new System.Drawing.Size(75, 23);
            this.button_applyParams.TabIndex = 5;
            this.button_applyParams.Text = "Apply";
            this.button_applyParams.UseVisualStyleBackColor = true;
            this.button_applyParams.Click += new System.EventHandler(this.button_applyParams_Click);
            // 
            // comboBox_algorithms
            // 
            this.comboBox_algorithms.FormattingEnabled = true;
            this.comboBox_algorithms.Location = new System.Drawing.Point(71, 12);
            this.comboBox_algorithms.Name = "comboBox_algorithms";
            this.comboBox_algorithms.Size = new System.Drawing.Size(287, 21);
            this.comboBox_algorithms.TabIndex = 7;
            this.comboBox_algorithms.SelectedIndexChanged += new System.EventHandler(this.comboBox_algorithms_SelectedIndexChanged);
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
            // groupBox_preview
            // 
            this.groupBox_preview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_preview.Controls.Add(this.flowLayoutPanel1);
            this.groupBox_preview.Location = new System.Drawing.Point(364, 39);
            this.groupBox_preview.Name = "groupBox_preview";
            this.groupBox_preview.Size = new System.Drawing.Size(408, 486);
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
            this.flowLayoutPanel1.Size = new System.Drawing.Size(402, 467);
            this.flowLayoutPanel1.TabIndex = 10;
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
            // button_openFile
            // 
            this.button_openFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_openFile.Location = new System.Drawing.Point(364, 12);
            this.button_openFile.Name = "button_openFile";
            this.button_openFile.Size = new System.Drawing.Size(408, 23);
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
            // Control_Panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 566);
            this.Controls.Add(this.button_restoreParams);
            this.Controls.Add(this.button_openFile);
            this.Controls.Add(this.button_applyParams);
            this.Controls.Add(this.groupBox_preview);
            this.Controls.Add(this.label_algorithms);
            this.Controls.Add(this.comboBox_algorithms);
            this.Controls.Add(this.groupBox_parameters);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Control_Panel";
            this.Text = "Control_Panel";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Control_Panel_FormClosed);
            this.groupBox_parameters.ResumeLayout(false);
            this.groupBox_parameters.PerformLayout();
            this.groupBox_preview.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_imgPreview)).EndInit();
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
    }
}