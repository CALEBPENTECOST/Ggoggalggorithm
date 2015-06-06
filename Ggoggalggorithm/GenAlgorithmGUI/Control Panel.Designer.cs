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
            this.button_oneStep = new System.Windows.Forms.Button();
            this.button_nextBest = new System.Windows.Forms.Button();
            this.button_startstop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_oneStep
            // 
            this.button_oneStep.Location = new System.Drawing.Point(12, 407);
            this.button_oneStep.Name = "button_oneStep";
            this.button_oneStep.Size = new System.Drawing.Size(75, 23);
            this.button_oneStep.TabIndex = 0;
            this.button_oneStep.Text = "One Step";
            this.button_oneStep.UseVisualStyleBackColor = true;
            // 
            // button_nextBest
            // 
            this.button_nextBest.Location = new System.Drawing.Point(93, 407);
            this.button_nextBest.Name = "button_nextBest";
            this.button_nextBest.Size = new System.Drawing.Size(75, 23);
            this.button_nextBest.TabIndex = 1;
            this.button_nextBest.Text = "Next Best";
            this.button_nextBest.UseVisualStyleBackColor = true;
            // 
            // button_startstop
            // 
            this.button_startstop.Location = new System.Drawing.Point(537, 407);
            this.button_startstop.Name = "button_startstop";
            this.button_startstop.Size = new System.Drawing.Size(75, 23);
            this.button_startstop.TabIndex = 2;
            this.button_startstop.Text = "start/stop";
            this.button_startstop.UseVisualStyleBackColor = true;
            // 
            // Control_Panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.button_startstop);
            this.Controls.Add(this.button_nextBest);
            this.Controls.Add(this.button_oneStep);
            this.MaximumSize = new System.Drawing.Size(640, 480);
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "Control_Panel";
            this.Text = "Control_Panel";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_oneStep;
        private System.Windows.Forms.Button button_nextBest;
        private System.Windows.Forms.Button button_startstop;
    }
}