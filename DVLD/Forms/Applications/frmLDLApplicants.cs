using BusinessLayer.Models;
using DVLD.Controls;
using DVLD.Forms.Types;
using DVLD.Presentation.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Forms.Applications
{
    public partial class frmLDLApplicants : BaseForm
    {

        public Action RefreshData;

        private Label lblTitle;
        private RoundedButton btnEdit;
        private RoundedButton btnCancel;


        private readonly Dictionary<string, string> _columns = new Dictionary<string, string> { { "L.D.L.Application ID", "LocalDrivingLicenseApplicationID" },
                                                                                                 { "Class Name", "ClassName" },{"Full Name" ,"FullName"},{ "Application Date","ApplicationDate"},
                                                                                                { "Status","Status"},{ "PassedTestCount","PassedTestCount"} };
        public DataGridView dgv;
        public frmLDLApplicants()
        {
            InitializeForm();
            InitializeComponents();
            InitializeApplicationGrid();
            RefreshData = LoadApplications;

        }

        private void InitializeComponents()
        {


            lblTitle =
                new Label();


            lblTitle.Text =
                " Manage Apllications ";


            lblTitle.Font =
                Theme.HeaderFont;


            lblTitle.ForeColor =
                Theme.TextPrimary;


            lblTitle.AutoSize =
                true;


            lblTitle.Location =
                new Point(40, 70);


            Controls.Add(lblTitle);






            btnEdit =
                CreateButton("Tests");




            btnEdit.Location =
                new Point(40, 970);


            Controls.Add(btnEdit);

            btnEdit.Click +=
                BtnEdit_Click;



            btnCancel =
               CreateButton("Cancel Application");




            btnCancel.Location =
                new Point(300, 970);


            Controls.Add(btnCancel);

            btnCancel.Click +=
                BtnCancel_Click;


        }

        private void InitializeApplicationGrid()
        {

            searchGridControl1 = new SearchGridControl();


            searchGridControl1.Location = new Point(40, 200);
            searchGridControl1.Size = new Size(2200, 700);
            Controls.Add(searchGridControl1);

            dgv = searchGridControl1.Grid;

            dgv.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgv.Size = new Size(2000, 700);

            LoadApplications();

        }
        private void LoadApplications()
        {

            searchGridControl1.LoadData(LDLApplications_View.GetData(), _columns);
            dgv = searchGridControl1.Grid;

        }
        private RoundedButton CreateButton(string text)
        {

            RoundedButton btn =
                new RoundedButton();


            btn.Text =
                text;


            btn.Size =
                new Size(150, 45);


            return btn;
        }

        private void InitializeForm()
        {
            WindowState =
                FormWindowState.Maximized;


            BackColor =
                Theme.AppBackground;


            Text =
                "Manage Applicants";
        }


        private void BtnEdit_Click(object sender, EventArgs e)
        {
            string NationalNo = dgv.CurrentRow.Cells["NationalNo"].Value.ToString();
            int LDLID = Convert.ToInt32(dgv.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value);
            int PassedTests = Convert.ToInt32(dgv.CurrentRow.Cells["PassedTestCount"].Value);

            frmTestMenu frm = new frmTestMenu(NationalNo, LDLID, PassedTests);
            frm.RefreshData = RefreshData;
            frm.ShowDialog();
            LoadApplications();



        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            int LDLID = Convert.ToInt32(dgv.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value);
            int AppID = LDLApplications.GetApplicationID(LDLID);
            if (BusinessLayer.Models.Applications.Cancel(AppID))
            {
                CustomMessageBox.Show("Success", "Application Cancelled Successfully");
                LoadApplications();
            }
            else
            {
                CustomMessageBox.Show("Error", "Failed to Cancel Application as it has refrences in Database");
            }
        }
    }
}
