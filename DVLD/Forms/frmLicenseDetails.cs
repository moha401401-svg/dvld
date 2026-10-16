using DVLD.Controls;
using DVLD.Presentation.UI;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Forms
{
    public partial class frmLicenseDetails : BaseForm
    {
        private LicenseInfoCard licenseInfoCard;
        int licenseID;

        public frmLicenseDetails(int licenseID)
        {
            InitializeForm();
            InitializeLicenseCard();
            this.licenseID = licenseID;
            LoadLicense(licenseID);
        }

        private void InitializeForm()
        {
            Text =
                "License Details";

            StartPosition =
                FormStartPosition.CenterScreen;

            ClientSize =
                new Size(
                    1100,
                    420);

            MinimumSize =
                new Size(
                    1000,
                    400);

            BackColor =
                Theme.AppBackground;
        }

        private void InitializeLicenseCard()
        {
            licenseInfoCard =
                new LicenseInfoCard();

            licenseInfoCard.Location =
                new Point(
                    30,
                    30);

            licenseInfoCard.Size =
                new Size(
                    ClientSize.Width - 60,
                    330);

            licenseInfoCard.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            Controls.Add(
                licenseInfoCard);
        }

        public void LoadLicense(int licenseID)
        {
            licenseInfoCard.LoadLicense(licenseID);
        }
    }
}