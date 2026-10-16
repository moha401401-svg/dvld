namespace DVLD.Forms.Applications
{
    partial class frmLDLApplicants
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
            this.searchGridControl1 = new DVLD.Controls.SearchGridControl();
            this.SuspendLayout();
            // 
            // searchGridControl1
            // 
            this.searchGridControl1.Location = new System.Drawing.Point(12, 80);
            this.searchGridControl1.Name = "searchGridControl1";
            this.searchGridControl1.Size = new System.Drawing.Size(1470, 530);
            this.searchGridControl1.TabIndex = 1;
            // 
            // frmLDLApplicznts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1513, 694);
            this.Controls.Add(this.searchGridControl1);
            this.Name = "frmLDLApplicznts";
            this.Text = "frmLDLApplicznts";
            this.Controls.SetChildIndex(this.searchGridControl1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.SearchGridControl searchGridControl1;
    }
}