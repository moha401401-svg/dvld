namespace DVLD.Forms.Types
{
    partial class frmEditFees
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
        /// 
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescrbtion;
        private System.Windows.Forms.Label lblName;
        private Presentation.UI.RoundedButton btnCancel;
        private Presentation.UI.RoundedButton btnSave;
        private System.Windows.Forms.Label lblFees;
        private Presentation.UI.RoundedTextBox txtFees;

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDescrbtion = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnCancel = new DVLD.Presentation.UI.RoundedButton();
            this.btnSave = new DVLD.Presentation.UI.RoundedButton();
            this.lblFees = new System.Windows.Forms.Label();
            this.txtFees = new DVLD.Presentation.UI.RoundedTextBox();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 55);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(185, 42);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Edit Fees";
            // 
            // lblDescrbtion
            // 
            this.lblDescrbtion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescrbtion.Location = new System.Drawing.Point(12, 244);
            this.lblDescrbtion.Name = "lblDescrbtion";
            this.lblDescrbtion.Size = new System.Drawing.Size(469, 129);
            this.lblDescrbtion.TabIndex = 2;
            this.lblDescrbtion.Text = "Edit Fees";
            this.lblDescrbtion.Visible = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblName.Location = new System.Drawing.Point(13, 196);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(103, 25);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Edit Fees";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.MintCream;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCancel.Location = new System.Drawing.Point(320, 509);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Radius = 15;
            this.btnCancel.Size = new System.Drawing.Size(111, 46);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.MintCream;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSave.Location = new System.Drawing.Point(101, 509);
            this.btnSave.Name = "btnSave";
            this.btnSave.Radius = 15;
            this.btnSave.Size = new System.Drawing.Size(111, 46);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblFees
            // 
            this.lblFees.AutoSize = true;
            this.lblFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFees.Location = new System.Drawing.Point(14, 414);
            this.lblFees.Name = "lblFees";
            this.lblFees.Size = new System.Drawing.Size(45, 20);
            this.lblFees.TabIndex = 6;
            this.lblFees.Text = "Fees";
            // 
            // txtFees
            // 
            this.txtFees.BackColor = System.Drawing.Color.White;
            this.txtFees.DarkBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtFees.DarkForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtFees.EmailMode = false;
            this.txtFees.LightBackColor = System.Drawing.Color.Gray;
            this.txtFees.LightForeColor = System.Drawing.Color.Black;
            this.txtFees.Location = new System.Drawing.Point(92, 405);
            this.txtFees.MaxLength = 32767;
            this.txtFees.MinLength = 0;
            this.txtFees.Multiline = false;
            this.txtFees.Name = "txtFees";
            this.txtFees.OnlyLetters = false;
            this.txtFees.OnlyNumbers = true;
            this.txtFees.Placeholder = "";
            this.txtFees.Size = new System.Drawing.Size(179, 42);
            this.txtFees.State = DVLD.Presentation.UI.ValidationState.Normal;
            this.txtFees.TabIndex = 7;
            this.txtFees.UsePassword = false;
            this.txtFees.ValidationMessage = "";
            // 
            // frmEditFees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 567);
            this.Controls.Add(this.lblFees);
            this.Controls.Add(this.lblDescrbtion);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtFees);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmEditFees";
            this.Text = "frmEditFees";
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.txtFees, 0);
            this.Controls.SetChildIndex(this.lblName, 0);
            this.Controls.SetChildIndex(this.lblDescrbtion, 0);
            this.Controls.SetChildIndex(this.lblFees, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        
    }
}