using BusinessLayer.Models;
using DVLD.Business.Models;
using DVLD.Presentation.UI;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DVLD.Controls
{
    public class UserDetailsCard : UserControl
    {

        private PictureBox picUser;

        private Label lblUserID;
        private Label lblUsername;
        private Label lblFullName;
        private Label lblEmail;
        private Label lblStatus;
        private Label lblPermissions;


        public UserDetailsCard()
        {
            InitializeUI();
        }



        private void InitializeUI()
        {

            Size =
                new Size(750, 350);


            BackColor =
                Theme.CardBackground;



            picUser =
                new PictureBox();


            picUser.Size =
                new Size(160, 160);


            picUser.Location =
                new Point(40, 40);


            picUser.SizeMode =
                PictureBoxSizeMode.Zoom;


            picUser.Image =
                Properties.Resources.male;


            Controls.Add(picUser);




            lblUserID =
                CreateLabel(
                    "User ID : ",
                    250,
                    40);



            lblUsername =
                CreateLabel(
                    "Username : ",
                    250,
                    80);



            lblFullName =
                CreateLabel(
                    "Full Name : ",
                    250,
                    120);



            lblEmail =
                CreateLabel(
                    "Email : ",
                    250,
                    160);



            lblStatus =
                CreateLabel(
                    "Status : ",
                    250,
                    200);



            lblPermissions =
                CreateLabel(
                    "Permissions : ",
                    250,
                    240);

        }





        private Label CreateLabel(
            string text,
            int x,
            int y)
        {

            Label lbl =
                new Label();


            lbl.Text =
                text;


            lbl.Location =
                new Point(x, y);


            lbl.AutoSize =
                true;


            lbl.Font =
                Theme.NormalFont;


            lbl.ForeColor =
                Theme.TextPrimary;


            Controls.Add(lbl);


            return lbl;

        }





        public void LoadUser(int userID)
        {

            Users user =
                Users.GetUser(userID);


            if (user == null)
                return;



            People person =
                People.GetPerson(
                    user.PersonID);



            if (person == null)
                return;



            lblUserID.Text =
                "User ID : "
                + user.UserID;



            lblUsername.Text =
                "Username : "
                + user.UserName;



            lblFullName.Text =
                "Full Name : "
                +
                person.FirstName
                + " "
                +
                person.SecondName
                + " "
                +
                person.ThirdName
                + " "
                +
                person.LastName;



            lblEmail.Text =
                "Email : "
                +
                person.Email;



            lblStatus.Text =
                "Status : "
                +
                (user.IsActive
                ? "Active"
                : "Inactive");



            lblPermissions.Text =
                "Permissions : "
                +
                user.UserPermissions;



            LoadImage(person);

        }





        private void LoadImage(
            People person)
        {


            if (!string.IsNullOrEmpty(person.ImagePath)
                &&
               File.Exists(person.ImagePath))
            {

                picUser.Image =
                    Image.FromFile(
                        person.ImagePath);

            }

            else
            {

                picUser.Image =
                    person.Gender == 0
                    ?
                    Properties.Resources.male
                    :
                    Properties.Resources.female;

            }

        }

    }
}