using BusinessLayer;
using BusinessLayer.Models;
using DVLD.Business;
using DVLD.Business.Models;
using DVLD.Controls;
using DVLD.Presentation.UI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Forms
{
    public partial class frmEditAccount : BaseForm
    {

        private Label lblTitle;


        private RoundedTextBox txtUsername;
        private RoundedTextBox txtCurrentPassword;
        private RoundedTextBox txtNewPassword;
        private RoundedTextBox txtConfirmPassword;


        private CheckBox chkActive;


        private RoundedButton btnDone;
        private RoundedButton btnDelete;



        public frmEditAccount()
        {

            InitializeForm();

            InitializeComponents();

            LoadUserData();

        }


        private void ValidationUserName(object sender, EventArgs e)
        {
            if (Users.IsUserExist(txtUsername.Text) && txtUsername.Text != CurrentUser.User.UserName) { txtUsername.State = ValidationState.Invalid; txtUsername.ValidationMessage = " Username already exists";  }
            else txtUsername.State = ValidationState.Valid;
           
        }

        private void InitializeForm()
        {

            Text =
                "Edit Account";


            Size =
                new Size(
                    600,
                    650);


            StartPosition =
                FormStartPosition.CenterScreen;


            BackColor =
                Theme.AppBackground;


        }
        private void InitializeComponents()
        {

            lblTitle =
                new Label();


            lblTitle.Text =
                "Edit Account";


            lblTitle.Font =
                Theme.HeaderFont;


            lblTitle.ForeColor =
                Theme.TextPrimary;


            lblTitle.AutoSize =
                true;


            lblTitle.Location =
                new Point(
                    210,
                    40);



            Controls.Add(lblTitle);





            txtUsername =
                CreateTextBox(
                    "Username",
                    120);


            txtCurrentPassword =
                CreateTextBox(
                    "Current Password",
                    200);


            txtNewPassword =
                CreateTextBox(
                    "New Password",
                    280);


            txtConfirmPassword =
                CreateTextBox(
                    "Confirm Password",
                    360);



            txtCurrentPassword.MinLength = 8;
            txtConfirmPassword.MinLength = 8;
            txtNewPassword.MinLength = 8;
            txtCurrentPassword.MaxLength = 20;
            txtNewPassword.MaxLength = 20;
            txtConfirmPassword.MaxLength = 20;
            txtUsername.TextChanged += ValidationUserName;
            





            chkActive =
                new CheckBox();


            chkActive.Text =
                "Active Account";


            chkActive.Font =
                Theme.NormalFont;


            chkActive.ForeColor =
                Theme.TextSecondary;


            chkActive.Location =
                new Point(
                    150,
                    440);



            Controls.Add(chkActive);





            btnDone =
                new RoundedButton();


            btnDone.Text =
                "Done";


            btnDone.Size =
                new Size(
                    120,
                    45);


            btnDone.Location =
                new Point(
                    240,
                    520);



            btnDone.Click +=
                BtnDone_Click;





            btnDelete =
                new RoundedButton();


            btnDelete.Text =
                "Delete Account";


            btnDelete.Size =
                new Size(
                    150,
                    45);


            btnDelete.Location =
                new Point(
                    410,
                    520);



            btnDelete.BackColor =
                Color.IndianRed;


            btnDelete.ForeColor =
                Color.White;



            btnDelete.Click +=
                BtnDelete_Click;




            Controls.Add(btnDone);

            Controls.Add(btnDelete);

        }
        private RoundedTextBox CreateTextBox(string hint, int y)
        {

            RoundedTextBox txt =
                new RoundedTextBox();


            txt.Size =
                new Size(
                    300,
                    45);


            txt.Location =
                new Point(
                    150,
                    y);



            txt.Placeholder =
                hint;



            Controls.Add(txt);


            return txt;

        }
        private void LoadUserData()
        {

            txtUsername.Text =
                CurrentUser.User.UserName;


            chkActive.Checked =
                CurrentUser.User.IsActive;


        }

        public void BtnDelete_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Do you want to delete your account?","Confirm",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                if (Users.DeleteUser(CurrentUser.User.UserID) && People.del(CurrentUser.Person.PersonID))
                {
                    MessageBox.Show("Deleted successfully", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ApplicationSession.Logout();
                }
                else MessageBox.Show("Cannot delete becuase this account has references", "Faild!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ;
        }
        public bool ValidationPass()
        {
            bool v = true;
            if (txtNewPassword.Text != "" || txtConfirmPassword.Text != "")
            {
                if (Users.VerifyPassword(txtCurrentPassword.Text, Users.GetPassword(CurrentUser.User.UserName)))
                {
                    txtCurrentPassword.State = ValidationState.Valid;
                    if (txtNewPassword.Text.Length < txtNewPassword.MinLength) { txtNewPassword.State = ValidationState.Invalid; txtNewPassword.ValidationMessage = "At least 8 characters"; v = false; }
                    else txtNewPassword.State = ValidationState.Valid;

                    if (txtNewPassword.Text != txtConfirmPassword.Text) { txtConfirmPassword.State = ValidationState.Invalid; txtConfirmPassword.ValidationMessage = "Not equal new password"; v = false; }
                    else txtConfirmPassword.State = ValidationState.Valid;

                }
                else { txtCurrentPassword.State = ValidationState.Invalid; txtCurrentPassword.ValidationMessage = "Password incorrect"; v = false; }
            }
            return v;
        }
        public void BtnDone_Click(object sender, EventArgs e)
        {
            if (!ValidationPass()) { CustomMessageBox.Show("Faild!", "Please review your errors"); return; }


            if (Users.IsUserExist(txtUsername.Text) && txtUsername.Text != CurrentUser.User.UserName) 
                { CustomMessageBox.Show("Faild!", "Username already exists"); return; }

            Users user = new Users();
            user.UserID = CurrentUser.User.UserID;
            user.Password = txtNewPassword.Text;
            user.UserName = txtUsername.Text;
            user.IsActive= chkActive.Checked;
           if(Users.UpdateUser(user)) {
                CustomMessageBox.Show("Done!", "Updated successfully"); 
                
                if (!CurrentUser.User.IsActive) { ApplicationSession.Logout(); }
                Close();
                return;
            }
            CustomMessageBox.Show("Faild!", "Error in Database");

            }

        }
    }
