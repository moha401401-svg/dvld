using BusinessLayer;
using BusinessLayer.Models;
using DVLD.Business.Models;
using DVLD.Controls;
using DVLD.Presentation.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Forms
{
    public partial class frmUsers : BaseForm
    {
        public Action RefreshUsers;
        private Label lblTitle;

       Dictionary<string,string>_columns= new Dictionary<string, string>()
                {
            { "User ID", "UserID" },
            { "Person ID", "PersonID" },
            { "UserName", "UserName" },
            { "Active", "IsActive" }
                };

        private DataGridView dgvUsers;

        private SearchGridControl searchGridControl;
        private RoundedButton btnAdd;
        private RoundedButton btnDelete;
        private RoundedButton btnToggle;
        private RoundedButton btnPermissions;
        private RoundedButton btnDetails;



        public frmUsers()
        {
            InitializeComponent();

            InitializeForm();

            InitializeComponents();
            RefreshUsers = LoadUsersGrid;
            LoadUsersGrid();
        }



        private void InitializeForm()
        {

            WindowState =
                FormWindowState.Maximized;


            BackColor =
                Theme.AppBackground;


            Text =
                "Manage Users";

        }





        private void InitializeComponents()
        {


            lblTitle =
                new Label();


            lblTitle.Text =
                "Manage Users";


            lblTitle.Font =
                Theme.HeaderFont;


            lblTitle.ForeColor =
                Theme.TextPrimary;


            lblTitle.AutoSize =
                true;


            lblTitle.Location =
                new Point(40, 70);


            Controls.Add(lblTitle);






            btnAdd =
                CreateButton("Add");

            btnDelete =
                CreateButton("Delete");

            btnToggle =
                CreateButton("Activate");

            btnPermissions =
                CreateButton("Permissions");

            btnDetails =
                CreateButton("Show Details");







            btnAdd.Location =
                new Point(40, 970);
            btnDelete.Location =
                new Point(240, 970);


            btnToggle.Location =
                new Point(440, 970);


            btnPermissions.Location =
                new Point(640, 970);


            btnDetails.Location =
                new Point(840, 970);






            Controls.Add(btnAdd);

            Controls.Add(btnDelete);

            Controls.Add(btnToggle);

            Controls.Add(btnPermissions);

            Controls.Add(btnDetails);






            btnAdd.Click +=
                BtnAdd_Click;


            btnDelete.Click +=
                BtnDelete_Click;


            btnToggle.Click +=
                BtnToggle_Click;


            btnPermissions.Click +=
                BtnPermissions_Click;


            btnDetails.Click +=
                BtnDetails_Click;


        }




        private void LoadUsersGrid()
        {
            if (searchGridControl == null)
            {
                searchGridControl = new SearchGridControl();

                searchGridControl.Location = new Point(40, 200);

                searchGridControl.Size = new Size(2200, 700);

                Controls.Add(searchGridControl);


                

            }

            searchGridControl.LoadData(
                Users.GetAll(), _columns);
                

            searchGridControl.SetBooleanOptions(
             new List<BooleanSearchOption>()
    {
        new BooleanSearchOption("Active", true),
        new BooleanSearchOption("Inactive", false) });

            dgvUsers = searchGridControl.Grid;
            dgvUsers.Size = new Size(2200, 700);

            dgvUsers.AutoSizeColumnsMode =
                  DataGridViewAutoSizeColumnsMode.Fill;


            dgvUsers.CellClick += DgvUsers_CellClick;
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
        private void DgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;


            DataGridViewRow row =
                dgvUsers.Rows[e.RowIndex];


            bool isActive =
                Convert.ToBoolean(
                    row.Cells["IsActive"].Value
                );


            if (isActive)
            {
                btnToggle.Text = "Deactivate";
            }
            else
            {
                btnToggle.Text = "Activate";
            }
        }






        private void DgvUsers_SelectionChanged(
            object sender,
            EventArgs e)
        {

            if (dgvUsers.CurrentRow == null)
                return;


            bool active =
                Convert.ToBoolean(
                    dgvUsers.CurrentRow
                    .Cells["IsActive"]
                    .Value);



            btnToggle.Text =
                active ?
                "Deactivate" :
                "Activate";

        }








        private int GetSelectedID()
        {

            if (dgvUsers.CurrentRow == null)
                return -1;


            return Convert.ToInt32(
                dgvUsers.CurrentRow
                .Cells["UserID"]
                .Value);

        }




        private void DgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnDetails_Click(sender, e);
        }


        private void BtnAdd_Click(
            object sender,
            EventArgs e)
        {

            frmAddUser frm = new frmAddUser();
            frm.RefreshUsers = RefreshUsers;
            frm.ShowDialog();

        }




        private void BtnDelete_Click(
            object sender,
            EventArgs e)
        {

            if (dgvUsers.CurrentRow == null) return;
            DialogResult result =
            MessageBox.Show(
                "Are you sure you want to delete this user?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
    );


            if (result == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgvUsers.CurrentRow.Cells[0].Value);
                if (Users.DeleteUser(id)) {
                    LoadUsersGrid();
                    MessageBox.Show(
                "Deleted Successfully",
                "Done",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information); LoadUsersGrid(); return;}

               
                MessageBox.Show(
                "Cannot delete becuase this user has refrences",
                "Faild",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
            
          

        }




        private void BtnToggle_Click(
            object sender,
            EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvUsers.CurrentRow.Cells[0].Value);
            string username = dgvUsers.CurrentRow.Cells["UserName"].Value.ToString();
            if (!(bool)dgvUsers.CurrentRow.Cells["IsActive"].Value) {

                if (Users.ActiveUser(id)) { CustomMessageBox.Show("Done!", $"{username} active now"); }
                else CustomMessageBox.Show("Faild!", "Error in Database");


            }
            else
            {
                if (Users.DisableUser(id)) { CustomMessageBox.Show("Done!", $"{username} inactive now"); }
                else CustomMessageBox.Show("Faild!", "Error in Database");
            }
            LoadUsersGrid();



        }




        private void BtnPermissions_Click(
            object sender,
            EventArgs e)
        {

           int permissions= (int)dgvUsers.CurrentRow.Cells["UserPermissions"].Value;
            int id = Convert.ToInt32(dgvUsers.CurrentRow.Cells[0].Value);
           
            frmPermissions frm = new frmPermissions((enPermissions)permissions);
            frm.RefreshData= RefreshUsers;

         
            if (frm.ShowDialog() != DialogResult.OK)
            {
                return; 
            }
            if (frm.PermissionValue == permissions) { return; }
           if( Users.UpdateUserPermissions(id, frm.PermissionValue))
            {
                CustomMessageBox.Show("Success!", "User permissions updated successfully!");
                LoadUsersGrid();


                return;
            }
            CustomMessageBox.Show("Faild!", "The current user permissins cannot be updated by itself");

        }




        private void BtnDetails_Click(
            object sender,
            EventArgs e)
        {

            int id =
                GetSelectedID();


            if (id == -1)
                return;


            frmUserDetails frm =
                new frmUserDetails(id);


            frm.ShowDialog();

        }

    }
}