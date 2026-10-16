using BusinessLayer;
using DVLD.Controls;
using DVLD.Presentation.UI;
using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace DVLD.Forms
{
    public partial class frmManageAccount : BaseForm
    {

        private Label lblTitle;


        private AccountActionBanner editProfileBanner;
        private AccountActionBanner editAccountBanner;
        private AccountActionBanner darkModeBanner;
        private AccountActionBanner logoutBanner;



        public frmManageAccount()
        {
            InitializeComponent();

            InitializeForm();

            InitializeComponents();

            LoadBanners();
        }



        private void InitializeForm()
        {
            WindowState =
                FormWindowState.Maximized;


            BackColor =
                Theme.AppBackground;


            Text =
                "Manage Account";
        }



        private void InitializeComponents()
        {

            lblTitle =
                new Label();


            lblTitle.Text =
                "Manage Account";


            lblTitle.Font =
                Theme.HeaderFont;


            lblTitle.ForeColor =
                Theme.TextPrimary;


            lblTitle.AutoSize =
                true;


            lblTitle.Location =
                new Point(
                    60,
                    60);


            Controls.Add(lblTitle);

        }



        private void LoadBanners()
        {

            editProfileBanner =
                CreateBanner(
                    "Edit Profile",
                    "Change your personal information",
                    Properties.Resources.EditProfile,
                    Color.CornflowerBlue);



            editAccountBanner =
                CreateBanner(
                    "Edit Account",
                    "Username and password settings",
                    Properties.Resources.EditAccount,
                    Color.MediumPurple);



            darkModeBanner =
                CreateBanner(
                    "Dark Mode",
                    "Change application appearance",
                    Properties.Resources.dark,
                    Color.DarkGray);



            logoutBanner =
                CreateBanner(
                    "Logout",
                    "Sign out from your account",
                    Properties.Resources.logout,
                    Color.IndianRed);

            logoutBanner.BannerImage =
             Properties.Resources.logout;

            darkModeBanner.BannerImage =
             Properties.Resources.dark;

            editAccountBanner.BannerImage =
             Properties.Resources.EditAccount;

            editProfileBanner.BannerImage =
             Properties.Resources.EditProfile;

            editProfileBanner.Location =
                new Point(
                    150,
                    170);



            editAccountBanner.Location =
                new Point(
                    480,
                    170);



            darkModeBanner.Location =
                new Point(
                    150,
                    450);



            logoutBanner.Location =
                new Point(
                    480,
                    450);



            Controls.Add(editProfileBanner);
            Controls.Add(editAccountBanner);
            Controls.Add(darkModeBanner);
            Controls.Add(logoutBanner);



            editProfileBanner.BannerClick +=
                EditProfileBanner_BannerClick;


            editAccountBanner.BannerClick +=
                EditAccountBanner_BannerClick;


            darkModeBanner.BannerClick +=
                DarkModeBanner_BannerClick;


            logoutBanner.BannerClick +=
                LogoutBanner_BannerClick;
            ArrangeBanners();
        }


        private void ArrangeBanners()
        {

            int gap = 70;


            int width = 420;
            int height = 320;


            int totalWidth =
                (width * 2) + gap;



            int startX =
                (ClientSize.Width - totalWidth) / 2;



            int startY =
                170;



            editProfileBanner.Size =
                new Size(width+50, height + 50);


            editAccountBanner.Size =
                new Size(width + 50, height + 50);


            darkModeBanner.Size =
                new Size(width + 50, height + 50);


            logoutBanner.Size =
                new Size(width + 50, height + 50);



            editProfileBanner.Location =
                new Point(
                     500 + startX,
                    startY);



            editAccountBanner.Location =
                new Point(
                     550 + startX + width + gap,
                    startY);



            darkModeBanner.Location =
                new Point(
                    500+startX,
                    startY + height + gap+50);



            logoutBanner.Location =
                new Point(
                    550 + startX + width + gap,
                    startY + height + gap+50);

        }

        private AccountActionBanner CreateBanner(
            string title,
            string description,
            Image image,
            Color hoverColor)
        {

            AccountActionBanner banner =
                new AccountActionBanner();


            banner.Title =
                title;


            banner.Description =
                description;


            banner.BannerImage =
                image;


            banner.HoverColor =
                hoverColor;


            return banner;
        }




        private void EditProfileBanner_BannerClick(
            object sender,
            EventArgs e)
        {

            frmAddEditPerson frm = new frmAddEditPerson(CurrentUser.Person.PersonID);
            frm.ShowDialog();
            CurrentUser.Refresh();
        }




        private void EditAccountBanner_BannerClick(
            object sender,
            EventArgs e)
        {

            frmEditAccount frm = new frmEditAccount();
            frm.ShowDialog();
        }





        private void DarkModeBanner_BannerClick(
            object sender,
            EventArgs e)
        {

            ThemeManager.ToggleTheme();
        }





        private void LogoutBanner_BannerClick(
            object sender,
            EventArgs e)
        {

            ApplicationSession.Logout();
        }


    }
}