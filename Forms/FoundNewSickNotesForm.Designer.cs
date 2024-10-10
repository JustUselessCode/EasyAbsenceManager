namespace EasyAbsenceManager
{
    partial class FoundNewSickNotesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FoundNewSickNotesForm));
            this.CancelAddInExecutionButton = new System.Windows.Forms.Button();
            this.ExecuteAddonButton = new System.Windows.Forms.Button();
            this.ManagerInfoLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.GetHelpButton = new System.Windows.Forms.Button();
            this.SickNoteListBox = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CancelAddInExecutionButton
            // 
            this.CancelAddInExecutionButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelAddInExecutionButton.Location = new System.Drawing.Point(587, 391);
            this.CancelAddInExecutionButton.Name = "CancelAddInExecutionButton";
            this.CancelAddInExecutionButton.Size = new System.Drawing.Size(100, 38);
            this.CancelAddInExecutionButton.TabIndex = 1;
            this.CancelAddInExecutionButton.Text = "Abbrechen";
            this.CancelAddInExecutionButton.UseVisualStyleBackColor = true;
            // 
            // ExecuteAddonButton
            // 
            this.ExecuteAddonButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ExecuteAddonButton.Location = new System.Drawing.Point(693, 391);
            this.ExecuteAddonButton.Name = "ExecuteAddonButton";
            this.ExecuteAddonButton.Size = new System.Drawing.Size(95, 38);
            this.ExecuteAddonButton.TabIndex = 2;
            this.ExecuteAddonButton.Text = "Ausführen";
            this.ExecuteAddonButton.UseVisualStyleBackColor = true;
            // 
            // ManagerInfoLabel
            // 
            this.ManagerInfoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ManagerInfoLabel.AutoSize = true;
            this.ManagerInfoLabel.Location = new System.Drawing.Point(12, 9);
            this.ManagerInfoLabel.Name = "ManagerInfoLabel";
            this.ManagerInfoLabel.Size = new System.Drawing.Size(0, 20);
            this.ManagerInfoLabel.TabIndex = 3;
            this.ManagerInfoLabel.Click += new System.EventHandler(this.SickNoteCountLabel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.GetHelpButton);
            this.panel1.Controls.Add(this.SickNoteListBox);
            this.panel1.Controls.Add(this.ManagerInfoLabel);
            this.panel1.Controls.Add(this.ExecuteAddonButton);
            this.panel1.Controls.Add(this.CancelAddInExecutionButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // GetHelpButton
            // 
            this.GetHelpButton.Location = new System.Drawing.Point(699, 12);
            this.GetHelpButton.Name = "GetHelpButton";
            this.GetHelpButton.Size = new System.Drawing.Size(75, 31);
            this.GetHelpButton.TabIndex = 5;
            this.GetHelpButton.Text = "Hilfe";
            this.GetHelpButton.UseVisualStyleBackColor = true;
            this.GetHelpButton.Click += new System.EventHandler(this.GetHelpButton_Click);
            // 
            // SickNoteListBox
            // 
            this.SickNoteListBox.FormattingEnabled = true;
            this.SickNoteListBox.ItemHeight = 20;
            this.SickNoteListBox.Location = new System.Drawing.Point(58, 49);
            this.SickNoteListBox.Name = "SickNoteListBox";
            this.SickNoteListBox.ScrollAlwaysVisible = true;
            this.SickNoteListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.SickNoteListBox.Size = new System.Drawing.Size(716, 324);
            this.SickNoteListBox.TabIndex = 4;
            // 
            // FoundNewSickNotesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FoundNewSickNotesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " EasyAbsenceManager";
            this.Load += new System.EventHandler(this.FoundNewSickNotesForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button CancelAddInExecutionButton;
        private System.Windows.Forms.Button ExecuteAddonButton;
        public System.Windows.Forms.Label ManagerInfoLabel;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.ListBox SickNoteListBox;
        public System.Windows.Forms.Button GetHelpButton;
    }
}