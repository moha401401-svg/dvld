using BusinessLayer.Models;
using DVLD.Business.Models;
using DVLD.Controls;
using DVLD.Presentation.UI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Forms
{
    public partial class frmDriverDetails : BaseForm
    {
        private Label lblTitle;

        private Panel pnlPersonInfo;
        private Panel pnlLicenses;

        private Panel pnlLicenseMenu;
        private Panel pnlLocal;
        private Panel pnlInternational;
        private bool Local = true;
        private RoundedButton btnLocal;
        private RoundedButton btnInternational;
        private RoundedButton btnClose;
        private RoundedButton btnShowLicenseDetails;

        public DataGridView dgvLocal;
        public DataGridView dgvInternational;

        private PersonInfoCard personInfoCard;

        public int DriverID
        {
            get;
            private set;
        }
        public int PersonID { get; private set; }
       

        public frmDriverDetails(int driverID,int personID)
        {
            DriverID = driverID;
            PersonID = personID;
            InitializeForm();
            InitializeUI();
            InitializePersonInfo();
            InitializeLicenseSection();
            InitializeButtons();

            ShowLocalLicenses();
        }

        private void InitializeForm()
        {
            Text =
                "Driver Details";

            StartPosition =
                FormStartPosition.CenterScreen;

            WindowState =
                FormWindowState.Normal;

            ClientSize =
      new Size(
          1000,
          1000);

            MinimumSize =
                new Size(
                    950,
                    900);

            BackColor =
                Theme.AppBackground;
        }

        private void InitializeUI()
        {
            lblTitle =
                new Label();

            lblTitle.Text =
                "Driver Details";

            lblTitle.Font =
                new Font(
                    "Segoe UI",
                    22,
                    FontStyle.Bold);

            lblTitle.ForeColor =
                Theme.TextPrimary;

            lblTitle.TextAlign =
                ContentAlignment.MiddleCenter;

            lblTitle.Dock =
                DockStyle.Top;

            lblTitle.Height =
                70;

            Controls.Add(
                lblTitle);


            pnlPersonInfo =
       new Panel();

            pnlPersonInfo.Location =
                new Point(
                    40,
                    90);

            pnlPersonInfo.Size =
           new Size(
               ClientSize.Width - 80,
               530);

            pnlPersonInfo.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            pnlPersonInfo.BackColor =
                Theme.CardBackground;

            Controls.Add(
                pnlPersonInfo);


            pnlLicenses =new Panel();
            pnlLicenses.Location =
      new Point(   40, 625);

            pnlLicenses.Size =
                new Size(
                    ClientSize.Width - 80,
                    ClientSize.Height - 680);

            pnlLicenses.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;

            pnlLicenses.BackColor =
                Theme.CardBackground;

            Controls.Add(
                pnlLicenses);
        }

        private void InitializePersonInfo()
        {
            personInfoCard =
                new PersonInfoCard();

            personInfoCard.Dock =
                DockStyle.Fill;
            personInfoCard.Margin =new Padding(0);

            pnlPersonInfo.Controls.Add(
                personInfoCard);
            People person = People.GetPerson(PersonID);
            personInfoCard.LoadPerson(person);

           
        }

        private void InitializeLicenseSection()
        {
            pnlLicenseMenu =
                new Panel();

            pnlLicenseMenu.Dock =
                DockStyle.Top;

            pnlLicenseMenu.Height =
                65;

            pnlLicenseMenu.BackColor =
                Theme.CardBackground;

            pnlLicenses.Controls.Add(
                pnlLicenseMenu);


            btnLocal =
                CreateMenuButton(
                    "Local Licenses");

            btnLocal.Location =
                new Point(
                    20,
                    10);

            pnlLicenseMenu.Controls.Add(
                btnLocal);


            btnInternational =
                CreateMenuButton(
                    "International Licenses");

            btnInternational.Location =
                new Point(
                    190,
                    10);

            pnlLicenseMenu.Controls.Add(
                btnInternational);


            pnlLocal =
                new Panel();

            pnlLocal.Location =
                new Point(
                    20,
                    75);

            pnlLocal.Size =
                new Size(
                    pnlLicenses.Width - 40,
                    pnlLicenses.Height - 95);

            pnlLocal.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;

            pnlLocal.BackColor =
                Theme.AppBackground;

            pnlLicenses.Controls.Add(
                pnlLocal);


            dgvLocal =
                new DataGridView();

            dgvLocal.Dock =
                DockStyle.Fill;

            dgvLocal.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvLocal.AllowUserToAddRows =
                false;

            dgvLocal.ReadOnly =
                true;

            dgvLocal.DataSource = Licenses_View.GetAll(DriverID);

            pnlLocal.Controls.Add(
                dgvLocal);


            pnlInternational =
                new Panel();

            pnlInternational.Location =
                pnlLocal.Location;

            pnlInternational.Size =
                pnlLocal.Size;

            pnlInternational.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;

            pnlInternational.BackColor =
                Theme.AppBackground;

            pnlInternational.Visible =
                false;

            pnlLicenses.Controls.Add(
                pnlInternational);


            dgvInternational =
                new DataGridView();

            dgvInternational.Dock =
                DockStyle.Fill;

            dgvInternational.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvInternational.AllowUserToAddRows =
                false;

            dgvInternational.ReadOnly =
                true;

            dgvInternational.DataSource = InternationalLicenses_View.GetInternationalLicensesByDriverID(DriverID);

            pnlInternational.Controls.Add(
                dgvInternational);


            btnLocal.Click +=
                (s, e) =>
                {
                    ShowLocalLicenses();
                };


            btnInternational.Click +=
                (s, e) =>
                {
                    ShowInternationalLicenses();
                };
        }

        private RoundedButton CreateMenuButton(
            string text)
        {
            RoundedButton button =
                new RoundedButton();

            button.Text =
                text;

            button.Size =
                new Size(
                    150,
                    45);

            button.NormalColor =
                Color.CornflowerBlue;

            button.HoverColor =
                Color.FromArgb(
                    80,
                    140,
                    220);

            button.PressedColor =
                Color.FromArgb(
                    60,
                    110,
                    190);

            return button;
        }

        private void ShowLocalLicenses()
        {
            Local = true;
            pnlLocal.Visible =
                true;

            pnlInternational.Visible =
                false;
        }

        private void ShowInternationalLicenses()
        {
            Local = false;
            pnlLocal.Visible =
                false;

            pnlInternational.Visible =
                true;
        }

        private void InitializeButtons()
        {
            btnClose =
                new RoundedButton();

            btnClose.Text =
                "Close";

            btnClose.Size =
                new Size(
                    130,
                    45);

            btnClose.Location =
                new Point(
                    40,
                    ClientSize.Height - 50);

            btnClose.Anchor =
                AnchorStyles.Bottom |
                AnchorStyles.Left;

            btnClose.NormalColor =
                Color.FromArgb(
                    100,
                    100,
                    100);

            btnClose.HoverColor =
                Color.FromArgb(
                    120,
                    120,
                    120);

            btnClose.PressedColor =
                Color.FromArgb(
                    80,
                    80,
                    80);

            btnClose.Click +=
                (s, e) =>
                {
                    Close();
                };

            Controls.Add(
                btnClose);



            btnShowLicenseDetails =
    new RoundedButton();

            btnShowLicenseDetails.Text =
                "Show License Details";

            btnShowLicenseDetails.Size =
                new Size(
                    190,
                    45);

            btnShowLicenseDetails.Location =
                new Point(
                    185,
                    ClientSize.Height - 50);

            btnShowLicenseDetails.Anchor =
                AnchorStyles.Bottom |
                AnchorStyles.Left;

            btnShowLicenseDetails.NormalColor =
                Color.CornflowerBlue;

            btnShowLicenseDetails.HoverColor =
                Color.FromArgb(
                    80,
                    140,
                    220);

            btnShowLicenseDetails.PressedColor =
                Color.FromArgb(
                    60,
                    110,
                    190);

            btnShowLicenseDetails.Click +=
                BtnShowLicenseDetails_Click;

            Controls.Add(
                btnShowLicenseDetails);
        }

        private void BtnShowLicenseDetails_Click(object sender,EventArgs e)
        {
            if (Local)
            {

                int licenseID = Convert.ToInt32(dgvLocal.CurrentRow.Cells[0].Value);
                frmLicenseDetails frmlocal =
                    new frmLicenseDetails(licenseID);

                frmlocal.ShowDialog();
                return;
            }

            int InternationalLicenseID = Convert.ToInt32(dgvInternational.CurrentRow.Cells[0].Value);
            frmInternationalLicenseInfo frminter =
                new frmInternationalLicenseInfo(InternationalLicenseID);

            frminter.ShowDialog();
            return;

        }
    }
}