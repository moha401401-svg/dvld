using DVLD.Controls;
using DVLD.Presentation.UI;
using System;
using System.Drawing;
using System.Windows.Forms;
using DVLD.Forms.Applications;
using BusinessLayer.Models;
namespace DVLD.Forms
{
    public class frmAppointment : BaseForm
    {
        private Label lblTitle;
        public Action RefreshData;
        private Panel pnlTestInfo;
        private Panel pnlAppointment;
        private PictureBox picTest;
        public int ApplicationId
        {
            get;
            private set;
        }
        private TestInfoControl testInfoControl;

        private Label lblAppointmentDate;
        private DateTimePicker dtpAppointmentDate;

        private RoundedButton btnCancel;
        private RoundedButton btnRegister;


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

        public DateTime AppointmentDate
        {
            get
            {
                return dtpAppointmentDate.Value.Date;
            }
        }


        public frmAppointment(TestMode mode, bool isRetake, int applicationId)
        {
            Mode = mode;
            IsRetake = isRetake;
            ApplicationId = applicationId;

            InitializeForm();
            InitializeUI();
            InitializeTestInfo();
            InitializeAppointmentDate();
            InitializeButtons();
        }


        private void InitializeForm()
        {
            Text =
                IsRetake
                ? "Retake Test Appointment"
                : "Test Appointment";


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
                ? "Retake Test Appointment"
                : "Test Appointment";


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
                new Size(200, 200);

            picTest.SizeMode =
                PictureBoxSizeMode.Zoom;

            picTest.BackColor =
                Color.Transparent;

            picTest.Location =
                new Point(
                   500 ,
                    160);

            Controls.Add(picTest);

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


            pnlAppointment =
                new Panel();


            pnlAppointment.Location =
                new Point(
                    460,
                    300);


            pnlAppointment.Size =
                new Size(
                    400,
                    200);


            pnlAppointment.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right |
                AnchorStyles.Bottom;


            pnlAppointment.BackColor =
                Theme.CardBackground;


            Controls.Add(
                pnlAppointment);
        }


        private void InitializeTestInfo()
        {
            testInfoControl =
                new TestInfoControl();

            testInfoControl.Size =
                new Size(350, 350);

            testInfoControl.Location =
                new Point(25, 80);
            testInfoControl.LoadData(
        Mode,
        ApplicationId,
        IsRetake);

            pnlTestInfo.Controls.Add(
                testInfoControl);
        }


        private void InitializeAppointmentDate()
        {
            lblAppointmentDate =
                new Label();


            lblAppointmentDate.Text =
                "Appointment Date";


            lblAppointmentDate.Font =
                new Font(
                    "Segoe UI",
                    14,
                    FontStyle.Bold);


            lblAppointmentDate.ForeColor =
                Theme.TextPrimary;


            lblAppointmentDate.AutoSize =
                true;


            lblAppointmentDate.Location =
                new Point(
                    40,
                    70);


            pnlAppointment.Controls.Add(
                lblAppointmentDate);


            dtpAppointmentDate =
                new DateTimePicker();


            dtpAppointmentDate.Format =
                DateTimePickerFormat.Custom;


            dtpAppointmentDate.CustomFormat =
                "dd/MM/yyyy";


            dtpAppointmentDate.Width =
                280;


            dtpAppointmentDate.Height =
                40;


            dtpAppointmentDate.Location =
                new Point(
                    40,
                    115);


            // أقل موعد بعد أسبوع من النهارده
            dtpAppointmentDate.MinDate =
                DateTime.Today.AddDays(7);


            // آخر يوم في الشهر القادم
            dtpAppointmentDate.MaxDate =
                new DateTime(
                    DateTime.Today.Year,
                    DateTime.Today.Month,
                    1)
                .AddMonths(2)
                .AddDays(-1);


            // القيمة الافتراضية
            dtpAppointmentDate.Value =
                dtpAppointmentDate.MinDate;


            pnlAppointment.Controls.Add(
                dtpAppointmentDate);
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
                    ClientSize.Width -400,
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


            btnRegister =
                new RoundedButton();


            btnRegister.Text =
                "Register Appointment";


            btnRegister.Size =
                new Size(
                    190,
                    45);


            btnRegister.Location =
                new Point(
                    ClientSize.Width - 200,
                    ClientSize.Height - 65);


            btnRegister.Anchor =
                AnchorStyles.Bottom |
                AnchorStyles.Right;


            btnRegister.NormalColor =
                Color.CornflowerBlue;


            btnRegister.HoverColor =
                Color.FromArgb(
                    80,
                    140,
                    220);


            btnRegister.PressedColor =
                Color.FromArgb(
                    60,
                    110,
                    190);


            btnRegister.Click +=
                BtnRegister_Click;


            Controls.Add(
                btnRegister);
        }


        private void BtnCancel_Click(
            object sender,
            EventArgs e)
        {
            Close();
        }


        private void BtnRegister_Click(
            object sender,
            EventArgs e)
        {
           if( TestAppointment.Add((int)Mode, AppointmentDate, ApplicationId))
            {
                CustomMessageBox.Show("Done!", "Appointment added successfully");
            }
           else CustomMessageBox.Show("Faild!", "Error in Database");
            RefreshData?.Invoke();
           Close();
        }
    }
}