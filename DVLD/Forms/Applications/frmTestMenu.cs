using DVLD.Controls;
using DVLD.Presentation.UI;
using System;
using System.Drawing;
using System.Windows.Forms;
using DVLD.Presentation.UI;
using BusinessLayer.Models;
using DVLD.Forms.Applications;
namespace DVLD.Forms
{
    public partial class frmTestMenu
        : BaseForm
    {
        private Label lblTitle;
        string NationalNo;
        public Action RefreshData;
        public int PassedTests
        {
            get;
            private set;
        }
        int LDLID;
        private AccountActionBanner bannerTest1;
        private AccountActionBanner bannerTest2;
        private AccountActionBanner bannerTest3;

        public frmTestMenu(string NationalNo,int LDLID, int PassedTests)
        {
            this.NationalNo = NationalNo;
            this.PassedTests = PassedTests;
            this.LDLID = LDLID;
            InitializeForm();
            InitializeUI();
            InitializeBanners();
        }
        public void CloseWithRefresh()
        {
            RefreshData?.Invoke();
            Close();
        }
        private void InitializeForm()
        {
            Text =
                "Tests";

            StartPosition =
                FormStartPosition.CenterScreen;

            WindowState =
                FormWindowState.Maximized;

            BackColor =
                Theme.AppBackground;
        }

        private void InitializeUI()
        {
            lblTitle =
                new Label();

            lblTitle.Text =
                "Tests";

            lblTitle.Dock =
                DockStyle.Top;

            lblTitle.Height =
                80;

            lblTitle.TextAlign =
                ContentAlignment.MiddleCenter;

            lblTitle.Font =
                new Font(
                    "Segoe UI",
                    24,
                    FontStyle.Bold);

            lblTitle.ForeColor =
                Theme.TextPrimary;

            Controls.Add(lblTitle);
        }

        private void InitializeBanners()
        {
            bannerTest1 =
                CreateBanner(
                    TestTypes.GetName(1),
                    TestTypes.GetDes(1));

            bannerTest2 =
                CreateBanner(
                   TestTypes.GetName(2),
                    TestTypes.GetDes(2));

            bannerTest3 =
                CreateBanner(
                    TestTypes.GetName(3),
                    TestTypes.GetDes(3));


            bannerTest1.BannerImage = Image.FromFile("C:\\DVLD\\images\\test1.png");
            bannerTest2.BannerImage = Image.FromFile("C:\\DVLD\\images\\test2.png");
            bannerTest3.BannerImage = Image.FromFile("C:\\DVLD\\images\\test3.png");
            bannerTest1.HoverBorderColor = Color.Green;
            bannerTest1.HoverColor = Color.LightGreen;
            bannerTest2.HoverBorderColor = Color.Yellow;
            bannerTest2.HoverColor = Color.LightYellow;
            bannerTest3.HoverBorderColor = Color.Red;
            bannerTest3.HoverColor = Color.OrangeRed;

            Controls.Add(
                bannerTest1);

            Controls.Add(
                bannerTest2);

            Controls.Add(
                bannerTest3);


            ArrangeBanners();
            bannerTest1.BannerClick += Banner1Click;
            bannerTest2.BannerClick += Banner2Click;
            bannerTest3.BannerClick += Banner3Click;

            Resize +=
                (s, e) =>
                {
                    ArrangeBanners();
                };
        }

        private AccountActionBanner CreateBanner(
            string title,
            string description)
        {
            AccountActionBanner banner =
                new AccountActionBanner();

            banner.Title =
                title;

            banner.Description =
                description;

            banner.Width =
                280;

            banner.Height =
                500;

            banner.Cursor =
                Cursors.Hand;

            return banner;
        }

        private void ArrangeBanners()
        {
            int margin =
                50;

            int spacing =
                30;

            int availableWidth =
                ClientSize.Width
                - (margin * 2)
                - (spacing * 2);

            int bannerWidth =
                availableWidth / 3;

            int bannerHeight =
                ClientSize.Height
                - 150;


            int y =
                110;


            bannerTest1.Size =
                new Size(
                    bannerWidth,
                    bannerHeight);
            bannerTest1.ImageOffsetY = 500;
            bannerTest1.ImageBaseSize = 300;

            bannerTest1.TitleOffsetY = 600;

            bannerTest1.DescriptionOffsetY = 100;
            bannerTest2.Size =
                new Size(
                    bannerWidth,
                    bannerHeight);

            bannerTest2.ImageOffsetY = 500;
            bannerTest2.ImageBaseSize = 300;

            bannerTest2.TitleOffsetY = 600;

            bannerTest2.DescriptionOffsetY = 100;

            bannerTest3.Size =
                new Size(
                    bannerWidth,
                    bannerHeight);

            bannerTest3.ImageOffsetY = 500;
            bannerTest3.ImageBaseSize = 300;

            bannerTest3.TitleOffsetY = 600;

            bannerTest3.DescriptionOffsetY = 100;


            bannerTest1.Location =
                new Point(
                    margin,
                    y);


            bannerTest2.Location =
                new Point(
                    margin
                    + bannerWidth
                    + spacing,
                    y);


            bannerTest3.Location =
                new Point(
                    margin
                    + (bannerWidth + spacing) * 2,
                    y);
        }

        public void Banner1Click(object sender, EventArgs e)
        {
            if (PassedTests != 0)
            {
                CustomMessageBox.Show("Faild", "You already finished this test"); return;
            }

            frmTestAppointment frm = new frmTestAppointment(TestMode.Test1, NationalNo, LDLID, PassedTests);
            frm.ShowDialog();
            PassedTests = frm.PassedTests;
           



        }
        public void Banner2Click(object sender, EventArgs e)
        {
            if (PassedTests >1)
            {
                CustomMessageBox.Show("Faild", "You already finished this test"); return;
            }
            if (PassedTests == 0) {

                CustomMessageBox.Show("Faild", "You have to complete test 1"); return;
            }

            frmTestAppointment frm = new frmTestAppointment(TestMode.Test2, NationalNo, LDLID, PassedTests);
            frm.ShowDialog();
            PassedTests = frm.PassedTests;



        }
        public void Banner3Click(object sender, EventArgs e)
        {
            if (PassedTests > 2)
            {
                CustomMessageBox.Show("Faild", "You already finished this test"); return;
            }
            if(PassedTests <2)
            {
                CustomMessageBox.Show("Faild", "You have to complete previous tests "); return;
            }

            frmTestAppointment frm = new frmTestAppointment(TestMode.Test3, NationalNo, LDLID, PassedTests);
            frm.ShowDialog();
            PassedTests = frm.PassedTests;
            if (PassedTests == 3)
            {
                
               frmLicenseNotes frmNotes = new frmLicenseNotes();
                frmNotes.ShowDialog();
                string notes= frmNotes.Notes;

              int id=  Licenses.Insertion(LDLID, notes);
                frmLicenseDetails frmlic= new frmLicenseDetails(id);
                frmlic.ShowDialog();
              int AppID=  LDLApplications.GetApplicationID(LDLID);
                     BusinessLayer.Models.Applications.Update(AppID,enUpdateApplicationMode.Completed);

            }

        }



    }
}