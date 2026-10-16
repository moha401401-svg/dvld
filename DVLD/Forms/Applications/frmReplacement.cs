using BusinessLayer.Models;
using DVLD.Business;
using DVLD.Controls;
using DVLD.Presentation.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Forms
{
    public partial class frmReplacement : BaseForm
    {
        private Label lblTitle;

        private Panel pnlLicenseSearch;
        private Panel pnlInternationalInfo;
        private Panel pnlStep1;
        int LicenseID;
        private Label lblFeesTitle;
        private Label lblFeesValue;

        private Label lblDriverIDTitle;
        private Label lblDriverIDValue;

        private Label lblNotes;
        private RoundedTextBox txtNotesValue;

        private Label lblIssueDateTitle;
        private Label lblIssueDateValue;

        private Label lblExpirationDateTitle;
        private Label lblExpirationDateValue;

        private Label lblNewLicenseIDTitle;
        private Label lblNewLicenseIDValue;


        private RoundedButton btnIssue;

        private InfoSelectorControl licenseSelector;

        private LicenseInfoCard licenseInfoCard;

        private DataGridView dgv;

        private RoundedButton btnCancel;
        private RoundedButton btnNext;
        private RoundedButton btnBack;


        private RadioButton rbReplaceDamaged;
        private RadioButton rbReplaceLost;

        public int? SelectedLicenseID
        {
            get
            {
                return licenseSelector.SelectedId;
            }
        }


        public frmReplacement()
        {
            InitializeForm();
            InitializeUI();
            InitializeButtons();
            InitializeLicenseSearch();
            LoadLicenses();
            InitializeInternationalPanel();
            InitializeReplacementRadioButtons();




        }


        public enApplicationType ReplacementType
        {
            get
            {
                if (rbReplaceLost.Checked)
                    return enApplicationType.ReplaceLostLicense;


                return enApplicationType.ReplaceDamagedLicense;
            }
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
                "🌍  Add Replacement License";

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


        private void InitializeReplacementRadioButtons()
        {
            rbReplaceDamaged =
                new RadioButton();

            rbReplaceDamaged.Text =
                "🛠 Replace Damaged License";

            rbReplaceDamaged.AutoSize =
                true;

            rbReplaceDamaged.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold);

            rbReplaceDamaged.ForeColor =
                Theme.TextPrimary;

            rbReplaceDamaged.Location =
                new Point(
                    180,
                    450);


            rbReplaceLost =
                new RadioButton();

            rbReplaceLost.Text =
                "❌ Replace Lost License";

            rbReplaceLost.AutoSize =
                true;

            rbReplaceLost.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold);

            rbReplaceLost.ForeColor =
                Theme.TextPrimary;

            rbReplaceLost.Location =
                new Point(
                    600,
                    450);

            rbReplaceDamaged.Checked = true;
            lblFeesValue.Text =
                 ApplicationTypes
                 .GetFees((int)ReplacementType)
                 .ToString("0.00");

            pnlInternationalInfo.Controls.Add(rbReplaceDamaged);
            pnlInternationalInfo.Controls.Add(rbReplaceLost);

            rbReplaceDamaged.CheckedChanged +=
                ReplacementType_CheckedChanged;

            rbReplaceLost.CheckedChanged +=
                ReplacementType_CheckedChanged;
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

            pnlLicenseSearch.Controls.Add(licenseSelector);

            pnlStep1.Controls.Add(pnlLicenseSearch);
            pnlInternationalInfo.Controls.Add(title);
            pnlInternationalInfo.Controls.Add(value);
        }

        private void AddRow(
      Panel panel,
      Label title,
      RoundedTextBox value,
      int y,
      int titleX = 300,
      int valueX = 600)
        {
            title.Location =
                new Point(titleX, y);

            value.Location =
                new Point(valueX-10, y);

            pnlLicenseSearch.Controls.Add(licenseSelector);

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

            lbl.Size = new Size( 260, 34);

            lbl.TextAlign =
                ContentAlignment.MiddleLeft;

            return lbl;
        }

        public void ReplacementType_CheckedChanged(object sender, EventArgs e)
        {
           
            lblFeesValue.Text =
                   ApplicationTypes
                   .GetFees((int)ReplacementType)
                   .ToString("0.00");
        }
        private void InitializeInternationalPanel()
        {



            Label lblHeader = new Label();

            lblHeader.Text = "Replacement License Information";

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

            y += 40;


            lblNotes =
                CreateTitleLabel("🪪 Notes");

            txtNotesValue= new RoundedTextBox();
            txtNotesValue.Placeholder = "Note...";

            AddRow(
                pnlInternationalInfo,
                lblNotes,
                txtNotesValue,
                y);
       
            y += 50;
           

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


            lblNewLicenseIDTitle =
                CreateTitleLabel("🌍 New License ID");

            lblNewLicenseIDValue =
                CreateValueLabel("???");

            AddRow(
                pnlInternationalInfo,
                lblNewLicenseIDTitle,
                lblNewLicenseIDValue,
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

                if (!Licenses.IsActive(LicenseID))
                {
                    CustomMessageBox.Show("Failed!", "This license is inactive ");
                    return;
                }


                    Licenses_View license =
                    Licenses_View.GetLicense(LicenseID);

               

                lblDriverIDValue.Text =
                    license.DriverID.ToString();

               

                lblIssueDateValue.Text =
                    DateTime.Now.ToShortDateString();

                
                 

                lblNewLicenseIDValue.Text =
                    "???";

                pnlStep1.Visible = false;
                pnlInternationalInfo.Visible = true;

                btnNext.Text = "Save";
                btnCancel.Text = "Back";
            }
            else
            {
                int clsID = Licenses.GetLicenseClass(LicenseID);
                lblExpirationDateValue.Text = DateTime.Now.AddYears(LicenseClasses.GetValidityLength(clsID)).ToString();
                int personID= Licenses.GetPersonID(LicenseID);
                int OldLicenseID= Convert.ToInt32(dgv.CurrentRow.Cells[0].Value);
                int LDLID = LDLApplications.Add(clsID, personID,ReplacementType);
                
                int NewLicenseID = Licenses.Insertion(LDLID, txtNotesValue.Text, ReplacementType==enApplicationType.ReplaceLostLicense? Licenses.enIssueReason.Lost: Licenses.enIssueReason.Damaged, OldLicenseID);
                if (NewLicenseID == 0) { CustomMessageBox.Show("Faild!", $"Error In Database"); return; }
                CustomMessageBox.Show("Done!", $"Replacement done successfully with ID:{NewLicenseID}");
                lblNewLicenseIDValue.Text=NewLicenseID.ToString();
                Close();
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
            pnlLicenseSearch.Visible = true;

            btnNext.Text = "Next";
            btnCancel.Text = "Cancel";
            return;
        }


    }
}