
using BusinessLayer.Models;
using DVLD.Business;
using DVLD.Forms.Applications;
using DVLD.Presentation.UI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Controls
{
    public class TestInfoControl : UserControl
    {
        private Label lblHeader;

        private Label lblAppID;
        private Label lblAppIDVal;

        private Label lblTestTypeTitle;
        private Label lblTestTypeValue;

        private Label lblDescriptionTitle;
        private Label lblDescriptionValue;

        private Label lblFeesTitle;
        private Label lblFeesValue;

        private Label lblRetakeFeesTitle;
        private Label lblRetakeFeesValue;

        private Label lblTotalFeesTitle;
        private Label lblTotalFeesValue;

        private TestMode mode;

        private string testName = "";
        private string description = "";

        private double fees;
        private double retakeFees = 0;

        private bool isRetake;

        public TestMode Mode
        {
            get => mode;
            private set => mode = value;
        }

        public string TestName
        {
            get => testName;

            private set
            {
                testName = value;
                UpdateUI();
            }
        }

        public string Description
        {
            get => description;

            private set
            {
                description = value;
                UpdateUI();
            }
        }

        public double Fees
        {
            get => fees;

            private set
            {
                fees = value;
                UpdateUI();
            }
        }

        public double RetakeFees
        {
            get => retakeFees;

            private set
            {
                retakeFees = value;
                UpdateUI();
            }
        }

        public bool IsRetake
        {
            get => isRetake;

            private set
            {
                isRetake = value;
                UpdateUI();
            }
        }

        public double TotalFees
        {
            get
            {
                return Fees +
                    (IsRetake ? RetakeFees : 0);
            }
        }

        public TestInfoControl()
        {
            InitializeControl();
            InitializeUI();
            UpdateUI();
        }

        private void InitializeControl()
        {
            Size =
                new Size(
                    350,
                    430);

            BackColor =
                Theme.CardBackground;

            Padding =
                new Padding(18);

            DoubleBuffered =
                true;
        }

        private void InitializeUI()
        {
            lblHeader =
                CreateHeaderLabel(
                    "🧪  Test Information");

            lblHeader.Location =
                new Point(
                    18,
                    12);

            lblHeader.Size =
                new Size(
                    Width - 36,
                    35);

            Controls.Add(
                lblHeader);


            // =====================================================
            // Application ID
            // =====================================================

            lblAppID =
                CreateTitleLabel(
                    "🆔  Application ID");

            lblAppIDVal =
                CreateValueLabel();

            AddRow(
                lblAppID,
                lblAppIDVal,
                58);


            // =====================================================
            // Test Type
            // =====================================================

            lblTestTypeTitle =
                CreateTitleLabel(
                    "🧪  Test Type");

            lblTestTypeValue =
                CreateValueLabel();

            AddRow(
                lblTestTypeTitle,
                lblTestTypeValue,
                95);


            // =====================================================
            // Description
            // =====================================================

            lblDescriptionTitle =
                CreateTitleLabel(
                    "📝  Description");

            lblDescriptionValue =
                CreateValueLabel();

            lblDescriptionValue.Height =
                55;

            lblDescriptionValue.TextAlign =
                ContentAlignment.TopLeft;

            AddRow(
                lblDescriptionTitle,
                lblDescriptionValue,
                132);


            // =====================================================
            // Fees
            // =====================================================

            lblFeesTitle =
                CreateTitleLabel(
                    "💵  Fees");

            lblFeesValue =
                CreateValueLabel();

            AddRow(
                lblFeesTitle,
                lblFeesValue,
                205);


            // =====================================================
            // Retake Fees
            // =====================================================

            lblRetakeFeesTitle =
                CreateTitleLabel(
                    "🔄  Retake Fees");

            lblRetakeFeesValue =
                CreateValueLabel();

            AddRow(
                lblRetakeFeesTitle,
                lblRetakeFeesValue,
                245);


            // =====================================================
            // Total Fees
            // =====================================================

            lblTotalFeesTitle =
                CreateTitleLabel(
                    "💰  Total Fees");

            lblTotalFeesValue =
                CreateValueLabel();

            lblTotalFeesTitle.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold);

            lblTotalFeesValue.Font =
                new Font(
                    "Segoe UI",
                    11,
                    FontStyle.Bold);

            AddRow(
                lblTotalFeesTitle,
                lblTotalFeesValue,
                285);
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
                    15,
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
                    145,
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
                    155,
                    28);

            label.TextAlign =
                ContentAlignment.MiddleLeft;

            return label;
        }

        private void AddRow(
            Label title,
            Label value,
            int y)
        {
            title.Location =
                new Point(
                    18,
                    y);

            value.Location =
                new Point(
                    163,
                    y);

            Controls.Add(title);
            Controls.Add(value);
        }

        // =========================================================
        // Load Test Information
        // =========================================================

        public void LoadData(
            TestMode mode,
            int applicationId,
            bool isRetake)
        {
            Mode =
                mode;

            IsRetake =
                isRetake;

            lblAppIDVal.Text =
                applicationId.ToString();

            int testTypeId =
                GetTestTypeId(mode);

            TestName =
                TestTypes.GetName(
                    testTypeId);

            Description =
                TestTypes.GetDes(
                    testTypeId);

            Fees =
                TestTypes.GetFees(
                    testTypeId);

            if (IsRetake)
            {
                RetakeFees = 5;
            }
            else
            {
                RetakeFees = 0;
            }

            UpdateUI();
        }

        private int GetTestTypeId(
            TestMode mode)
        {
            switch (mode)
            {
                case TestMode.Test1:
                    return 1;

                case TestMode.Test2:
                    return 2;

                case TestMode.Test3:
                    return 3;

                default:
                    throw new ArgumentException(
                        "Invalid TestMode");
            }
        }

        private void UpdateUI()
        {
            if (lblTestTypeValue == null)
                return;

            lblAppIDVal.Text =
                lblAppIDVal.Text;

            lblTestTypeValue.Text =
                TestName;

            lblDescriptionValue.Text =
                Description;

            lblFeesValue.Text =
                Fees.ToString("0.00");

            lblRetakeFeesValue.Text =
                RetakeFees.ToString("0.00");

            lblTotalFeesValue.Text =
                TotalFees.ToString("0.00");

            lblRetakeFeesTitle.Visible =
                IsRetake;

            lblRetakeFeesValue.Visible =
                IsRetake;
        }

        protected override void OnResize(
            EventArgs e)
        {
            base.OnResize(e);

            if (lblHeader != null)
            {
                lblHeader.Width =
                    Width - 36;
            }
        }
    }
}

