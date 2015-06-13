namespace GenAlgorithmGUI
{
    partial class AlgorithmStepForm
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
            this.groupBox_stepFuncs = new System.Windows.Forms.GroupBox();
            this.button_stop = new System.Windows.Forms.Button();
            this.button_start = new System.Windows.Forms.Button();
            this.button_nextBest = new System.Windows.Forms.Button();
            this.button_stepOnce = new System.Windows.Forms.Button();
            this.pictureBox_genImage = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_step = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_fitness = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_lastbestfit = new System.Windows.Forms.ToolStripStatusLabel();
            this.backgroundWorker_stepProcessor = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.toolStripStatusLabel_numPolygons = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox_stepFuncs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_genImage)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_stepFuncs
            // 
            this.groupBox_stepFuncs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox_stepFuncs.Controls.Add(this.button_stop);
            this.groupBox_stepFuncs.Controls.Add(this.button_start);
            this.groupBox_stepFuncs.Controls.Add(this.button_nextBest);
            this.groupBox_stepFuncs.Controls.Add(this.button_stepOnce);
            this.groupBox_stepFuncs.Location = new System.Drawing.Point(12, 12);
            this.groupBox_stepFuncs.Name = "groupBox_stepFuncs";
            this.groupBox_stepFuncs.Size = new System.Drawing.Size(170, 529);
            this.groupBox_stepFuncs.TabIndex = 0;
            this.groupBox_stepFuncs.TabStop = false;
            this.groupBox_stepFuncs.Text = "Step...";
            // 
            // button_stop
            // 
            this.button_stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_stop.Enabled = false;
            this.button_stop.Location = new System.Drawing.Point(6, 500);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(158, 23);
            this.button_stop.TabIndex = 3;
            this.button_stop.Text = "Stop";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // button_start
            // 
            this.button_start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_start.Location = new System.Drawing.Point(6, 471);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(158, 23);
            this.button_start.TabIndex = 2;
            this.button_start.Text = "Start";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_nextBest
            // 
            this.button_nextBest.Location = new System.Drawing.Point(6, 48);
            this.button_nextBest.Name = "button_nextBest";
            this.button_nextBest.Size = new System.Drawing.Size(158, 23);
            this.button_nextBest.TabIndex = 1;
            this.button_nextBest.Text = "Next Best";
            this.button_nextBest.UseVisualStyleBackColor = true;
            this.button_nextBest.Click += new System.EventHandler(this.button_nextBest_Click);
            // 
            // button_stepOnce
            // 
            this.button_stepOnce.Location = new System.Drawing.Point(6, 19);
            this.button_stepOnce.Name = "button_stepOnce";
            this.button_stepOnce.Size = new System.Drawing.Size(158, 23);
            this.button_stepOnce.TabIndex = 0;
            this.button_stepOnce.Text = "Once";
            this.button_stepOnce.UseVisualStyleBackColor = true;
            this.button_stepOnce.Click += new System.EventHandler(this.button_stepOnce_Click);
            // 
            // pictureBox_genImage
            // 
            this.pictureBox_genImage.Location = new System.Drawing.Point(3, 3);
            this.pictureBox_genImage.Name = "pictureBox_genImage";
            this.pictureBox_genImage.Size = new System.Drawing.Size(94, 82);
            this.pictureBox_genImage.TabIndex = 1;
            this.pictureBox_genImage.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_step,
            this.toolStripStatusLabel_fitness,
            this.toolStripStatusLabel_lastbestfit,
            this.toolStripStatusLabel_numPolygons});
            this.statusStrip1.Location = new System.Drawing.Point(0, 544);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_step
            // 
            this.toolStripStatusLabel_step.Name = "toolStripStatusLabel_step";
            this.toolStripStatusLabel_step.Size = new System.Drawing.Size(139, 17);
            this.toolStripStatusLabel_step.Text = "toolStripStatusLabel_step";
            // 
            // toolStripStatusLabel_fitness
            // 
            this.toolStripStatusLabel_fitness.Name = "toolStripStatusLabel_fitness";
            this.toolStripStatusLabel_fitness.Size = new System.Drawing.Size(151, 17);
            this.toolStripStatusLabel_fitness.Text = "toolStripStatusLabel_fitness";
            // 
            // toolStripStatusLabel_lastbestfit
            // 
            this.toolStripStatusLabel_lastbestfit.Name = "toolStripStatusLabel_lastbestfit";
            this.toolStripStatusLabel_lastbestfit.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel_lastbestfit.Text = "toolStripStatusLabel1";
            // 
            // backgroundWorker_stepProcessor
            // 
            this.backgroundWorker_stepProcessor.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_stepProcessor_DoWork);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(188, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(584, 523);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generated Image";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.pictureBox_genImage);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(578, 504);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // toolStripStatusLabel_numPolygons
            // 
            this.toolStripStatusLabel_numPolygons.Name = "toolStripStatusLabel_numPolygons";
            this.toolStripStatusLabel_numPolygons.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel_numPolygons.Text = "toolStripStatusLabel1";
            // 
            // AlgorithmStepForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(784, 566);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox_stepFuncs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "AlgorithmStepForm";
            this.Text = "AlgorithmStepForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AlgorithmStepForm_FormClosed);
            this.groupBox_stepFuncs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_genImage)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_stepFuncs;
        private System.Windows.Forms.Button button_stop;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_nextBest;
        private System.Windows.Forms.Button button_stepOnce;
        private System.Windows.Forms.PictureBox pictureBox_genImage;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_step;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_fitness;
        private System.ComponentModel.BackgroundWorker backgroundWorker_stepProcessor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_lastbestfit;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_numPolygons;
    }
}