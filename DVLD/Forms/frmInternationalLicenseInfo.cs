using DVLD.Controls;
using DVLD.Presentation.UI;
using BusinessLayer.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Forms
{
    public class frmInternationalLicenseInfo : BaseForm
    {
        private Label lblTitle;

        private Panel pnlCard;

        private InternationalLicenseInfoCard internationalLicenseCard;



        private int _internationalLicenseID;



        public frmInternationalLicenseInfo(
            int internationalLicenseID)
        {
            _internationalLicenseID =
                internationalLicenseID;


            InitializeForm();

            InitializeUI();

            LoadLicense();
        }




        private void InitializeForm()
        {
            Text =
                "International License";


            StartPosition =
                FormStartPosition.CenterScreen;


            ClientSize =
                new Size(
                    900,
                    450);


            MinimumSize =
                new Size(
                    850,
                    400);


            BackColor =
                Theme.AppBackground;
        }





        private void InitializeUI()
        {

            lblTitle =
                new Label();


            lblTitle.Text =
                "🌍 International License";


            lblTitle.Dock =
                DockStyle.Top;


            lblTitle.Height =
                70;


            lblTitle.Font =
                new Font(
                    "Segoe UI",
                    22,
                    FontStyle.Bold);


            lblTitle.ForeColor =
                Theme.TextPrimary;


            lblTitle.TextAlign =
                ContentAlignment.MiddleCenter;


            Controls.Add(
                lblTitle);




            pnlCard =
                new Panel();


            pnlCard.Location =
                new Point(
                    30,
                    90);


            pnlCard.Size =
                new Size(
                    840,
                    300);


            pnlCard.BackColor =
                Theme.CardBackground;


            pnlCard.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;


            Controls.Add(
                pnlCard);




            internationalLicenseCard =
                new InternationalLicenseInfoCard();


            internationalLicenseCard.Dock =
                DockStyle.Fill;


            pnlCard.Controls.Add(
                internationalLicenseCard);

        }





        private void LoadLicense()
        {

            InternationalLicenses_View license =InternationalLicenses_View.GetInternationalLicenseByID( _internationalLicenseID);



            if (license == null)
            {
                CustomMessageBox.Show(
                    "Error",
                    "License not found");

                Close();

                return;
            }



            internationalLicenseCard.LoadInternationalLicense( license);

        }
    }
}