
using BusinessLayer.Models;
using DVLD.Business.Models;
using DVLD.Controls;
using DVLD.Presentation.UI;
using DVLD.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Controls
{
    public class LicenseInfoCard : UserControl
    {
        private Label lblHeader;

        private Label lblLicenseClassTitle;
        private Label lblLicenseClassValue;

        private Label lblDriverNameTitle;
        private Label lblDriverNameValue;

        private Label lblLicenseIDTitle;
        private Label lblLicenseIDValue;

        private Label lblNationalNumberTitle;
        private Label lblNationalNumberValue;

        private Label lblGenderTitle;
        private Label lblGenderValue;

        private Label lblIssueDateTitle;
        private Label lblIssueDateValue;

        private Label lblIssueReasonTitle;
        private Label lblIssueReasonValue;

        private Label lblNotesTitle;
        private Label lblNotesValue;

        private Label lblIsActiveTitle;
        private Label lblIsActiveValue;

        private Label lblDateOfBirthTitle;
        private Label lblDateOfBirthValue;

        private Label lblDriverIDTitle;
        private Label lblDriverIDValue;

        private Label lblExpirationDateTitle;
        private Label lblExpirationDateValue;

        private Label lblIsDetainedTitle;
        private Label lblIsDetainedValue;

        private PictureBox picDriver;
        

        private string licenseClass = "";
        private string driverName = "";
        private string licenseID = "";
        private string nationalNumber = "";
        private string gender = "";
        private string issueDate = "";
        private string issueReason = "";
        private string notes = "";
        private string isActive = "";
        private string dateOfBirth = "";
        private string driverID = "";
        private string expirationDate = "";
        private bool isDetained;


        public string LicenseClass
        {
            get => licenseClass;

            set
            {
                licenseClass = value;
                UpdateUI();
            }
        }


        public string DriverName
        {
            get => driverName;

            set
            {
                driverName = value;
                UpdateUI();
            }
        }


        public string LicenseID
        {
            get => licenseID;

            set
            {
                licenseID = value;
                UpdateUI();
            }
        }


        public string NationalNumber
        {
            get => nationalNumber;

            set
            {
                nationalNumber = value;
                UpdateUI();
            }
        }


        public string Gender
        {
            get => gender;

            set
            {
                gender = value;
                UpdateUI();
            }
        }


        public string IssueDate
        {
            get => issueDate;

            set
            {
                issueDate = value;
                UpdateUI();
            }
        }


        public string IssueReason
        {
            get => issueReason;

            set
            {
                issueReason = value;
                UpdateUI();
            }
        }


        public string Notes
        {
            get => notes;

            set
            {
                notes = value;
                UpdateUI();
            }
        }


        public string IsActive
        {
            get => isActive;

            set
            {
                isActive = value;
                UpdateUI();
            }
        }


        public string DateOfBirth
        {
            get => dateOfBirth;

            set
            {
                dateOfBirth = value;
                UpdateUI();
            }
        }


        public string DriverID
        {
            get => driverID;

            set
            {
                driverID = value;
                UpdateUI();
            }
        }


        public string ExpirationDate
        {
            get => expirationDate;

            set
            {
                expirationDate = value;
                UpdateUI();
            }
        }


        public bool IsDetained
        {
            get => isDetained;

            set
            {
                isDetained = value;
                UpdateUI();
            }
        }


        public Image DriverImage
        {
            get
            {
                return picDriver?.Image;
            }

            set
            {
                if (picDriver != null)
                    picDriver.Image = value;
            }
        }


        public LicenseInfoCard()
        {
            InitializeControl();
            InitializeUI();
            UpdateUI();
        }


        private void InitializeControl()
        {
            Size =
                new Size(
                    1050,
                    350);

            BackColor =
                Theme.CardBackground;

            Padding =
                new Padding(20);

            DoubleBuffered =
                true;

            DriverImage= Resources.male;
        }


        public void LoadLicense(int licenseID)
        {
            Licenses_View licenseViewData =
                Licenses_View.GetLicense(licenseID);

            if (licenseViewData == null)
                return;


            int personID =
                Licenses_View.GetPersonIDByLicenseID(
                    licenseID);


            People person =
                People.GetPerson(
                    personID);

            if (person == null)
                return;


            LicenseClass =
                licenseViewData.ClassName;

            DriverName =
                $"{person.FirstName} {person.SecondName} {person.ThirdName} {person.LastName}";

            LicenseID =
                licenseViewData.LicenseID.ToString();

            NationalNumber =
                person.NationalNo;

            Gender =
                person.Gender == 0
                ? "Male"
                : "Female";

            IssueDate =
                licenseViewData.IssueDate
                .ToString("dd/MM/yyyy");

            IssueReason =
                licenseViewData.IssueReason ?? "None";

            Notes =
                licenseViewData.Notes ?? "None";

            IsActive =
                licenseViewData.IsActive
                ? "Yes"
                : "No";

            DateOfBirth =
                person.DateOfBirth
                .ToString("dd/MM/yyyy");

            DriverID =
                licenseViewData.DriverID.ToString();

            ExpirationDate =
                licenseViewData.ExpirationDate
                .ToString("dd/MM/yyyy");

            IsDetained = DetainedLicenses.IsLicenseDetained(licenseID);
              


            if (!string.IsNullOrWhiteSpace(
                person.ImagePath))
            {
                try
                {
                    DriverImage =
                        Image.FromFile(
                            person.ImagePath);
                }
                catch
                {
                    DriverImage = person.Gender == 1 ? Resources.female : Resources.male;
                }
            }
            else
            {
                DriverImage = person.Gender==1?Resources.female:Resources.male;
                
            }
        }


        private void InitializeUI()
        {
            lblHeader =
                CreateHeaderLabel(
                    "🪪  License Information");

            lblHeader.Location =
                new Point(
                    20,
                    15);

            lblHeader.Size =
                new Size(
                    Width - 40,
                    35);

            Controls.Add(
                lblHeader);


         

            lblLicenseClassTitle =
                CreateTitleLabel(
                    "🚗  License Class");

            lblLicenseClassValue =
                CreateValueLabel();

            AddRow(
                lblLicenseClassTitle,
                lblLicenseClassValue,
                65,
                20);


            lblDriverNameTitle =
                CreateTitleLabel(
                    "👤  Driver Name");

            lblDriverNameValue =
                CreateValueLabel();

            AddRow(
                lblDriverNameTitle,
                lblDriverNameValue,
                105,
                20);


            lblLicenseIDTitle =
                CreateTitleLabel(
                    "🪪  License ID");

            lblLicenseIDValue =
                CreateValueLabel();

            AddRow(
                lblLicenseIDTitle,
                lblLicenseIDValue,
                145,
                20);


            lblNationalNumberTitle =
                CreateTitleLabel(
                    "🆔  National No.");

            lblNationalNumberValue =
                CreateValueLabel();

            AddRow(
                lblNationalNumberTitle,
                lblNationalNumberValue,
                185,
                20);


            lblGenderTitle =
                CreateTitleLabel(
                    "⚧  Gender");

            lblGenderValue =
                CreateValueLabel();

            AddRow(
                lblGenderTitle,
                lblGenderValue,
                225,
                20);


            lblIssueDateTitle =
                CreateTitleLabel(
                    "📅  Issue Date");

            lblIssueDateValue =
                CreateValueLabel();

            AddRow(
                lblIssueDateTitle,
                lblIssueDateValue,
                265,
                20);


         

            int secondColumnX =
                410;


            lblIssueReasonTitle =
                CreateTitleLabel(
                    "📋  Issue Reason");

            lblIssueReasonValue =
                CreateValueLabel();

            AddRow(
                lblIssueReasonTitle,
                lblIssueReasonValue,
                65,
                secondColumnX);


            lblNotesTitle =
                CreateTitleLabel(
                    "📝  Notes");

            lblNotesValue =
                CreateValueLabel();

            lblNotesValue.Width =
                230;

            AddRow(
                lblNotesTitle,
                lblNotesValue,
                105,
                secondColumnX);


            lblIsActiveTitle =
                CreateTitleLabel(
                    "🟢  Is Active");

            lblIsActiveValue =
                CreateValueLabel();

            AddRow(
                lblIsActiveTitle,
                lblIsActiveValue,
                145,
                secondColumnX);


            lblDateOfBirthTitle =
                CreateTitleLabel(
                    "🎂  Date Of Birth");

            lblDateOfBirthValue =
                CreateValueLabel();

            AddRow(
                lblDateOfBirthTitle,
                lblDateOfBirthValue,
                185,
                secondColumnX);


            lblDriverIDTitle =
                CreateTitleLabel(
                    "👨‍✈️  Driver ID");

            lblDriverIDValue =
                CreateValueLabel();

            AddRow(
                lblDriverIDTitle,
                lblDriverIDValue,
                225,
                secondColumnX);


            lblExpirationDateTitle =
                CreateTitleLabel(
                    "⏳  Expiration Date");

            lblExpirationDateValue =
                CreateValueLabel();

            AddRow(
                lblExpirationDateTitle,
                lblExpirationDateValue,
                265,
                secondColumnX);


            lblIsDetainedTitle =
                CreateTitleLabel(
                    "🔒  Is Detained");

            lblIsDetainedValue =
                CreateValueLabel();

            AddRow(
                lblIsDetainedTitle,
                lblIsDetainedValue,
                305,
                secondColumnX);



            picDriver =
                new PictureBox();

            picDriver.Size =
                new Size(
                    190,
                    230);

            picDriver.Location =
                new Point(
                    Width - 215,
                    65);

            picDriver.SizeMode =
                PictureBoxSizeMode.Zoom;

            picDriver.BackColor =
                Color.Transparent;

            Controls.Add(
                picDriver);
        }


        private Label CreateHeaderLabel(
            string text)
        {
            Label label =
                new Label();

            label.Text =
                text;

            label.Font =
                new Font(
                    "Segoe UI",
                    16,
                    FontStyle.Bold);

            label.ForeColor =
                Theme.TextPrimary;

            label.TextAlign =
                ContentAlignment.MiddleCenter;

            return label;
        }


        private Label CreateTitleLabel(
            string text)
        {
            Label label =
                new Label();

            label.Text =
                text;

            label.Font =
                new Font(
                    "Segoe UI",
                    9,
                    FontStyle.Bold);

            label.ForeColor =
                Theme.TextPrimary;

            label.AutoSize =
                false;

            label.Size =
                new Size(
                    110,
                    28);

            label.TextAlign =
                ContentAlignment.MiddleLeft;

            return label;
        }


        private Label CreateValueLabel()
        {
            Label label =
                new Label();

            label.Font =
                new Font(
                    "Segoe UI",
                    9);

            label.ForeColor =
                Theme.TextSecondary;

            label.AutoSize =
                false;

            label.Size =
                new Size(
                    150,
                    28);

            label.TextAlign =
                ContentAlignment.MiddleLeft;

            return label;
        }


        private void AddRow(
            Label title,
            Label value,
            int y,
            int titleX)
        {
            title.Location =
                new Point(
                    titleX,
                    y);

            value.Location =
                new Point(
                    titleX + 110,
                    y);

            Controls.Add(
                title);

            Controls.Add(
                value);
        }


        private void UpdateUI()
        {
            if (lblLicenseClassValue == null)
                return;


            lblLicenseClassValue.Text =
                LicenseClass;

            lblDriverNameValue.Text =
                DriverName;

            lblLicenseIDValue.Text =
                LicenseID;

            lblNationalNumberValue.Text =
                NationalNumber;

            lblGenderValue.Text =
                Gender;

            lblIssueDateValue.Text =
                IssueDate;

            lblIssueReasonValue.Text =
                IssueReason;

            lblNotesValue.Text =
                Notes;

            lblIsActiveValue.Text =
                IsActive;

            lblDateOfBirthValue.Text =
                DateOfBirth;

            lblDriverIDValue.Text =
                DriverID;

            lblExpirationDateValue.Text =
                ExpirationDate;

            lblIsDetainedValue.Text =
                IsDetained
                ? "Yes"
                : "No";
        }


        protected override void OnResize(
            EventArgs e)
        {
            base.OnResize(e);


            if (lblHeader != null)
            {
                lblHeader.Width =
                    Width - 40;
            }


            if (picDriver != null)
            {
                picDriver.Left =
                    Width - 215;
            }
        }
    }
}

