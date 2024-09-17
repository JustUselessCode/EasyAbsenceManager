namespace EasyAbsenceManager.Forms
{
    partial class ManuallyProcessedEmailsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManuallyProcessedEmailsForm));
            this.GetHelpButton = new System.Windows.Forms.Button();
            this.SickNoteListBox = new System.Windows.Forms.ListBox();
            this.ManagerInfoLabel = new System.Windows.Forms.Label();
            this.ExecuteAddonButton = new System.Windows.Forms.Button();
            this.CancelAddInExecutionButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GetHelpButton
            // 
            this.GetHelpButton.Location = new System.Drawing.Point(699, 18);
            this.GetHelpButton.Name = "GetHelpButton";
            this.GetHelpButton.Size = new System.Drawing.Size(75, 31);
            this.GetHelpButton.TabIndex = 10;
            this.GetHelpButton.Text = "Hilfe";
            this.GetHelpButton.UseVisualStyleBackColor = true;
            // 
            // SickNoteListBox
            // 
            this.SickNoteListBox.FormattingEnabled = true;
            this.SickNoteListBox.ItemHeight = 20;
            this.SickNoteListBox.Location = new System.Drawing.Point(58, 55);
            this.SickNoteListBox.Name = "SickNoteListBox";
            this.SickNoteListBox.ScrollAlwaysVisible = true;
            this.SickNoteListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.SickNoteListBox.Size = new System.Drawing.Size(716, 324);
            this.SickNoteListBox.TabIndex = 9;
            // 
            // ManagerInfoLabel
            // 
            this.ManagerInfoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ManagerInfoLabel.AutoSize = true;
            this.ManagerInfoLabel.Location = new System.Drawing.Point(12, 15);
            this.ManagerInfoLabel.Name = "ManagerInfoLabel";
            this.ManagerInfoLabel.Size = new System.Drawing.Size(0, 20);
            this.ManagerInfoLabel.TabIndex = 8;
            this.ManagerInfoLabel.Click += new System.EventHandler(this.ManagerInfoLabel_Click);
            // 
            // ExecuteAddonButton
            // 
            this.ExecuteAddonButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ExecuteAddonButton.Location = new System.Drawing.Point(693, 397);
            this.ExecuteAddonButton.Name = "ExecuteAddonButton";
            this.ExecuteAddonButton.Size = new System.Drawing.Size(95, 38);
            this.ExecuteAddonButton.TabIndex = 7;
            this.ExecuteAddonButton.Text = "Ausführen";
            this.ExecuteAddonButton.UseVisualStyleBackColor = true;
            // 
            // CancelAddInExecutionButton
            // 
            this.CancelAddInExecutionButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelAddInExecutionButton.Location = new System.Drawing.Point(587, 397);
            this.CancelAddInExecutionButton.Name = "CancelAddInExecutionButton";
            this.CancelAddInExecutionButton.Size = new System.Drawing.Size(100, 38);
            this.CancelAddInExecutionButton.TabIndex = 6;
            this.CancelAddInExecutionButton.Text = "Abbrechen";
            this.CancelAddInExecutionButton.UseVisualStyleBackColor = true;
            // 
            // ManuallyProcessedEmailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GetHelpButton);
            this.Controls.Add(this.SickNoteListBox);
            this.Controls.Add(this.ManagerInfoLabel);
            this.Controls.Add(this.ExecuteAddonButton);
            this.Controls.Add(this.CancelAddInExecutionButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ManuallyProcessedEmailsForm";
            this.Text = " Erster Start";
            this.Load += new System.EventHandler(this.ManuallyProcessedEmailsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button GetHelpButton;
        public System.Windows.Forms.ListBox SickNoteListBox;
        public System.Windows.Forms.Label ManagerInfoLabel;
        private System.Windows.Forms.Button ExecuteAddonButton;
        private System.Windows.Forms.Button CancelAddInExecutionButton;
    }
}