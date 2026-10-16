using BusinessLayer;
using BusinessLayer.Models;
using DVLD.Controls;
using DVLD.Presentation.UI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Forms
{
    public partial class frmReleaseLicense : BaseForm
    {
        private Label lblTitle;

        private Panel pnlLicenseCard;
        private Panel pnlDetails;

        private LicenseInfoCard licenseCard;

        private Label lblDateTitle;
        private Label lblDateValue;

        private Label lblFineTitle;
        private Label lblFineValue;

        private RoundedButton btnRelease;
        private RoundedButton btnCancel;

        private int _detainID;
        private int _licenseID;

     


        public frmReleaseLicense(int detainID)
        {
            _detainID = detainID;

            InitializeForm();
            InitializeUI();
            LoadData();
        }



        private void InitializeForm()
        {
            Text =
                "Release License";

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
                "✅ Release Detained License";

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
                    "📅 Release Date");

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
                    "💰 Detain Fine");

            lblFineValue =
                CreateValue("");

            AddRow(
                lblFineTitle,
                lblFineValue,
                65);






            btnRelease =
                new RoundedButton();

            btnRelease.Text =
                "Release";

            btnRelease.Size =
                new Size(
                    120,
                    40);

            btnRelease.Location =
                new Point(
                    600,
                    600);

            btnRelease.Click +=
                BtnRelease_Click;

            Controls.Add(
                btnRelease);






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
                (s, e) => Close();

            Controls.Add(
                btnCancel);
        }

        private void LoadData()
        {
           


            _licenseID = DetainedLicenses.GetLicenseID(_detainID);
               

            licenseCard.LoadLicense(
                _licenseID);

            lblDateValue.Text =
                DateTime.Now.ToShortDateString();

            lblFineValue.Text =DetainedLicenses.GetFineFees(_detainID).ToString("0.00");
        }



        private void BtnRelease_Click(
            object sender,
            EventArgs e)
        {
          
              

        

            bool released =
                DetainedLicenses.ReleaseLicense( _detainID);

            if (!released)
            {
                CustomMessageBox.Show(
                    "Failed!",
                    "License release failed.");

                return;
            }

            CustomMessageBox.Show(
                "Done!",
                "License released successfully.");

            Close();
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

            pnlDetails.Controls.Add(
                title);

            pnlDetails.Controls.Add(
                value);
        }




        private Label CreateTitle(
            string text)
        {
            Label lbl =
                new Label();

            lbl.Text =
                text;

            lbl.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold);

            lbl.ForeColor =
                Theme.TextPrimary;

            lbl.AutoSize =
                false;

            lbl.Size =
                new Size(
                    170,
                    35);

            lbl.TextAlign =
                ContentAlignment.MiddleLeft;

            return lbl;
        }




        private Label CreateValue(
            string text)
        {
            Label lbl =
                new Label();

            lbl.Text =
                text;

            lbl.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Regular);

            lbl.ForeColor =
                Theme.TextSecondary;

            lbl.AutoSize =
                false;

            lbl.BorderStyle =
                BorderStyle.FixedSingle;

            lbl.BackColor =
                Color.White;

            lbl.Size =
                new Size(
                    200,
                    35);

            lbl.TextAlign =
                ContentAlignment.MiddleLeft;

            return lbl;
        }
    }
}