namespace EasyAbsenceManager.Forms
{
    partial class StartupInfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartupInfoForm));
            this.InfoLabel = new System.Windows.Forms.Label();
            this.StartupContinueButton = new System.Windows.Forms.Button();
            this.eventLog1 = new System.Diagnostics.EventLog();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            this.SuspendLayout();
            // 
            // InfoLabel
            // 
            this.InfoLabel.AutoSize = true;
            this.InfoLabel.Location = new System.Drawing.Point(12, 9);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(40, 20);
            this.InfoLabel.TabIndex = 0;
            this.InfoLabel.Text = "Test";
            this.InfoLabel.Click += new System.EventHandler(this.InfoLabel_Click);
            // 
            // StartupContinueButton
            // 
            this.StartupContinueButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.StartupContinueButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.StartupContinueButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.StartupContinueButton.Location = new System.Drawing.Point(324, 151);
            this.StartupContinueButton.Name = "StartupContinueButton";
            this.StartupContinueButton.Size = new System.Drawing.Size(98, 36);
            this.StartupContinueButton.TabIndex = 1;
            this.StartupContinueButton.Text = "Weiter";
            this.StartupContinueButton.UseVisualStyleBackColor = true;
            this.StartupContinueButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // StartupInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(434, 199);
            this.Controls.Add(this.StartupContinueButton);
            this.Controls.Add(this.InfoLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StartupInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Information";
            this.Load += new System.EventHandler(this.StartupInfoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label InfoLabel;
        public System.Windows.Forms.Button StartupContinueButton;
        private System.Diagnostics.EventLog eventLog1;
    }
}