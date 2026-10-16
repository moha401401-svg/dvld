using BCrypt.Net;
using BusinessLayer;
using BusinessLayer.Models;
using DVLD.Controls;
using DVLD.Forms.Applications;
using DVLD.Forms.Types;
using DVLD.Presentation.UI;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace DVLD.Forms
{
    public partial class frmApplications : BaseForm
    {

        AccountBanner account;
        private Label lblWelcome;
        private Label lblTitle;
       
        private MenuBanner ManageApplicants;
        private MenuBanner ApplicationsTypes;
        private MenuBanner LocalLicenses;
        private MenuBanner Replacement;
        private MenuBanner DetainedLicenses;
        private MenuBanner InternationalLicenses;

        private MenuBanner TestTypes;
        private FlowLayoutPanel bannersPanel;

      


        public frmApplications()
        {

            InitializeComponent();

            InitializeForm();
            InitializeComponents();
        }


        private void InitializeForm()
        {
            WindowState = FormWindowState.Maximized;

            StartPosition = FormStartPosition.CenterScreen;
            CurrentUser.UserChanged += _Updated;


            BackColor =
                Theme.AppBackground;

            Load += frmApplications_Load;
        }


        private void InitializeComponents()
        {
            lblTitle = new Label();

            lblTitle.Text =
                "DVLD Management System";

            lblTitle.Font =
                Theme.HeaderFont;

            lblTitle.ForeColor =
                Theme.TextPrimary;

            lblTitle.AutoSize = true;

            lblTitle.Location =
                new Point(40, 60);


            Controls.Add(lblTitle);



            lblWelcome = new Label();

            lblWelcome.Text =
                "Welcome, " + CurrentUser.User.UserName;

            lblWelcome.Font =
                Theme.NormalFont;

            lblWelcome.ForeColor =
                Theme.TextSecondary;

            lblWelcome.AutoSize = true;

            lblWelcome.Location =
                new Point(45, 110);


            Controls.Add(lblWelcome);



            bannersPanel = new FlowLayoutPanel();

            bannersPanel.Location =
                new Point(40, 170);

            bannersPanel.Size =
                new Size(2000, 800);

            bannersPanel.BackColor =
                Theme.AppBackground;

            bannersPanel.AutoScroll = true;

            bannersPanel.FlowDirection =
                FlowDirection.LeftToRight;

            bannersPanel.WrapContents = true;


            Controls.Add(bannersPanel);


            CreateManageAccountBanner();

            CreateTestTypes();
            CreateApplicationsTypes();
            CreateLocalLicenses();
            CreateInternationalLicenses();
            CreateManageApplicants();
            CreateReplacementLicenses();
            CreateDetainedLicenses();




        }
        private void CreateLocalLicenses()
        {
            LocalLicenses = new MenuBanner();


            LocalLicenses.Title =
                "local Licenses";


            LocalLicenses.Description =
                "Apply for local licenses";


            LocalLicenses.Size =
                new Size(250, 180);


            LocalLicenses.Margin =
                new Padding(20);



            LocalLicenses.BannerClick +=
                LocalLicenses_BannerClick;



            bannersPanel.Controls.Add(
                LocalLicenses
            );


            LocalLicenses.BannerImage =
                Image.FromFile(
                    @"C:\DVLD\images\locallicesnse.jpg"
                );
        }
        private void CreateInternationalLicenses()
        {
            InternationalLicenses = new MenuBanner();


            InternationalLicenses.Title =
                "Innternational Licenses";


            InternationalLicenses.Description =
                "Apply for International licenses";


            InternationalLicenses.Size =
                new Size(250, 180);


            InternationalLicenses.Margin =
                new Padding(20);



            InternationalLicenses.BannerClick +=
                InternationalLicenses_BannerClick;



            bannersPanel.Controls.Add(
                InternationalLicenses
            );


            InternationalLicenses.BannerImage =
                Image.FromFile(
                    @"C:\DVLD\images\InternationalLicenses.jpg"
                );
        }


        private void CreateReplacementLicenses()
        {
            Replacement = new MenuBanner();


            Replacement.Title =
                "Replacement Licenses";


            Replacement.Description =
                "Apply for Replacement licenses";


            Replacement.Size =
                new Size(250, 180);


            Replacement.Margin =
                new Padding(20);



            Replacement.BannerClick +=
                Replacement_BannerClick;



            bannersPanel.Controls.Add(
                Replacement
            );


            Replacement.BannerImage =
                Image.FromFile(
                    @"C:\DVLD\images\Replacement.jpg"
                );
        }

        private void CreateDetainedLicenses()
        {
            DetainedLicenses = new MenuBanner();


            DetainedLicenses.Title =
                "DetainedLicenses Licenses";


            DetainedLicenses.Description =
                "Apply for DetainedLicenses licenses";


            DetainedLicenses.Size =
                new Size(250, 180);


            DetainedLicenses.Margin =
                new Padding(20);



            DetainedLicenses.BannerClick +=
                DetainedLicenses_BannerClick;



            bannersPanel.Controls.Add(
                DetainedLicenses
            );


            DetainedLicenses.BannerImage =
                Image.FromFile(
                    @"C:\DVLD\images\DetainedLicenses.jpg"
                );
        }

        private void CreateManageApplicants()
        {
            ManageApplicants = new MenuBanner();


            ManageApplicants.Title =
                "Manage Local Applicants";


            ManageApplicants.Description =
                "Manage Applicants for local license";


            ManageApplicants.Size =
                new Size(250, 180);


            ManageApplicants.Margin =
                new Padding(20);



            ManageApplicants.BannerClick +=
                ManageApplicants_BannerClick;



            bannersPanel.Controls.Add(
                ManageApplicants
            );


            ManageApplicants.BannerImage =
                Image.FromFile(
                    @"C:\DVLD\images\ManageApplicants.png"
                );
        }

       
        private void CreateTestTypes()
        {
            TestTypes = new MenuBanner();


            TestTypes.Title =
                "Tests types";


            TestTypes.Description =
                "Show and update fees";


            TestTypes.Size =
                new Size(250, 180);


            TestTypes.Margin =
                new Padding(20);



            TestTypes.BannerClick +=
                TestTypes_BannerClick;



            bannersPanel.Controls.Add(
                TestTypes
            );


            TestTypes.BannerImage =
                Image.FromFile(
                    @"C:\DVLD\images\TestTypes.png"
                );
        }
        private void CreateApplicationsTypes()
        {
            ApplicationsTypes = new MenuBanner();


            ApplicationsTypes.Title =
                "Applications types";


            ApplicationsTypes.Description =
                "Show and update fees";


            ApplicationsTypes.Size =
                new Size(250, 180);


            ApplicationsTypes.Margin =
                new Padding(20);



            ApplicationsTypes.BannerClick +=
                ApplicationsBanner_BannerClick;



            bannersPanel.Controls.Add(
                ApplicationsTypes
            );


            ApplicationsTypes.BannerImage =
                Image.FromFile(
                    @"C:\DVLD\images\Applications.png"
                );
        }
   

        private void CreateManageAccountBanner()
        {
            account =
      new AccountBanner();


            account.Location =
                new Point(
                    ClientSize.Width - 430,
                    40);


            account.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;


            account.FullName =
                CurrentUser.Person.FirstName + " " + CurrentUser.Person.LastName;


            account.ProfileImage =
                CurrentUser.Person.ImagePath == null
                ? null
                : Image.FromFile(
                    CurrentUser.Person.ImagePath);


            account.BannerClick +=
                Account_BannerClick;


            Controls.Add(account);


        }

        private void _Updated()
        {
            account.FullName =
                CurrentUser.Person.FirstName + " " + CurrentUser.Person.LastName;


            account.ProfileImage =
                CurrentUser.Person.ImagePath == null
                ? null
                : Image.FromFile(
                    CurrentUser.Person.ImagePath);

            lblWelcome.Text =
               "Welcome, " + CurrentUser.User.UserName;

        }


        private void Replacement_BannerClick(object sender,EventArgs e)
        {
            if(CurrentUser.HasPermission(enPermissions.ReplacementLicense) == false)
            {
                MessageBox.Show(
                    "You do not have permission to manage replacement licenses.",
                    "Permission Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            frmReplacement frm = new frmReplacement();
            frm.ShowDialog( );
        }
        private void ApplicationsBanner_BannerClick(object sender, EventArgs e)
        {
            if(CurrentUser.HasPermission(enPermissions.ApplicationTypes) == false)
            {
                MessageBox.Show(
                    "You do not have permission to manage application types.",
                    "Permission Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            frmApplicationsTypes frm = new frmApplicationsTypes();
            frm.ShowDialog();
        }
      
        private void TestTypes_BannerClick(object sender, EventArgs e)
        {
            if(CurrentUser.HasPermission(enPermissions.Types) == false)
            {
                MessageBox.Show(
                    "You do not have permission to manage test types.",
                    "Permission Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            frmTestsTypes frm = new frmTestsTypes();
            frm.ShowDialog();
        }
        private void Account_BannerClick(object sender, EventArgs e)
        {
            frmManageAccount frm =
                new frmManageAccount();

            frm.ShowDialog();
        }
      
        public void InternationalLicenses_BannerClick(object sender,EventArgs e)
        {
            if(CurrentUser.HasPermission(enPermissions.AddInternationalLicense) == false)
            {
                MessageBox.Show(
                    "You do not have permission to manage international licenses.",
                    "Permission Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            frmAddInternationalLicense frm = new frmAddInternationalLicense();
            frm.ShowDialog();
        }


        private void DetainedLicenses_BannerClick(object sender, EventArgs e)
        {
            if (CurrentUser.HasPermission(enPermissions.DetainedLicense) == false)
            {
                MessageBox.Show(
                    "You do not have permission to manage detained licenses.",
                    "Permission Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            frmManageDetainedLicenses frm = new frmManageDetainedLicenses();
            frm.ShowDialog();

        }
        private void LocalLicenses_BannerClick(object sender, EventArgs e)
        {
            if (CurrentUser.HasPermission(enPermissions.AddAndRenewLocalLicense) == false)
            {
                MessageBox.Show(
                    "You do not have permission to manage local licenses.",
                    "Permission Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            frmAddLocalLicense frm = new frmAddLocalLicense();
            frm.ShowDialog();
        }


        private void ManageApplicants_BannerClick(object sender,EventArgs e)
        {
            if(CurrentUser.HasPermission(enPermissions.ManageLocal) == false)
            {
                MessageBox.Show(
                    "You do not have permission to manage applicants.",
                    "Permission Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            frmLDLApplicants frm = new frmLDLApplicants();
            frm.ShowDialog();
        }
        private void frmApplications_Load(
            object sender,
            EventArgs e)
        {
            FormAnimator.FadeIn(this);
        }
    }
}