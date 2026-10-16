using BusinessLayer.Models;
using DVLD.Controls;
using DVLD.Forms.Applications;
using DVLD.Presentation.UI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Forms
{
    public class frmTest : BaseForm
    {
        private Label lblTitle;

        public Action RefreshData;

        private Label lblNotes;
        private TextBox txtNotes;

        private Panel pnlTestInfo;
        private Panel pnlTestResult;

        private PictureBox picTest;

        private TestInfoControl testInfoControl;

        private Label lblResultTitle;

        private RadioButton rbPassed;
        private RadioButton rbFailed;

        private RoundedButton btnCancel;
        private RoundedButton btnSave;
        private int TestAppoitmentID;
    

        public int ApplicationId
        {
            get;
            private set;
        }


        public TestMode Mode
        {
            get;
            private set;
        }


        public bool IsRetake
        {
            get;
            private set;
        }


        public Image TestImage
        {
            get
            {
                return picTest.Image;
            }

            set
            {
                picTest.Image = value;
            }
        }

        public int PassedTest
        {
            get;
            private set;
        }
        public bool Passed
        {
            get
            {
                return rbPassed.Checked;
            }
        }


        public frmTest(
            TestMode mode,
            bool isRetake,
            int applicationId,int testAppoitmentID,int passedTests)
        {
            Mode = mode;
            IsRetake = isRetake;
            ApplicationId = applicationId;
            PassedTest = passedTests;
            TestAppoitmentID=testAppoitmentID;

            

            InitializeForm();
            InitializeUI();
            InitializeTestInfo();
            InitializeTestResult();
            InitializeButtons();
        }


        private void InitializeForm()
        {
            Text =
                IsRetake
                ? "Retake Test"
                : "Test";


            StartPosition =
                FormStartPosition.CenterScreen;


            ClientSize =
                new Size(
                    900,
                    650);


            MinimumSize =
                new Size(
                    850,
                    600);


            BackColor =
                Theme.AppBackground;
        }


        private void InitializeUI()
        {
            lblTitle =
                new Label();


            lblTitle.Text =
                IsRetake
                ? "Retake Test"
                : "Test";


            lblTitle.Dock =
                DockStyle.Top;


            lblTitle.Height =
                75;


            lblTitle.TextAlign =
                ContentAlignment.MiddleCenter;


            lblTitle.Font =
                new Font(
                    "Segoe UI",
                    22,
                    FontStyle.Bold);


            lblTitle.ForeColor =
                Theme.TextPrimary;


            Controls.Add(
                lblTitle);


           

            picTest =
                new PictureBox();


            picTest.Size =
                new Size(
                    200,
                    200);


            picTest.SizeMode =
                PictureBoxSizeMode.Zoom;


            picTest.BackColor =
                Color.Transparent;


            picTest.Location =
                new Point(
                    500,
                    160);


            Controls.Add(
                picTest);


          
          

            pnlTestInfo =
                new Panel();


            pnlTestInfo.Location =
                new Point(
                    30,
                    100);


            pnlTestInfo.Size =
                new Size(
                    400,
                    400);


            pnlTestInfo.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Bottom;


            pnlTestInfo.BackColor =
                Theme.CardBackground;


            Controls.Add(
                pnlTestInfo);


         

            pnlTestResult =
                new Panel();


            pnlTestResult.Location =
                new Point(
                    460,
                    300);


            pnlTestResult.Size =
                new Size(
                    400,
                    200);


            pnlTestResult.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right |
                AnchorStyles.Bottom;


            pnlTestResult.BackColor =
                Theme.CardBackground;


            Controls.Add(
                pnlTestResult);
        }


        private void InitializeTestInfo()
        {
            testInfoControl =
                new TestInfoControl();


            testInfoControl.Size =
                new Size(
                    350,
                    350);


            testInfoControl.Location =
                new Point(
                    25,
                    25);


            testInfoControl.LoadData(
                Mode,
                ApplicationId,
                IsRetake);


            pnlTestInfo.Controls.Add(
                testInfoControl);
        }


        private void InitializeTestResult()
        {
            rbPassed = new RadioButton();
            rbPassed.Text = "Passed";
            rbPassed.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            rbPassed.Location = new Point(40, 90);
            rbPassed.AutoSize = true;
            rbPassed.Checked = true;

            rbFailed = new RadioButton();
            rbFailed.Text = "Failed";
            rbFailed.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            rbFailed.Location = new Point(160, 90);
            rbFailed.AutoSize = true;

            lblNotes = new Label();
            lblNotes.Text = "Notes";
            lblNotes.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblNotes.Location = new Point(40, 120);
            lblNotes.AutoSize = true;

            txtNotes = new TextBox();
            txtNotes.Multiline = true;
            txtNotes.ScrollBars = ScrollBars.Vertical;
            txtNotes.Location = new Point(40, 150);
            txtNotes.Size = new Size(320, 50);

            pnlTestResult.Controls.Add(rbPassed);
            pnlTestResult.Controls.Add(rbFailed);
            pnlTestResult.Controls.Add(lblNotes);
            pnlTestResult.Controls.Add(txtNotes);
        }


        private void InitializeButtons()
        {
            btnCancel =
                new RoundedButton();


            btnCancel.Text =
                "Cancel";


            btnCancel.Size =
                new Size(
                    140,
                    45);


            btnCancel.Location =
                new Point(
                    ClientSize.Width - 400,
                    ClientSize.Height - 65);


            btnCancel.Anchor =
                AnchorStyles.Bottom |
                AnchorStyles.Right;


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
                BtnCancel_Click;


            Controls.Add(
                btnCancel);


            btnSave =
                new RoundedButton();


            btnSave.Text =
                "Save Test";


            btnSave.Size =
                new Size(
                    160,
                    45);


            btnSave.Location =
                new Point(
                    ClientSize.Width - 220,
                    ClientSize.Height - 65);


            btnSave.Anchor =
                AnchorStyles.Bottom |
                AnchorStyles.Right;


            btnSave.NormalColor =
                Color.CornflowerBlue;


            btnSave.HoverColor =
                Color.FromArgb(
                    80,
                    140,
                    220);


            btnSave.PressedColor =
                Color.FromArgb(
                    60,
                    110,
                    190);


            btnSave.Click +=
                BtnSave_Click;


            Controls.Add(
                btnSave);
        }


        private void BtnCancel_Click(
            object sender,
            EventArgs e)
        {
            Close();
        }


        private void BtnSave_Click(
            object sender,
            EventArgs e)
        {
            bool passed =
                rbPassed.Checked;


            if (Test.Add(TestAppoitmentID, passed, txtNotes.Text))
            {


               
               if(!TestAppointment.Lock(TestAppoitmentID))
                {
                      CustomMessageBox.Show("Faild!", "Error in Database: cannot lock the appointment");
                    return;
                }
               
                CustomMessageBox.Show(
                    "Done!",
                    passed
                    ? "Test passed successfully."
                    : "Test result saved as failed.");
                if (passed) { PassedTest++; }
                RefreshData?.Invoke();

                Close();
                return;
            }
            else CustomMessageBox.Show("Faild!", "Error in Database:cannot save in Database");


        }
    }
}