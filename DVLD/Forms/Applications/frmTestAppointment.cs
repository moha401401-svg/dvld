using BusinessLayer.Models;
using DVLD.Business;
using DVLD.Business.Models;
using DVLD.Controls;
using DVLD.Presentation.UI;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Forms.Applications
{
    public enum TestMode
    {
        Test1=1,
        Test2=2,
        Test3=3
    }

    public class frmTestAppointment : BaseForm
    {
        private readonly TestMode _mode;
        private readonly string _nationalNo;
        private readonly int _applicationID;
        private  bool _IsRetake;
        private Label lblTitle;
 
        private Panel pnlPerson;
        private Panel pnlTestInfo;
        private Panel pnlAppointments;
        private Panel pnlBottom;
        private Action Refresh;
        private Action RefreshMainBack;
        private Action RefreshMain;
        private PersonInfoCard personInfoCard;

        private Label lblTestNameValue;
        private Label lblDescriptionValue;
        private Label lblApplicationIDValue;
        private Label lblTestFeesValue;
        private Label lblRetakeFeesValue;
        private Label lblTotalFeesValue;

        private DataGridView dgvAppointments;

        private RoundedButton btnAddAppointment;
        private RoundedButton btnStartTest;
        private RoundedButton btnCancel;

        public int PassedTests
        {
            get;
            private set;
        }
        public frmTestAppointment(
            TestMode mode,
            string nationalNo,
            int applicationID,int passedTests)
        {
            _mode = mode;
            _nationalNo = nationalNo;
            _applicationID = applicationID;
            PassedTests = passedTests;

            InitializeForm();
            InitializeUI();
            ConfigureTest();
            LoadPerson();
            LoadAppointments();
            Refresh=LoadAppointments;
            RefreshMain = CloseWithRefresh;
        }

        public void CloseWithRefresh()
        {
           
            RefreshMainBack?.Invoke();
            LoadAppointments();
            Close();
        }
        private void InitializeForm()
        {
            Text =
                "Test Appointment";

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
                "Test Appointment";

            lblTitle.Dock =
                DockStyle.Top;

            lblTitle.Height =
                70;

            lblTitle.TextAlign =
                ContentAlignment.MiddleCenter;

            lblTitle.Font =
                new Font(
                    "Segoe UI",
                    22,
                    FontStyle.Bold);

            lblTitle.ForeColor =
                Theme.TextPrimary;

            Controls.Add(lblTitle);


            pnlPerson =
                new Panel();

            pnlPerson.Location =
                new Point(30, 85);

            pnlPerson.Size =
                new Size(700, 550);

           

            pnlPerson.BackColor =
                Theme.CardBackground;

            Controls.Add(pnlPerson);


            InitializePersonCard();


            pnlTestInfo =
                new Panel();

            pnlTestInfo.Location =
                new Point(900, 200);

            pnlTestInfo.Size =
                new Size(
                    ClientSize.Width - 60,
                    190);

            pnlTestInfo.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            pnlTestInfo.BackColor =
                Theme.CardBackground;

            Controls.Add(pnlTestInfo);
           

            InitializeTestInfo();


            pnlAppointments =
                new Panel();

            pnlAppointments.Location =
                new Point(30, 700);

            pnlAppointments.Size =
                new Size(
                    ClientSize.Width - 60,
                    300);

            pnlAppointments.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            pnlAppointments.BackColor =
                Theme.CardBackground;

            Controls.Add(pnlAppointments);


            InitializeAppointments();


            InitializeButtons();
        }


        private void InitializePersonCard()
        {
            personInfoCard =
                new PersonInfoCard();

            personInfoCard.Dock =
                DockStyle.Fill;

            personInfoCard.Margin =
                new Padding(10);

            

            pnlPerson.Controls.Add(
                personInfoCard);


        }


        private void InitializeTestInfo()
        {
            Label lblSection =
                CreateSectionTitle(
                    "Test Information",
                    15);

            pnlTestInfo.Controls.Add(
                lblSection);


            CreateInfoLabel(
                "Test",
                55,
                out lblTestNameValue);

            CreateInfoLabel(
                "Description",
                85,
                out lblDescriptionValue);

            CreateInfoLabel(
                "Application ID",
                115,
                out lblApplicationIDValue);

            CreateInfoLabel(
                "Test Fees",
                140,
                out lblTestFeesValue);


           


            Label lblRetakeTitle =
                CreateSimpleLabel(
                    "Retake Fees",
                    55);

            lblRetakeTitle.Location =
                new Point(
                    500,
                    55);

            pnlTestInfo.Controls.Add(
                lblRetakeTitle);


            Label lblTotalTitle =
                CreateSimpleLabel(
                    "Total Fees",
                    145);

            lblTotalTitle.Location =
                new Point(
                    500,
                    145);

            pnlTestInfo.Controls.Add(
                lblTotalTitle);


            lblTotalFeesValue =
                new Label();

            lblTotalFeesValue.Text =
                "$0.00";
           
            lblTotalFeesValue.Font =
                new Font(
                    "Segoe UI",
                    12,
                    FontStyle.Bold);

            lblTotalFeesValue.ForeColor =
                Theme.TextPrimary;

            lblTotalFeesValue.AutoSize =
                true;

            lblTotalFeesValue.Location =
                new Point(
                    650,
                    145);

            pnlTestInfo.Controls.Add(
                lblTotalFeesValue);


            lblRetakeFeesValue = new Label();
            if (TestAppointment.IsRetake(_applicationID, (int)_mode))
            {
                _IsRetake = true;
                lblRetakeFeesValue.Text = "5.00";

            }
            else { lblRetakeFeesValue.Text = "0.00"; _IsRetake = false; }
            lblRetakeFeesValue.Font =
               new Font(
                   "Segoe UI",
                   12,
                   FontStyle.Regular);

            lblRetakeFeesValue.ForeColor =
                Theme.TextPrimary;

            lblRetakeFeesValue.AutoSize =
                true;

            lblRetakeFeesValue.Location =
                new Point(
                    650,
                    55);

            pnlTestInfo.Controls.Add(
               lblRetakeFeesValue);

        }


        private void CreateInfoLabel(
            string title,
            int y,
            out Label valueLabel)
        {
            Label lblTitle =
                CreateSimpleLabel(
                    title,
                    y);

            lblTitle.Location =
                new Point(
                    40,
                    y);

            pnlTestInfo.Controls.Add(
                lblTitle);


            valueLabel =
                new Label();

            valueLabel.Text =
                "-";

            valueLabel.Font =
                new Font(
                    "Segoe UI",
                    11);

            valueLabel.ForeColor =
                Theme.TextSecondary;

            valueLabel.AutoSize =
                false;

            valueLabel.Location =
                new Point(
                    180,
                    y);

            valueLabel.Size =
                new Size(
                    280,
                    28);

            pnlTestInfo.Controls.Add(
                valueLabel);
        }


        private Label CreateSimpleLabel(
            string text,
            int y)
        {
            Label label =
                new Label();

            label.Text =
                text;

            label.Font =
                new Font(
                    "Segoe UI",
                    11,
                    FontStyle.Bold);

            label.ForeColor =
                Theme.TextPrimary;

            label.AutoSize =
                true;

            label.Location =
                new Point(
                    40,
                    y);

            return label;
        }


        private Label CreateSectionTitle(
            string text,
            int y)
        {
            Label label =
                new Label();

            label.Text =
                text;

            label.Font =
                new Font(
                    "Segoe UI",
                    14,
                    FontStyle.Bold);

            label.ForeColor =
                Theme.TextPrimary;

            label.AutoSize =
                true;

            label.Location =
                new Point(
                    40,
                    y);

            return label;
        }


        private void InitializeAppointments()
        {
            Label lblTitle =
                CreateSectionTitle(
                    "Registered Appointments",
                    15);

            pnlAppointments.Controls.Add(
                lblTitle);


            btnAddAppointment =
                new RoundedButton();

            btnAddAppointment.Text =
                "Add Appointment";

            btnAddAppointment.Size =
                new Size(
                    150,
                    40);

            btnAddAppointment.Location =
                new Point(
                    pnlAppointments.Width - 190,
                    10);

            btnAddAppointment.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;

            btnAddAppointment.NormalColor =
                Color.FromArgb(
                    70,
                    120,
                    160);

            btnAddAppointment.Click +=
                BtnAddAppointment_Click;

            pnlAppointments.Controls.Add(
                btnAddAppointment);


            dgvAppointments =
                new DataGridView();

            dgvAppointments.Location =
                new Point(
                    40,
                    55);

            dgvAppointments.Size =
                new Size(
                    pnlAppointments.Width - 80,
                    150);

            dgvAppointments.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;

            dgvAppointments.ReadOnly =
                true;

            dgvAppointments.AllowUserToAddRows =
                false;

            dgvAppointments.AllowUserToDeleteRows =
                false;

            dgvAppointments.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvAppointments.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvAppointments.BackgroundColor =
                Color.White;

            dgvAppointments.BorderStyle =
                BorderStyle.None;

            pnlAppointments.Controls.Add(
                dgvAppointments);
        }


        private void InitializeButtons()
        {
            pnlBottom =
                new Panel();

            pnlBottom.Dock =
                DockStyle.Bottom;

            pnlBottom.Height =
                70;

            pnlBottom.BackColor =
                Color.Transparent;

            Controls.Add(
                pnlBottom);


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
                    ClientSize.Width - 300,
                    10);

            btnCancel.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;

            btnCancel.NormalColor =
                Color.FromArgb(
                    100,
                    100,
                    100);

            btnCancel.Click +=
                BtnCancel_Click;

            pnlBottom.Controls.Add(
                btnCancel);


            btnStartTest =
                new RoundedButton();

            btnStartTest.Text =
                "Start Test";

            btnStartTest.Size =
                new Size(
                    130,
                    45);

            btnStartTest.Location =
                new Point(
                    ClientSize.Width - 155,
                    10);

            btnStartTest.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;

            btnStartTest.NormalColor =
                Color.CornflowerBlue;

            btnStartTest.Click +=
                BtnStartTest_Click;

            pnlBottom.Controls.Add(
                btnStartTest);
        }


        private void ConfigureTest()
        {
            switch (_mode)
            {
                case TestMode.Test1:

                    lblTestNameValue.Text =
                        TestTypes.GetName(1);

                    lblDescriptionValue.Text =
                        TestTypes.GetDes(1);

                    lblTestFeesValue.Text =
                        TestTypes.GetFees(1)
                        .ToString("0.00");

                    break;


                case TestMode.Test2:

                    lblTestNameValue.Text =
                        TestTypes.GetName(2);

                    lblDescriptionValue.Text =
                        TestTypes.GetDes(2);

                    lblTestFeesValue.Text =
                        TestTypes.GetFees(2)
                        .ToString("0.00");

                    break;


                case TestMode.Test3:

                    lblTestNameValue.Text =
                        TestTypes.GetName(3);

                    lblDescriptionValue.Text =
                        TestTypes.GetDes(3);

                    lblTestFeesValue.Text =
                        TestTypes.GetFees(3)
                        .ToString("0.00");

                    break;
            }


            lblApplicationIDValue.Text =
                _applicationID.ToString();





            lblTotalFeesValue.Text =
              (Convert.ToDouble(lblTestFeesValue.Text) + Convert.ToDouble(lblRetakeFeesValue.Text)).ToString();
        }


        private void LoadPerson()
        {
            People data =
                People.GetPerson(_nationalNo);

            if (data == null )
            {
                return;
            }

            personInfoCard.LoadPerson(data);
        }


        private void LoadAppointments()
        {
          dgvAppointments.DataSource= TestAppointments_View.GetAppointments(_applicationID);
        }


        private void BtnAddAppointment_Click(
            object sender,
            EventArgs e)
        {

            if (!TestAppointment.CanGetAppointment(_applicationID))
            {
                CustomMessageBox.Show("Faild!", "You already have an appointment");
                return;
            }
            frmAppointment frm = new frmAppointment(_mode, _IsRetake, _applicationID);
            switch (_mode)
            {
                case TestMode.Test1:
                    frm.TestImage =
                    Image.FromFile(@"C:\DVLD\images\test1.png");
                    break;
                case TestMode.Test2:
                    frm.TestImage =
                   Image.FromFile(@"C:\DVLD\images\test2.png");
                    break;
                default:
                    frm.TestImage =
                   Image.FromFile(@"C:\DVLD\images\test3.png");
                    break;


            }
            frm.RefreshData = Refresh;
           
            frm.ShowDialog();

        }


        private void BtnStartTest_Click(
            object sender,
            EventArgs e)
        {
            if (dgvAppointments.CurrentRow == null)
            {
                CustomMessageBox.Show("Faild!", "Please, select an appointment");
                return;
            }
            if (Convert.ToBoolean(dgvAppointments.CurrentRow.Cells["IsLocked"].Value))
            {
                CustomMessageBox.Show("Faild!", "Please, select an available appointment");
                return;
            }
            int id= Convert.ToInt32(dgvAppointments.CurrentRow.Cells[0].Value);
            frmTest app = new frmTest(_mode,_IsRetake,_applicationID,id,PassedTests);

            switch (_mode)
            {
                case TestMode.Test1:
                    app.TestImage =
                    Image.FromFile(@"C:\DVLD\images\test1.png");
                    break;
                case TestMode.Test2:
                    app.TestImage =
                   Image.FromFile(@"C:\DVLD\images\test2.png");
                    break;
                default:
                    app.TestImage =
                   Image.FromFile(@"C:\DVLD\images\test3.png");
                    break;


            }
            app.RefreshData = RefreshMain;
            app.ShowDialog();
            PassedTests = app.PassedTest;

        }


        private void BtnCancel_Click(
            object sender,
            EventArgs e)
        {
            Close();
        }
    }
}