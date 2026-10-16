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
namespace DVLD.Forms
{
    public partial class frmApplicationsTypes : BaseForm
    {
        public Action RefreshFees;
        private Label lblTitle;
        private RoundedButton btnEdit;
        

        private readonly Dictionary<string, string> _columns = new Dictionary<string, string> { { "ApplicationType ID", "ApplicationTypeID" },
                                                                                                 { "Application Type Title", "ApplicationTypeTitle" } };
        public DataGridView dgv;
        public frmApplicationsTypes()
        {
            InitializeComponent();
            InitializeForm();
            InitializeComponents();
            RefreshFees = LoadApplications;
            InitializeApplicationGrid();


        }

        private void InitializeForm()
        {
            WindowState =
                FormWindowState.Maximized;


            BackColor =
                Theme.AppBackground;


            Text =
                "Manage Types";
        }
        private void LoadApplications() {

            searchGridControl1.LoadData(ApplicationTypes.GetAll(),_columns);
            dgv = searchGridControl1.Grid;
        
        }

        private void InitializeComponents()
        {


            lblTitle =
                new Label();


            lblTitle.Text =
                "Apllications Types";


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
                CreateButton("Edit");

          








            btnEdit.Location =
                new Point(40, 970);
          





            Controls.Add(btnEdit);

           






            btnEdit.Click +=
                BtnEdit_Click;


            


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

        private void InitializeApplicationGrid() {
           

            searchGridControl1.Location = new Point(40, 200);
            searchGridControl1.Size = new Size(2200, 700);

            Controls.Add(searchGridControl1);

            dgv = searchGridControl1.Grid;

            dgv.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgv.Size = new Size(2200, 700);
            LoadApplications();

        }
        private void BtnEdit_Click(object sender, EventArgs e) { 

            if(dgv.CurrentRow==null) { CustomMessageBox.Show("Cannot load", "Please select a type"); return;  }
            string title = dgv.CurrentRow.Cells["ApplicationTypeTitle"].Value.ToString();
            int fees = Convert.ToInt32(  dgv.CurrentRow.Cells["ApplicationFees"].Value);
            int id = Convert.ToInt32(dgv.CurrentRow.Cells[0].Value);


            frmEditFees frm = new frmEditFees(title,"",fees,id);
            frm.RefreshFees = RefreshFees;
            frm.ShowDialog();
           
        
        
        }


    }



}
