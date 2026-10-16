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
    public class frmManageDetainedLicenses : BaseForm
    {
        private Label lblTitle;

        private SearchGridControl searchGridControl;

        private RoundedButton btnRelease;

        private DataGridView dgv;



        private readonly Dictionary<string, string> _columns =
            new Dictionary<string, string>
            {
                { "Detain ID","DetainID"},
                { "License ID","LicenseID"},
                { "Detain Date","DetainDate"},
                { "Fine Fees","FineFees"},
                { "Released","IsReleased"}
            };



        public frmManageDetainedLicenses()
        {
            InitializeForm();

            InitializeComponents();

            InitializeGrid();
        }



        private void InitializeForm()
        {
            Text =
                "Manage Detained Licenses";

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
                "Manage Detained Licenses";

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





            btnRelease =
                new RoundedButton();

            btnRelease.Text =
                "Release";

            btnRelease.Size =
                new Size(
                    150,
                    45);

            btnRelease.Location =
                new Point(
                    40,
                    1000);

            btnRelease.NormalColor =
                Color.CornflowerBlue;

            btnRelease.HoverColor =
                Color.FromArgb(
                    80,
                    140,
                    220);

            btnRelease.PressedColor =
                Color.FromArgb(
                    60,
                    110,
                    190);

            btnRelease.Click +=
                BtnRelease_Click;

            Controls.Add(
                btnRelease);
        }




        private void InitializeGrid()
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

            searchGridControl.SetBooleanOptions(
                new List<BooleanSearchOption> { new BooleanSearchOption(Text = "Released", true), new BooleanSearchOption(Text = "Detained", false) });
                


            dgv =
                searchGridControl.Grid;

            dgv.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;



            LoadData();
        }




        private void LoadData()
        {
            DataTable dt =
                DetainedLicenses.GetDetainedLicenses();

            searchGridControl.LoadData(
                dt,
                _columns);

            dgv =
                searchGridControl.Grid;
        }




        private void BtnRelease_Click(
            object sender,
            EventArgs e)
        {

            if (dgv.CurrentRow == null)
            {
                CustomMessageBox.Show(
                    "Failed",
                    "Please select a detained license.");

                return;
            }


            int detainID =
                Convert.ToInt32(
                    dgv.CurrentRow.Cells["DetainID"].Value);

            int LicenseID =
               Convert.ToInt32(
                   dgv.CurrentRow.Cells["LicenseID"].Value);

            if (DetainedLicenses.IsLicenseDetained(LicenseID))
            {
                frmReleaseLicense frm = new frmReleaseLicense(detainID);
                frm.ShowDialog();
                LoadData();
                return;
            }

            CustomMessageBox.Show(
                   "Failed",
                   "License has been released before.");

            return;





            
        }
    }
}