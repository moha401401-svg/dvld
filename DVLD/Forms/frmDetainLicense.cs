using BusinessLayer;
using BusinessLayer.Models;
using DVLD.Controls;
using DVLD.Presentation.UI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Forms
{
    public partial class  frmDetainLicense : BaseForm
    {

        private Label lblTitle;

        private Panel pnlLicenseCard;
        private Panel pnlDetails;


        private LicenseInfoCard licenseCard;


        private Label lblDateTitle;
        private Label lblDateValue;


        private Label lblFineTitle;

        private RoundedTextBox txtFine;


        private RoundedButton btnDetain;
        private RoundedButton btnCancel;


        private int _licenseID;



        public frmDetainLicense(int licenseID)
        {
            _licenseID =
                licenseID;


            InitializeForm();

            InitializeUI();

            LoadLicense();
        }



        private void InitializeForm()
        {
            Text =
                "Detain License";


            StartPosition =
                FormStartPosition.CenterScreen;


            ClientSize =
                new Size(
                    1040,
                    700);


            BackColor =
                Theme.AppBackground;
        }




        private void InitializeUI()
        {

            lblTitle =
                new Label();


            lblTitle.Text =
                "🚫 Detain License";


            lblTitle.Dock =
                DockStyle.Top;


            lblTitle.Height =
                60;


            lblTitle.Font =
                new Font(
                    "Segoe UI",
                    20,
                    FontStyle.Bold);


            lblTitle.ForeColor =
                Theme.TextPrimary;


            lblTitle.TextAlign =
                ContentAlignment.MiddleCenter;


            Controls.Add(
                lblTitle);




            pnlLicenseCard =
                new Panel();


            pnlLicenseCard.Location =
                new Point(
                    30,
                    80);


            pnlLicenseCard.Size =
                new Size(
                    1000,
                    300);


            pnlLicenseCard.BackColor =
                Theme.CardBackground;


            Controls.Add(
                pnlLicenseCard);



            licenseCard =
                new LicenseInfoCard();


            licenseCard.Dock =
                DockStyle.Fill;


            pnlLicenseCard.Controls.Add(
                licenseCard);





            pnlDetails =
                new Panel();


            pnlDetails.Location =
                new Point(
                    30,
                    500);


            pnlDetails.Size =
                new Size(
                    500,
                    120);


            pnlDetails.BackColor =
                Theme.CardBackground;


            Controls.Add(
                pnlDetails);




            lblDateTitle =
                CreateTitle(
                    "📅 Detain Date");


            lblDateValue =
                CreateValue(
                    DateTime.Now
                    .ToShortDateString());



            AddRow(
                lblDateTitle,
                lblDateValue,
                20);




            lblFineTitle =
                CreateTitle(
                    "💰 Fine Fees");


            lblFineTitle.Location =
                new Point(
                    30,
                    68);


            txtFine =
                new RoundedTextBox();


            txtFine.Size =
                new Size(
                    200,
                    35);


            txtFine.Location =
                new Point(
                    210,
                    65);

            txtFine.MaxLength= 9999;

            txtFine.KeyPress +=
                TxtFine_KeyPress;



            pnlDetails.Controls.Add(
                lblFineTitle);


            pnlDetails.Controls.Add(
                txtFine);



            btnDetain =
                new RoundedButton();


            btnDetain.Text =
                "Detain";


            btnDetain.Size =
                new Size(
                    120,
                    40);


            btnDetain.Location =
                new Point(
                    600,
                    600);


            btnDetain.Click +=
                BtnDetain_Click;



            Controls.Add(
                btnDetain);




            btnCancel =
                new RoundedButton();


            btnCancel.Text =
                "Cancel";


            btnCancel.Size =
                new Size(
                    120,
                    40);


            btnCancel.Location =
                new Point(
                    740,
                    600);



            btnCancel.Click +=
                (s, e) =>
                Close();


            Controls.Add(
                btnCancel);
        }





        private void LoadLicense()
        {

            


            if (_licenseID != null)
            {
                licenseCard.LoadLicense( _licenseID);
            }
        }




        private void BtnDetain_Click(
            object sender,
            EventArgs e)
        {

            if (!decimal.TryParse(
                txtFine.Text,
                out decimal fine))
            {
                CustomMessageBox.Show(
                    "Failed!",
                    "Please enter valid fine fees");

                return;
            }

            if (Convert.ToDecimal(txtFine.Text) > txtFine.MaxLength)
            {
                CustomMessageBox.Show(
                    "Failed!",
                    "Max fees fine is 9999");
                txtFine.State = ValidationState.Invalid;
                

                return;
            }
            txtFine.State=ValidationState.Valid;    
            int id =DetainedLicenses.AddDetainedLicense(_licenseID, Convert.ToDecimal(txtFine.Text));
                  



            if (id > 0)
            {
                CustomMessageBox.Show(
                    "Done!",
                    "License detained successfully");

                Close();
            }

        }





        private void TxtFine_KeyPress(
            object sender,
            KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar)
                && e.KeyChar != '.'
                && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }




        private void AddRow(
            Label title,
            Label value,
            int y)
        {

            title.Location =
                new Point(
                    30,
                    y);


            value.Location =
                new Point(
                    210,
                    y);


            pnlDetails.Controls.Add(title);
            pnlDetails.Controls.Add(value);
        }



        private Label CreateTitle(
            string text)
        {
            return new Label
            {
                Text = text,
                Size =
                    new Size(
                        170,
                        35),
                Font =
                    new Font(
                        "Segoe UI",
                        10,
                        FontStyle.Bold),
                ForeColor =
                    Theme.TextPrimary
            };
        }



        private Label CreateValue(
            string text)
        {
            return new Label
            {
                Text = text,
                Size =
                    new Size(
                        200,
                        35),
                BorderStyle =
                    BorderStyle.FixedSingle,
                BackColor =
                    Color.White,
                TextAlign =
                    ContentAlignment.MiddleLeft
            };
        }

    }
}