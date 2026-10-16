using BusinessLayer.Models;
using DVLD.Business;
using DVLD.Business.Models;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DVLD.Controls
{
    public class PersonInfoCard : UserControl
    {
        private PictureBox picPerson;

        private Label lblTitle;
        private Label lblPersonID;

        private Label lblNationalNoTitle;
        private Label lblFullNameTitle;
        private Label lblGenderTitle;
        private Label lblBirthTitle;
        private Label lblCountryTitle;
        private Label lblPhoneTitle;
        private Label lblEmailTitle;
        private Label lblAddressTitle;

        private Label lblNationalNo;
        private Label lblFullName;
        private Label lblGender;
        private Label lblBirth;
        private Label lblCountry;
        private Label lblPhone;
        private Label lblEmail;
        private Label lblAddress;

        public PersonInfoCard()
        {
            InitializeUI();
        }

        private void InitializeUI()
        {
            Size = new Size(850, 520);

            BackColor = Color.White;

            picPerson = new PictureBox();

            picPerson.Location = new Point(35, 40);

            picPerson.Size = new Size(170, 170);

            picPerson.SizeMode = PictureBoxSizeMode.Zoom;

            picPerson.BorderStyle = BorderStyle.FixedSingle;

            picPerson.Image = Properties.Resources.male;

            Controls.Add(picPerson);



            lblTitle = new Label();

            lblTitle.Text = "Person Information";

            lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);

            lblTitle.AutoSize = true;

            lblTitle.Location = new Point(260, 20);

            Controls.Add(lblTitle);



            CreateInfoLabel("National Number", 260, 80, out lblNationalNoTitle, out lblNationalNo);

            CreateInfoLabel("Full Name", 260, 145, out lblFullNameTitle, out lblFullName);

            CreateInfoLabel("Gender", 260, 210, out lblGenderTitle, out lblGender);

            CreateInfoLabel("Date Of Birth", 260, 275, out lblBirthTitle, out lblBirth);

            CreateInfoLabel("Nationality", 260, 340, out lblCountryTitle, out lblCountry);

            CreateInfoLabel("Phone", 260, 405, out lblPhoneTitle, out lblPhone);
            CreateInfoLabel("Email", 260, 470, out lblEmailTitle, out lblEmail);



            lblAddressTitle = new Label();

            lblAddressTitle.Text = "Address";

            lblAddressTitle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            lblAddressTitle.AutoSize = true;

            lblAddressTitle.Location = new Point(35, 245);

            Controls.Add(lblAddressTitle);



            lblAddress = new Label();

            lblAddress.Font = new Font("Segoe UI", 10);

            lblAddress.Location = new Point(35, 270);

            lblAddress.Size = new Size(180, 180);

            lblAddress.BorderStyle = BorderStyle.FixedSingle;

            lblAddress.Padding = new Padding(8);

            Controls.Add(lblAddress);



            lblPersonID = new Label();

            lblPersonID.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            lblPersonID.AutoSize = true;

            lblPersonID.Location =
                new Point(260, 55);

            Controls.Add(lblPersonID);
        }

        private void CreateInfoLabel(
            string title,
            int x,
            int y,
            out Label lblTitle,
            out Label lblValue)
        {
            lblTitle = new Label();

            lblTitle.Text = title;

            lblTitle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            lblTitle.AutoSize = true;

            lblTitle.Location = new Point(x, y);

            Controls.Add(lblTitle);



            lblValue = new Label();

            lblValue.Font = new Font("Segoe UI", 10);

            lblValue.Location = new Point(x, y + 22);

            lblValue.Size = new Size(300, 25);

            Controls.Add(lblValue);


        }
        public void LoadPerson(People person)
        {
            if (person == null)
                return;
            lblPersonID.Text =
                "Person ID: " + person.PersonID;

            lblNationalNo.Text =
                person.NationalNo;

            lblFullName.Text =
                person.FirstName + " " +
                person.SecondName + " " +
                person.ThirdName + " " +
                person.LastName;

            lblGender.Text =
                person.Gender == 0 ? "Male" : "Female";

            lblBirth.Text =
                person.DateOfBirth.ToShortDateString();

            lblPhone.Text =
                person.Phone;
            lblEmail.Text = person.Email;

            lblAddress.Text =
                person.Address;

            lblCountry.Text =
                Countries.GetCountryName(person.NationalityCountryID);



            if (!string.IsNullOrWhiteSpace(person.ImagePath)
                && File.Exists(person.ImagePath))
            {
                picPerson.Image =
                    Image.FromFile(person.ImagePath);
            }
            else
            {
                picPerson.Image =
                    person.Gender == 0 ?
                    Properties.Resources.male :
                    Properties.Resources.female;
            }
        }
        public void ClearData()
        {
            lblPersonID.Text = "Person ID: -1";
            lblNationalNo.Text = "";

            lblFullName.Text = "";

            lblGender.Text = "";

            lblBirth.Text = "";

            lblCountry.Text = "";

            lblPhone.Text = "";

            lblEmail.Text = "";

            lblAddress.Text = "";


            picPerson.Image =
                Properties.Resources.male;
        }

    }
}