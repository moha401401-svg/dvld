
using DVLD.Controls;
using DVLD.Presentation.UI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Forms
{
    public class frmLicenseNotes : BaseForm
    {
        private Label lblTitle;
        private TextBox txtNotes;

        private RoundedButton btnSend;
        private RoundedButton btnSkip;

        public bool SaveNotes
        {
            get;
            private set;
        }

        public string Notes
        {
            get
            {
                return txtNotes.Text.Trim();
            }
        }

        public frmLicenseNotes()
        {
            InitializeForm();
            InitializeControls();
        }

        private void InitializeForm()
        {
            Text = "License Notes";

            StartPosition =
                FormStartPosition.CenterParent;

            FormBorderStyle =
                FormBorderStyle.FixedDialog;

            MaximizeBox = false;
            MinimizeBox = false;

            ClientSize =
                new Size(420, 180);

            BackColor =
                Theme.AppBackground;
        }

        private void InitializeControls()
        {
            lblTitle =
                new Label();

            lblTitle.Text =
                "Do you want to add any notes?";

            lblTitle.Font =
                new Font(
                    "Segoe UI",
                    11,
                    FontStyle.Bold);

            lblTitle.ForeColor =
                Theme.TextPrimary;

            lblTitle.AutoSize = false;

            lblTitle.Size =
                new Size(360, 30);

            lblTitle.Location =
                new Point(30, 20);

            Controls.Add(lblTitle);



            txtNotes =
                new TextBox();

            txtNotes.Multiline = true;

            txtNotes.Size =
                new Size(360, 55);

            txtNotes.Location =
                new Point(30, 60);

            Controls.Add(txtNotes);



            btnSend =
                new RoundedButton();

            btnSend.Text =
                "Send";

            btnSend.Size =
                new Size(120, 40);

            btnSend.Location =
                new Point(70, 125);

            btnSend.Click += BtnSend_Click;

            Controls.Add(btnSend);



            btnSkip =
                new RoundedButton();

            btnSkip.Text =
                "Skip";

            btnSkip.Size =
                new Size(120, 40);

            btnSkip.Location =
                new Point(230, 125);

            btnSkip.NormalColor =
                Color.Gray;

            btnSkip.HoverColor =
                Color.DimGray;

            btnSkip.Click += BtnSkip_Click;

            Controls.Add(btnSkip);
        }

        private void BtnSend_Click(
            object sender,
            EventArgs e)
        {
            SaveNotes =
                !string.IsNullOrWhiteSpace(
                    txtNotes.Text);

            DialogResult =
                DialogResult.OK;

            Close();
        }

        private void BtnSkip_Click(
            object sender,
            EventArgs e)
        {
            SaveNotes = false;

            DialogResult =
                DialogResult.OK;

            Close();
        }
    }
}

