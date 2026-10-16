using BusinessLayer.Models;
using DVLD.Controls;
using DVLD.Presentation.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Forms
{
    public partial class frmLicenses : BaseForm
    {
        private Label lblTitle;
        private SearchGridControl searchGridControl;
        private RoundedButton btnViewDetails;
        private RoundedButton btnToggleStatus;
        private RoundedButton btnDetain;

        public DataGridView dgv;

        private readonly Dictionary<string, string> _columns =
            new Dictionary<string, string>
            {
                { "License ID", "LicenseID" },
                { "Driver ID", "DriverID" },
                { "Issue Date", "IssueDate" },
                { "Is active", "IsActive" }
            };

        public frmLicenses()
        {
            InitializeForm();
            InitializeComponents();
            InitializeLicensesGrid();
        }

        private void InitializeForm()
        {
            Text =
                "Manage Licenses";

            WindowState =
                FormWindowState.Maximized;

            BackColor =
                Theme.AppBackground;
        }

        private void InitializeComponents()
        {
            lblTitle =
                new Label();

            lblTitle.Text =
                "Manage Licenses";

            lblTitle.Font =
                Theme.HeaderFont;

            lblTitle.ForeColor =
                Theme.TextPrimary;

            lblTitle.AutoSize =
                true;

            lblTitle.Location =
                new Point(
                    40,
                    70);

            Controls.Add(
                lblTitle);


            btnViewDetails =
                new RoundedButton();

            btnViewDetails.Text =
                "View Details";

            btnViewDetails.Size =
                new Size(
                    150,
                    45);

            btnViewDetails.Location =
                new Point(
                    40,
                    1000);

            btnViewDetails.NormalColor =
                Color.CornflowerBlue;

            btnViewDetails.HoverColor =
                Color.FromArgb(
                    80,
                    140,
                    220);

            btnViewDetails.PressedColor =
                Color.FromArgb(
                    60,
                    110,
                    190);



            btnViewDetails.Click +=
                BtnViewDetails_Click;

            Controls.Add(
                btnViewDetails);


            btnToggleStatus =
               new RoundedButton();

            btnToggleStatus.Text =
                "";

            btnToggleStatus.Size =
                new Size(
                    150,
                    45);

            btnToggleStatus.Location =
                new Point(
                    340,
                    1000);

            btnToggleStatus.NormalColor =
                Color.CornflowerBlue;

            btnToggleStatus.HoverColor =
                Color.FromArgb(
                    80,
                    140,
                    220);

            btnToggleStatus.PressedColor =
                Color.FromArgb(
                    60,
                    110,
                    190);



            btnToggleStatus.Click +=
                btnToggleStatus_Click;
            Controls.Add(btnToggleStatus);

            btnDetain =
              new RoundedButton();

            btnDetain.Text =
                "Detain";

            btnDetain.Size =
                new Size(
                    150,
                    45);

            btnDetain.Location =
                new Point(
                    640,
                    1000);

            btnDetain.NormalColor =
                Color.CornflowerBlue;

            btnDetain.HoverColor =
                Color.FromArgb(
                    80,
                    140,
                    220);

            btnDetain.PressedColor =
                Color.FromArgb(
                    60,
                    110,
                    190);



            btnDetain.Click +=
                btnDetain_Click;

            Controls.Add(
                btnDetain);
        }

        private void InitializeLicensesGrid()
        {
            searchGridControl =
                new SearchGridControl();

            searchGridControl.Location =
                new Point(
                    40,
                    200);

            searchGridControl.Size =
                new Size(
                    ClientSize.Width - 80,
                    ClientSize.Height - 300);

            searchGridControl.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;

            Controls.Add(
                searchGridControl);


            dgv =
                searchGridControl.Grid;

            dgv.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            searchGridControl.SetBooleanOptions(
             new List<BooleanSearchOption>()
    {
        new BooleanSearchOption("Active", true),
        new BooleanSearchOption("Inactive", false) });
            LoadLicenses();

            dgv.CellClick += dgv_CellClick;
            dgv.CellDoubleClick += dgv_CellDoubleClick;

           


          
        }
        private void dgv_CellDoubleClick(object sender,DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            ShowLicenseDetails();
        }
        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null)
            {

                CustomMessageBox.Show(
                    "Failed",
                    "Please select a license first.");
                return;
            }


            int LicenseID = Convert.ToInt32(dgv.CurrentRow.Cells["LicenseID"].Value);

            if (!Licenses.IsActive(LicenseID)) {
                CustomMessageBox.Show(
                    "Failed",
                    "Please select an active license first.");
                return;
            }

            if (DetainedLicenses.IsLicenseDetained(LicenseID)) {
                CustomMessageBox.Show(
                    "Failed",
                    "This license already detained.");
                return;
            }

            frmDetainLicense frm= new frmDetainLicense(LicenseID);
            frm.ShowDialog();

           




        }
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            bool isActive =
                Convert.ToBoolean(
                    dgv.Rows[e.RowIndex]
                       .Cells["IsActive"]
                       .Value);

            btnToggleStatus.Text =
                isActive
                ? "Deactivate"
                : "Activate";
        }
        private void LoadLicenses()
        {
            DataTable dt = Licenses_View.GetAlldata();
               

            searchGridControl.LoadData(
                dt,
                _columns);

            dgv =
                searchGridControl.Grid;
        }

        private void BtnViewDetails_Click(
            object sender,
            EventArgs e)
        {
            ShowLicenseDetails();
        }

        private void ShowLicenseDetails()
        {

            if (dgv.CurrentRow == null)
            {
                CustomMessageBox.Show(
                    "Failed",
                    "Please select a license first.");

                return;
            }

            int LicenseID =
                Convert.ToInt32(
                    dgv.CurrentRow.Cells["LicenseID"].Value);


            frmLicenseDetails frm =
                new frmLicenseDetails(LicenseID);

            frm.ShowDialog();

        }
        private void btnToggleStatus_Click(object sender, EventArgs e) {

            if (dgv.CurrentRow == null)
            {
                return;
            }



            int LicenseID =Convert.ToInt32(dgv.CurrentRow.Cells["LicenseID"].Value);

            bool isActive = Convert.ToBoolean(dgv.CurrentRow.Cells["IsActive"].Value);

            if (isActive)
            {

                if (Licenses.Deactivate(LicenseID))
                {
                    CustomMessageBox.Show("Success!", "License  deactivated!");
                    LoadLicenses();
                    return;

                }
                CustomMessageBox.Show("Faild!", "Error in Database!"); return;

            }
            if (Licenses.Activate(LicenseID))
            {
                CustomMessageBox.Show("Success!", "License  activated!");
                LoadLicenses();
                return;

            }
            CustomMessageBox.Show("Faild!", "Error in Database!"); return;

        }
    }
}