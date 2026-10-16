using BusinessLayer.Models;
using DVLD.Business.Models;
using DVLD.Controls;
using DVLD.Presentation.UI;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Forms
{
    public partial class frmAddUser : BaseForm
    {
        private int UserPermissions = 0;
        private Panel pnlPerson;
        private Panel pnlUser;
        public Action RefreshUsers;
        private DataTable _peopleTable;
        private PersonInfoCard personCard;


        private RoundedTextBox txtSearch;
        private ComboBox cmbSearchType;
        private DataGridView dgvPeople;


        private RoundedTextBox txtUsername;
        private RoundedTextBox txtPassword;
        private RoundedTextBox txtConfirmPassword;


        private CheckBox chkActive;


        private RoundedButton btnNext;
        private RoundedButton btnBack;
        private RoundedButton btnSave;
        private RoundedButton btnPermissions;



        private int SelectedPersonID = -1;



        public frmAddUser()
        {
            InitializeComponent();

            InitializeForm();

            InitializeComponents();
           

        }


        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            RoundedTextBox txt = sender as RoundedTextBox;

            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.State = ValidationState.Invalid;
                txt.ValidationMessage = "Password is required.";
                return;
            }

            if (txt.Text.Length < txt.MinLength)
            {
                txt.State = ValidationState.Invalid;
                txt.ValidationMessage = "Password must be at least 8 characters.";
                return;
            }

            if (txt.Text.Length > txt.MaxLength)
            {
                txt.State = ValidationState.Invalid;
                txt.ValidationMessage = "Password must not exceed 20 characters.";
                return;
            }

            txt.State = ValidationState.Valid;
            txt.ValidationMessage = "";
        }
        private void TxtUsername_TextChanged(object sender, EventArgs e)
        {
            RoundedTextBox txt = sender as RoundedTextBox;


            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.State = ValidationState.Invalid;
                txt.ValidationMessage = "Username is required";
                return;
            }


            if (Users.IsUserExist(txt.Text))
            {
                txt.State = ValidationState.Invalid;
                txt.ValidationMessage = "Username already exist";
            }
            else
            {
                txt.State = ValidationState.Valid;
                txt.ValidationMessage = "";
            }
        }

        private void InitializeForm()
        {

            Size =
                new Size(1300, 650);


            StartPosition =
                FormStartPosition.CenterScreen;


            Text =
                "Add User";


            BackColor =
                Theme.AppBackground;

        }





        private void InitializeComponents()
        {

            CreatePersonPanel();

            CreateUserPanel();


            Controls.Add(pnlPerson);

            Controls.Add(pnlUser);



            pnlUser.Visible = false;

        }






        private void CreatePersonPanel()
        {

            pnlPerson =
                new Panel();


            pnlPerson.Size =
                new Size(1200, 620);


            pnlPerson.Location =
                new Point(40, 40);




            personCard =
                new PersonInfoCard();


            personCard.Location =
                new Point(500, 20);
            

            pnlPerson.Controls.Add(personCard);




            txtSearch =
                new RoundedTextBox();
            txtSearch.TextChanged +=
                    TxtSearch_TextChanged;

            txtSearch.Location =
                new Point(20, 40);


            txtSearch.Size =
                new Size(250, 35);


            


            pnlPerson.Controls.Add(txtSearch);






            cmbSearchType =
                new ComboBox();


            cmbSearchType.Location =
                new Point(290, 40);


            cmbSearchType.Size =
                new Size(150, 35);


            cmbSearchType.DropDownStyle =
                ComboBoxStyle.DropDownList;


            cmbSearchType.Items.Add("National No");

            cmbSearchType.Items.Add("Full Name");

            cmbSearchType.Items.Add("Phone");

            cmbSearchType.Items.Add("Email");


            cmbSearchType.SelectedIndex = 0;


            pnlPerson.Controls.Add(cmbSearchType);






            dgvPeople =
                new DataGridView();


            dgvPeople.Location =
                new Point(20, 100);


            dgvPeople.Size =
                new Size(450, 300);


            dgvPeople.ReadOnly = true;


            dgvPeople.SelectionMode =
             DataGridViewSelectionMode.FullRowSelect;


            _peopleTable = People.GetAllFewDetails();

            dgvPeople.DataSource =
                _peopleTable;


            dgvPeople.SelectionChanged +=
                DgvPeople_SelectionChanged;

            txtSearch.KeyPress += txtSearch_KeyPress;

            if (dgvPeople.Rows.Count > 0)
            {
                dgvPeople.Rows[0].Selected = true;
            }


            pnlPerson.Controls.Add(dgvPeople);





            btnNext =
                new RoundedButton();


            btnNext.Text =
                "Next";


            btnNext.Location =
                new Point(350, 450);

            btnNext.Size =
                 new Size(100, 30);
            btnNext.Click +=
                BtnNext_Click;


            pnlPerson.Controls.Add(btnNext);

        }



        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_peopleTable == null)
                return;


            try
            {
                string text =
                    txtSearch.Text.Replace("'", "''");


                string filter = "";


                switch (cmbSearchType.Text)
                {
                    case "National No":

                        filter =
                            $"NationalNo LIKE '%{text}%'";

                        break;


                    case "Full Name":

                        filter =
                            $"FullName LIKE '%{text}%'";

                        break;


                    case "Phone":

                        filter =
                            $"Phone LIKE '%{text}%'";

                        break;


                    case "Email":

                        filter =
                            $"Email LIKE '%{text}%'";

                        break;
                }


                _peopleTable.DefaultView.RowFilter = filter;
            }
            catch
            {
              
                _peopleTable.DefaultView.RowFilter = "";
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (
               cmbSearchType.Text == "Phone")
            {
                if (!char.IsDigit(e.KeyChar) &&
                   e.KeyChar != '\b')
                {
                    e.Handled = true;
                }
            }
        }
        private RoundedTextBox CreateTextBox(string name,int y)
        {
            Label lbl = new Label();

            lbl.Text = name;

            lbl.Location =
                new Point(80, y - 25);

            lbl.AutoSize = true;

            pnlUser.Controls.Add(lbl);



            RoundedTextBox txt =
                new RoundedTextBox();


            txt.Location =
                new Point(80, y);


            txt.Width =
                250;


            txt.Placeholder =
                name;


            pnlUser.Controls.Add(txt);


            return txt;
        }
        private void CreateUserPanel()
        {

            pnlUser =
                new Panel();


            pnlUser.Size =
                new Size(850, 520);


            pnlUser.Location =
                new Point(40, 40);



           


            txtUsername =
                CreateTextBox("Username", 80);




            txtPassword =
                CreateTextBox(
                    "Password",
                    150);
            txtUsername.TextChanged += TxtUsername_TextChanged;
            txtPassword.TextChanged += TxtPassword_TextChanged;

            txtConfirmPassword =
                CreateTextBox(
                    "Confirm Password",
                    220);
            txtPassword.MinLength = 8;
            txtPassword.MaxLength = 20;

            


            chkActive =
                new CheckBox();


            chkActive.Text =
                "Active";


            chkActive.Checked =
                true;


            chkActive.Location =
                new Point(80, 300);


            pnlUser.Controls.Add(chkActive);






            btnPermissions =
                new RoundedButton();


            btnPermissions.Text =
                "Set Permissions";


            btnPermissions.Location =
                new Point(80, 350);

            btnPermissions.Size =
                new Size(180, 50);

            btnPermissions.Click +=
                BtnPermissions_Click;


            pnlUser.Controls.Add(btnPermissions);







            btnBack =
                new RoundedButton();


            btnBack.Text =
                "Back";


            btnBack.Location =
                new Point(250, 450);

            btnBack.Size =
                 new Size(100, 30);
            btnBack.Click +=
                BtnBack_Click;


            pnlUser.Controls.Add(btnBack);






            btnSave =
                new RoundedButton();


            btnSave.Text =
                "Save";


            btnSave.Location =
                new Point(400, 450);

            btnSave.Size =
                 new Size(100, 30);
            btnSave.Click +=
                BtnSave_Click;


            pnlUser.Controls.Add(btnSave);

        }









        int id = 0;
        private void BtnNext_Click(
            object sender,
            EventArgs e)
        {
            if (dgvPeople.CurrentRow == null) { CustomMessageBox.Show("Faild!", "Please Choose a person"); return; }
            id= Convert.ToInt32(dgvPeople.CurrentRow.Cells["PersonID"].Value);
            if (Users.IsPersonUser(id)) { CustomMessageBox.Show("Faild!", "This person is already user please select another person"); return; }
            

            pnlPerson.Visible = false;

            pnlUser.Visible = true;

        }



        private void BtnBack_Click(
            object sender,
            EventArgs e)
        {

            pnlUser.Visible = false;

            pnlPerson.Visible = true;

        }



        private void BtnPermissions_Click(
            object sender,
            EventArgs e)
        {

            frmPermissions frm = new frmPermissions();
            frm.ShowDialog();
            UserPermissions = frm.PermissionValue;


        }

        public bool Validation()
        {
            bool v = true;
            if (Users.IsUserExist(txtUsername.Text)) { txtUsername.State = ValidationState.Invalid; txtUsername.ValidationMessage = "This UserName is Already exist"; v = false; }
            else { txtUsername.State = ValidationState.Valid; }
            if (txtPassword.Text.Length < txtPassword.MinLength) {  txtPassword.State = ValidationState.Invalid;txtPassword.ValidationMessage = "Must be at least 8 characters";v = false; }
            else { txtPassword.State = ValidationState.Valid; }
            if  (txtPassword.Text.Length > txtPassword.MaxLength) { txtPassword.State = ValidationState.Invalid; txtPassword.ValidationMessage = "Must be at most 20 characters"; v = false; }
            else { txtPassword.State = ValidationState.Valid; }
            if (txtConfirmPassword.Text != txtPassword.Text) { txtConfirmPassword.State = ValidationState.Invalid; v = false; }
            
            else { txtConfirmPassword.State = ValidationState.Valid; }
            return v;

        }

        private void BtnSave_Click(
            object sender,
            EventArgs e)
        {

            if (!Validation()) { CustomMessageBox.Show("Cannot add user", "Please, fill all fields correctly"); return;  }
            if (UserPermissions == 0) { CustomMessageBox.Show("Falid", "Please, Define permissions");return; }
            Users user = new Users();
            user.UserName = txtUsername.Text;
            user.Password = txtPassword.Text;
            user.UserPermissions = UserPermissions;
            user.IsActive = chkActive.Checked;
            user.PersonID = id;
            int res = user.AddUser();
            if (res==0) { CustomMessageBox.Show("Cannot add user", "Error in Database"); return; }
            else if(res==-1) { CustomMessageBox.Show("Cannot add user", "This person is already a user."); return; }
            else  CustomMessageBox.Show("Done!", "Added successfully!");
                RefreshUsers?.Invoke();

                Close();
            


        }



        private void DgvPeople_SelectionChanged(
    object sender,
    EventArgs e)
        {
            if (dgvPeople.CurrentRow == null ||
                dgvPeople.SelectedRows.Count == 0)
            {
                SelectedPersonID = -1;
                personCard.ClearData();
                return;
            }


            object value =
                dgvPeople.CurrentRow.Cells["PersonID"].Value;


            if (value == null || value == DBNull.Value)
            {
                SelectedPersonID = -1;
                personCard.ClearData();
                return;
            }


            SelectedPersonID =
                Convert.ToInt32(value);


            People person =
                People.GetPerson(SelectedPersonID);


            if (person != null)
            {
                personCard.LoadPerson(person);
            }
            else
            {
                SelectedPersonID = -1;
                personCard.ClearData();
            }
        }
    }
}