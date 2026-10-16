using DVLD.Controls;
using DVLD.Presentation.UI;
using System;
using System.Data;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BusinessLayer.Models;
using System.ComponentModel;

namespace DVLD.Forms
{
    public partial class frmAddInternationalLicense : BaseForm
    {
        private Label lblTitle;

        private Panel pnlLicenseSearch;
        private Panel pnlInternationalInfo;
        private Panel pnlStep1;
        int LicenseID;
        int DriverID;
        private Label lblFeesTitle;
        private Label lblFeesValue;

        private Label lblDriverIDTitle;
        private Label lblDriverIDValue;

        private Label lblLocalLicenseIDTitle;
        private Label lblLocalLicenseIDValue;

        private Label lblIssueDateTitle;
        private Label lblIssueDateValue;

        private Label lblExpirationDateTitle;
        private Label lblExpirationDateValue;

        private Label lblInternationalLicenseIDTitle;
        private Label lblInternationalLicenseIDValue;

  
        private RoundedButton btnIssue;

        private InfoSelectorControl licenseSelector;

        private LicenseInfoCard licenseInfoCard;

        private DataGridView dgv;

        private RoundedButton btnCancel;
        private RoundedButton btnNext;
        private RoundedButton btnBack;
     

        public int? SelectedLicenseID
        {
            get
            {
                return licenseSelector.SelectedId;
            }
        }


        public frmAddInternationalLicense()
        {
            InitializeForm();
            InitializeUI();
            InitializeButtons();
            InitializeLicenseSearch();
            LoadLicenses();
            InitializeInternationalPanel();




        }


        private void InitializeForm()
        {
            Text = "Add International License";

            StartPosition =
                FormStartPosition.CenterScreen;

            ClientSize =
                new Size(1500, 850);

            MinimumSize =
                new Size(1400, 800);

            BackColor =
                Theme.AppBackground;

            DoubleBuffered = true;
        }

        private void InitializeUI()
        {
            lblTitle = new Label();

            lblTitle.Text =
                "🌍  Add International License";

            lblTitle.Font =
                new Font(
                    "Segoe UI",
                    22,
                    FontStyle.Bold);

            lblTitle.ForeColor =
                Theme.TextPrimary;

            lblTitle.AutoSize = false;

            lblTitle.TextAlign =
                ContentAlignment.MiddleCenter;

            lblTitle.Dock =
                DockStyle.Top;

            lblTitle.Height = 70;

            Controls.Add(lblTitle);



            pnlStep1 = new Panel();

            pnlStep1.Location =
                new Point(20, 90);

            pnlStep1.Size =
                new Size(
                    ClientSize.Width - 40,
                    650);

            pnlStep1.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;

            pnlStep1.BackColor =
                Color.Transparent;

            Controls.Add(pnlStep1);



            pnlLicenseSearch = new Panel();

            pnlLicenseSearch.Location =
                new Point(0, 0);

            pnlLicenseSearch.Size =
                new Size(500, 650);

            pnlLicenseSearch.BackColor =
                Theme.CardBackground;

            pnlLicenseSearch.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left;

            pnlStep1.Controls.Add(
                pnlLicenseSearch);



            pnlInternationalInfo = new Panel();

            pnlInternationalInfo.Location =
                new Point(20, 90);

            pnlInternationalInfo.Size =
                new Size(
                    ClientSize.Width - 40,
                    650);

            pnlInternationalInfo.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;

            pnlInternationalInfo.BackColor =
                Theme.CardBackground;

            pnlInternationalInfo.Visible = false;

            Controls.Add(
                pnlInternationalInfo);
        }

        private void InitializeLicenseSearch()
        {
            licenseSelector =
                new InfoSelectorControl();

            licenseSelector.Location =
                new Point(10, 10);

            licenseSelector.Size =
                new Size(
                    pnlLicenseSearch.Width - 20,
                    pnlLicenseSearch.Height - 20);

            licenseSelector.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;



            licenseInfoCard =
                new LicenseInfoCard();

            licenseInfoCard.Location =
                new Point(
                    pnlLicenseSearch.Right + 20,
                    0);

            licenseInfoCard.Size =
                new Size(
                    pnlStep1.Width -
                    pnlLicenseSearch.Width -
                    20,
                    pnlStep1.Height);

            licenseInfoCard.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;



            licenseSelector.InfoColumnName =
                "LicenseID";

            licenseSelector.SearchColumns =
                new Dictionary<string, string>
                {
            { "License ID", "LicenseID" },
            { "Driver ID", "DriverID" }
                };



            licenseSelector.LoadSelectedItem =
                id =>
                {
                    licenseInfoCard.LoadLicense(id);
                };



            pnlLicenseSearch.Controls.Add(
                licenseSelector);

            pnlStep1.Controls.Add(
                licenseInfoCard);



            dgv = licenseSelector.dgv;

            dgv.Size =
                new Size(
                    Width - 800,
                    Height - 150);

            dgv.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.None;

            dgv.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.None;

            dgv.ScrollBars =
                ScrollBars.Both;
        }

        private void AddRow(
      Panel panel,
      Label title,
      Label value,
      int y,
      int titleX = 300,
      int valueX = 600)
        {
            title.Location =
                new Point(titleX, y);

            value.Location =
                new Point(valueX, y);

            pnlLicenseSearch.Controls.Add( licenseSelector);

            pnlStep1.Controls.Add(pnlLicenseSearch);
            pnlInternationalInfo.Controls.Add(title);
            pnlInternationalInfo.Controls.Add(value);
        }
        private Label CreateValueLabel(string text = "")
        {
            Label lbl = new Label();

            lbl.Text = text;

            lbl.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Regular);

            lbl.ForeColor =
                Theme.TextSecondary;

            lbl.AutoSize = false;

            lbl.BorderStyle =
                BorderStyle.FixedSingle;

            lbl.BackColor =
                Color.White;

            lbl.Size =
                new Size(
                    180,
                    30);

            lbl.TextAlign =
                ContentAlignment.MiddleLeft;

            return lbl;
        }
        private Label CreateTitleLabel(string text)
        {
            Label lbl = new Label();

            lbl.Text = text;

            lbl.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold);

            lbl.ForeColor =
                Theme.TextPrimary;

            lbl.AutoSize = false;

            lbl.Size =
     new Size(
         260,
         34);

            lbl.TextAlign =
                ContentAlignment.MiddleLeft;

            return lbl;
        }
        private void InitializeInternationalPanel()
        {



            Label lblHeader = new Label();

            lblHeader.Text = "International License Information";

            lblHeader.Font =
                new Font(
                    "Segoe UI",
                    18,
                    FontStyle.Bold);

            lblHeader.ForeColor =
                Theme.TextPrimary;

            lblHeader.AutoSize = false;

            lblHeader.Size =
                new Size(
                    pnlInternationalInfo.Width,
                    50);

            lblHeader.Location =
                new Point(0, 15);

            lblHeader.TextAlign =
                ContentAlignment.MiddleCenter;

            lblHeader.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            pnlInternationalInfo.Controls.Add(lblHeader);
            int y = 90;

            lblFeesTitle =
                CreateTitleLabel("💰 Application Fees");

            lblFeesValue =
                CreateValueLabel();

            AddRow(
                pnlInternationalInfo,
                lblFeesTitle,
                lblFeesValue,
                y);

            y += 45;


            lblDriverIDTitle =
                CreateTitleLabel("🆔 Driver ID");

            lblDriverIDValue =
                CreateValueLabel();

            AddRow(
                pnlInternationalInfo,
                lblDriverIDTitle,
                lblDriverIDValue,
                y);

            y += 45;


            lblLocalLicenseIDTitle =
                CreateTitleLabel("🪪 Local License ID");

            lblLocalLicenseIDValue =
                CreateValueLabel();

            AddRow(
                pnlInternationalInfo,
                lblLocalLicenseIDTitle,
                lblLocalLicenseIDValue,
                y);

            y += 45;


            lblIssueDateTitle =
                CreateTitleLabel("📅 Issue Date");

            lblIssueDateValue =
                CreateValueLabel();

            AddRow(
                pnlInternationalInfo,
                lblIssueDateTitle,
                lblIssueDateValue,
                y);

            y += 45;


            lblExpirationDateTitle =
                CreateTitleLabel("⏳ Expiration Date");

            lblExpirationDateValue =
                CreateValueLabel();

            AddRow(
                pnlInternationalInfo,
                lblExpirationDateTitle,
                lblExpirationDateValue,
                y);

            y += 45;


            lblInternationalLicenseIDTitle =
                CreateTitleLabel("🌍 International License ID");

            lblInternationalLicenseIDValue =
                CreateValueLabel("???");

            AddRow(
                pnlInternationalInfo,
                lblInternationalLicenseIDTitle,
                lblInternationalLicenseIDValue,
                y);

            btnCancel.Click += BtnCancel_Click;
        }

        private void InitializeButtons()
        {
            btnCancel =
                new RoundedButton();

            btnCancel.Text =
                "Cancel";

            btnCancel.Size =
                new Size(
                    130,
                    45);

            btnCancel.Location =
                new Point(
                    30,
                    ClientSize.Height - 65);

            btnCancel.Anchor =
                AnchorStyles.Bottom |
                AnchorStyles.Left;

            btnCancel.NormalColor =
                Color.FromArgb(
                    100,
                    100,
                    100);

            btnCancel.HoverColor =
                Color.FromArgb(
                    120,
                    120,
                    120);

            btnCancel.PressedColor =
                Color.FromArgb(
                    80,
                    80,
                    80);

            btnCancel.Click +=
                (s, e) =>
                {
                    Close();
                };

            Controls.Add(
                btnCancel);
        

        btnNext = new RoundedButton();

        btnNext.Text =
                "Next";

            btnNext.Size =
                new Size(
                    130,
                    45);

        btnNext.Location =
                new Point(
                    300,
                    ClientSize.Height - 65);

        btnNext.Anchor =
                AnchorStyles.Bottom |
                AnchorStyles.Left;

            btnNext.NormalColor =
                Color.FromArgb(
                    100,
                    100,
                    100);

            btnNext.HoverColor =
                Color.FromArgb(
                    120,
                    120,
                    120);

            btnNext.PressedColor =
                Color.FromArgb(
                    80,
                    80,
                    80);

            btnNext.Click += btnNext_Click;

            Controls.Add(
                btnNext);
                }

        
        public void LoadLicenses()
        {
            licenseSelector.LoadData(Licenses_View.GetAlldata());
        }



        public void btnNext_Click(object sender, EventArgs e)
        {
            
            if (btnNext.Text == "Next")
            {
                if (dgv.CurrentRow == null)
                {
                    CustomMessageBox.Show("Failed!", "Please, select a license");
                    return;
                }

                 LicenseID = Convert.ToInt32(dgv.CurrentRow.Cells[0].Value);
                  DriverID= Convert.ToInt32(dgv.CurrentRow.Cells["DriverID"].Value);

                if (Licenses.IsActive(LicenseID))
                {
                    if (InternationalLicenses.HasAnActiveLicense(DriverID)) { CustomMessageBox.Show("Faild!", "This driver already has an active International license"); return; }
                   
                    if (Licenses.GetLicenseClass(LicenseID) != 3)
                    {
                        CustomMessageBox.Show(
                            "Failed!",
                            "An international license can only be issued to drivers who have an ordinary driving license");

                        return;
                    }
                }

                Licenses_View license =
                    Licenses_View.GetLicense(LicenseID);

                lblFeesValue.Text =
                    ApplicationTypes
                    .GetFees((int)enApplicationType.NewInternationalLicense)
                    .ToString("0.00");

                lblDriverIDValue.Text =
                    license.DriverID.ToString();

                lblLocalLicenseIDValue.Text =
                    license.LicenseID.ToString();

                lblIssueDateValue.Text =
                    DateTime.Now.ToShortDateString();

                lblExpirationDateValue.Text =
                    DateTime.Now
                    .AddYears(1)
                    .ToShortDateString();

                lblInternationalLicenseIDValue.Text =
                    "???";

                pnlStep1.Visible = false;
                pnlInternationalInfo.Visible = true;

                btnNext.Text = "Save";
                btnCancel.Text = "Back";
            }
            else
            {
                if (InternationalLicenses.HasAnActiveLicense(DriverID)) { CustomMessageBox.Show("Faild!", "This driver already has an active International license"); return; }
                int inter = InternationalLicenses.Insertion(LicenseID);
                lblInternationalLicenseIDValue.Text= inter.ToString();
                frmInternationalLicenseInfo frm = new frmInternationalLicenseInfo(inter);
                frm.ShowDialog();

                return;
            }
        }




        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.Text == "Cancel")
            {
                Close();
                return;
            }

            pnlInternationalInfo.Visible = false;
            pnlStep1.Visible = true;

            btnNext.Text = "Next";
            btnCancel.Text = "Cancel";
            return;
        }


    }
}