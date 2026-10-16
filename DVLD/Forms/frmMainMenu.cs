using BCrypt.Net;
using BusinessLayer;
using BusinessLayer.Models;
using DVLD.Controls;
using DVLD.Forms.Types;
using DVLD.Presentation.UI;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace DVLD.Forms
{
    public partial class frmMainMenu : BaseForm
    {

        AccountBanner account;
        private Label lblWelcome;
        private Label lblTitle;
        private MenuBanner usersBanner;
        private MenuBanner Licenses;
        private MenuBanner Applications;
      
        private MenuBanner Drivers;
        private FlowLayoutPanel bannersPanel;

        private MenuBanner peopleBanner;
      

        public frmMainMenu( )
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

            Load += frmMainMenu_Load;
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
                "Welcome, "+CurrentUser.User.UserName;

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
            CreatePeopleBanner();
            CreateUsersBanner();
           
            CreateApplications();
            CreateDrivers();
            CreateLicenses();
        }


        private void CreatePeopleBanner()
        {
            peopleBanner = new MenuBanner();

            peopleBanner.Title =
                "People";


            peopleBanner.Description =
                "Manage system people";


            peopleBanner.Size =
                new Size(250, 180);


            peopleBanner.Margin =
                new Padding(20);


            peopleBanner.BannerClick +=
                PeopleBanner_BannerClick;


            bannersPanel.Controls.Add(
                peopleBanner
            );
            peopleBanner.BannerImage = Image.FromFile("C:\\DVLD\\images\\People.jpg");
        }
       
        private void CreateApplications()
        {
            Applications = new MenuBanner();


            Applications.Title =
                "Applications";


            Applications.Description =
                "Apply for license and show application types";


            Applications.Size =
                new Size(250, 180);


            Applications.Margin =
                new Padding(20);



            Applications.BannerClick +=
                ApplicationsBanner_BannerClick;



            bannersPanel.Controls.Add(
                Applications
            );


            Applications.BannerImage =
                Image.FromFile(
                    @"C:\DVLD\images\apps.png"
                );
        }

        private void CreateLicenses()
        {
            Licenses = new MenuBanner();


            Licenses.Title =
                "Licenses";


            Licenses.Description =
                "Manage licenses ";


            Licenses.Size =
                new Size(250, 180);


            Licenses.Margin =
                new Padding(20);



            Licenses.BannerClick +=
                Licenses_BannerClick;



            bannersPanel.Controls.Add(
                Licenses
            );


            Licenses.BannerImage =
                Image.FromFile(
                    @"C:\DVLD\images\Licenses.png"
                );
        }
        private void CreateDrivers()
        {
            Drivers = new MenuBanner();


            Drivers.Title =
                "Drivers";


            Drivers.Description =
                "Manage drivers";


            Drivers.Size =
                new Size(250, 180);


            Drivers.Margin =
                new Padding(20);



            Drivers.BannerClick +=
                Drivers_BannerClick;



            bannersPanel.Controls.Add(
                Drivers
            );


            Drivers.BannerImage =
                Image.FromFile(
                    @"C:\DVLD\images\Drivers.png"
                );
        }
        private void CreateUsersBanner()
        {
            usersBanner = new MenuBanner();


            usersBanner.Title =
                "Manage Users";


            usersBanner.Description =
                "Manage system users";


            usersBanner.Size =
                new Size(250, 180);


            usersBanner.Margin =
                new Padding(20);



            usersBanner.BannerClick +=
                UsersBanner_BannerClick;



            bannersPanel.Controls.Add(
                usersBanner
            );


            usersBanner.BannerImage =
                Image.FromFile(
                    @"C:\DVLD\images\Users.jpg"
                );
        }
        private void Drivers_BannerClick(object sender, EventArgs e)
        {
            if(CurrentUser.HasPermission(enPermissions.Drivers) == false)
            {
                MessageBox.Show(
                    "You do not have permission to view drivers.",
                    "Permission Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            frmManageDrivers frm = new frmManageDrivers();
            frm.Show();

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
                CurrentUser.Person.FirstName+" "+CurrentUser.Person.LastName;


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
     


    private void ApplicationsBanner_BannerClick(Object sender, EventArgs e)
        {
            frmApplications frm = new frmApplications();
            frm.Show();
        }
        

        private void Licenses_BannerClick( object sender, EventArgs e)
        {
            if(CurrentUser.HasPermission(enPermissions.Licenses) == false)
            {
                MessageBox.Show(
                    "You do not have permission to view licenses.",
                    "Permission Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            frmLicenses frm= new frmLicenses();
            frm.ShowDialog();
        }
        private void Account_BannerClick(object sender, EventArgs e)
        {
            frmManageAccount frm =
                new frmManageAccount();

            frm.ShowDialog();
        }
        private void PeopleBanner_BannerClick(
            object sender,
            EventArgs e)
        {
            if(CurrentUser.HasPermission(enPermissions.People) == false)
            {
                MessageBox.Show(
                    "You do not have permission to view people.",
                    "Permission Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            frmPeople p = new frmPeople();
            p.Show();
           

        }

        private void UsersBanner_BannerClick(object sender,EventArgs e)
        {
            if(CurrentUser.HasPermission(enPermissions.ManageUsers) == false)
            {
                MessageBox.Show(
                    "You do not have permission to manage users.",
                    "Permission Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            frmUsers frm =
                new frmUsers();


            frm.ShowDialog();
         


        }
        private void frmMainMenu_Load(
            object sender,
            EventArgs e)
        {
            FormAnimator.FadeIn(this);
        }
    }
}