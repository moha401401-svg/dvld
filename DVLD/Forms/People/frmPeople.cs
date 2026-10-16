using DVLD.Business.Models;
using DVLD.Controls;
using DVLD.Presentation.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Forms
{
    public partial class frmPeople : BaseForm
    {
        private Label lblTitle;

      
        private SearchGridControl peopleGrid;
       
        private DataGridView dgvPeople;
        private RoundedButton btnAdd;
        private RoundedButton btnEdit;
        private RoundedButton btnDelete;
        private RoundedButton btnProfile;

        private DataTable peopleTable;
        private readonly Dictionary<string, string> _columns =
    new Dictionary<string, string>()
{
            {"Person ID","PersonID"},
            {"National No","NationalNo"},
            {"First Name","FirstName"},
            {"Second Name","SecondName"},
            {"Third Name","ThirdName"},
            {"Last Name","LastName"},
            {"Phone","Phone"},
            {"Email","Email"}
};

        public frmPeople()
        {
            InitializeComponent();
         

            InitializeForm();
            InitializeComponents();
            InitializePeopleGrid();
            
        }
        private void RefreshPeople()
        {
            peopleGrid.LoadData(
                People.GetAll(),
                _columns);
        }
      

        private void InitializePeopleGrid()
        {
            peopleGrid = new SearchGridControl();

            peopleGrid.Location = new Point(40, 200);
            peopleGrid.Size= new Size(2200, 700);

            Controls.Add(peopleGrid);

            dgvPeople = peopleGrid.Grid;

            dgvPeople.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvPeople.Size = new Size(2200, 700);

            RefreshPeople();



        }
        private void InitializeForm()
        {
            WindowState =
                FormWindowState.Maximized;

            BackColor =
                Theme.AppBackground;

            Resize += FrmPeople_Resize;
        }


        private void InitializeComponents()
        {
            lblTitle = new Label();

            lblTitle.Text =
                "People Management";

            lblTitle.Font =
                Theme.HeaderFont;

            lblTitle.ForeColor =
                Theme.TextPrimary;

            lblTitle.AutoSize = true;

            lblTitle.Location =
                new Point(40, 70);

            Controls.Add(lblTitle);



            



           



            btnAdd =
                CreateButton("Add Person");

            btnEdit =
                CreateButton("Edit");

            btnDelete =
                CreateButton("Delete");

            btnProfile =
                CreateButton("Show Profile");



            Controls.Add(btnAdd);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Controls.Add(btnProfile);



            btnAdd.Click +=
                BtnAdd_Click;

            btnEdit.Click +=
                BtnEdit_Click;

            btnDelete.Click +=
                BtnDelete_Click;

            btnProfile.Click +=
                BtnProfile_Click;


            SetButtonsLocation();
        }



        private RoundedButton CreateButton(string text)
        {
            RoundedButton btn =
                new RoundedButton();

            btn.Text = text;

            btn.Size =
                new Size(130, 45);

            return btn;
        }



       



       



        private void SetButtonsLocation()
        {
            int y =
                ClientSize.Height - 90;


            btnAdd.Location =
                new Point(40, y);


            btnEdit.Location =
                new Point(190, y);


            btnDelete.Location =
                new Point(340, y);


            btnProfile.Location =
                new Point(490, y);
        }



        private void FrmPeople_Resize(
            object sender,
            EventArgs e)
        {
            if (dgvPeople == null)
                return;


            dgvPeople.Size =
                new Size(
                    ClientSize.Width - 80,
                    ClientSize.Height - 330
                );


            SetButtonsLocation();
        }



        private void BtnAdd_Click(
            object sender,
            EventArgs e)
        {
            frmAddEditPerson per = new frmAddEditPerson();
            per.Back += FromPerson_Back;
            per.ShowDialog();

        }



        private void BtnEdit_Click(
            object sender,
            EventArgs e)
        {
            if (dgvPeople.CurrentRow == null) { CustomMessageBox.Show("Faild!", "Please, Select a Person First"); return;  }
            int id = (int)dgvPeople.CurrentRow.Cells["PersonID"].Value;
            frmAddEditPerson per= new frmAddEditPerson(id);
            per.Back += FromPerson_Back;
            per.ShowDialog();

        }

        private void FromPerson_Back(object sender)
        {
            RefreshPeople();
        }

       
            private void BtnDelete_Click(
    object sender,
    EventArgs e)
        {
            if (dgvPeople.CurrentRow == null)
            {
                CustomMessageBox.Show(
                    "Delete",
                    "Please select a person first."
                );

                return;
            }


            int personID =
                Convert.ToInt32(
                    dgvPeople.CurrentRow.Cells["PersonID"].Value
                );


            DialogResult result =
                MessageBox.Show(
                    $"Are you sure you want to delete Person ID : {personID} ?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );


            if (result == DialogResult.Yes)
            {
           
                
               
                if(!People.del(personID))
                {
                    MessageBox.Show("Cannot Delete becuase this person has refrences","Faild!",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                RefreshPeople();
            }
        }
    



        private void BtnProfile_Click(
            object sender,
            EventArgs e)
        {
            ShowProfile();
        }



        private void DgvPeople_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;


            ShowProfile();
        }



        private void ShowProfile()
        {
            if (dgvPeople.CurrentRow == null)
                return;


            int personID =
                Convert.ToInt32(
                    dgvPeople.CurrentRow.Cells["PersonID"].Value
                );

                frmPersonDetails per= new frmPersonDetails(personID);
            per.ShowDialog();

        }
    }
}