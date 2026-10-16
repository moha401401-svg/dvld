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
    public class frmManageDrivers : BaseForm
    {
        private Label lblTitle;
        private SearchGridControl searchGridControl;
        private RoundedButton btnViewDetails;

        public DataGridView dgv;

        private readonly Dictionary<string, string> _columns =
            new Dictionary<string, string>
            {
                { "Driver ID", "DriverID" },
                { "Person ID", "PersonID" },
                { "National No", "NationalNo" },
                { "Full Name", "FullName" },
                { "Created Date", "CreatedDate" }
            };

        public frmManageDrivers()
        {
            InitializeForm();
            InitializeComponents();
            InitializeDriversGrid();
        }

        private void InitializeForm()
        {
            Text =
                "Manage Drivers";

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
                "Manage Drivers";

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
        }

        private void InitializeDriversGrid()
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


            LoadDrivers();
        }

        private void LoadDrivers()
        {
            DataTable dt =
                Drivers_View.GetData();

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
            if (dgv.CurrentRow == null)
            {
                CustomMessageBox.Show(
                    "Failed",
                    "Please select a driver first.");

                return;
            }

            int driverID =
                Convert.ToInt32(
                    dgv.CurrentRow.Cells["DriverID"].Value);

            int PersonID = Convert.ToInt32(dgv.CurrentRow.Cells["PersonID"].Value);
            frmDriverDetails frm =
                new frmDriverDetails(driverID,PersonID);

            frm.ShowDialog();
        }
    }
}