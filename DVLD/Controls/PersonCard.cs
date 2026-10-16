using DVLD.Business.Models;
using DVLD.Presentation.UI;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace DVLD.Controls
{
    public class PersonCard : UserControl
    {
        private string _imagePath = "";

        private PictureBox picPerson;
        private Button btnChooseImage;
        private Label lblPersonID;
        private string NationalNo;
        private RoundedTextBox txtNationalNo;
        private RoundedTextBox txtFirstName;
        private RoundedTextBox txtSecondName;
        private RoundedTextBox txtThirdName;
        private RoundedTextBox txtLastName;
        private RoundedTextBox txtPhone;
        private RoundedTextBox txtEmail;
        private RoundedTextBox txtAddress;

        private DateTimePicker dtBirth;

        private ComboBox cmbGender;
        private ComboBox cmbCountry;

        



        public PersonCard()
        {
            InitializeUI();
        }

        public static void Clear(ref PersonCard person)
        {
            PersonCard p  = new PersonCard();
            person = p;
        }

        private void InitializeUI()
        {
            Size =
                new Size(850, 520);

            int fieldWidth = 220;
            int leftX = 280;
            int rightX = 530;

            int startY = 60;
            int gap = 70;

            lblPersonID = new Label();

            lblPersonID.Text = "";

            lblPersonID.Font =
                new Font("Segoe UI", 12, FontStyle.Bold);

            lblPersonID.ForeColor =
                Theme.TextPrimary;

            lblPersonID.AutoSize = true;

            lblPersonID.Visible = false;

            Controls.Add(lblPersonID);

            picPerson = new PictureBox();

            picPerson.Location =
                new Point(40, 40);

            picPerson.Size =
                new Size(160, 160);

            picPerson.SizeMode =
                PictureBoxSizeMode.Zoom;


            picPerson.Image =
                Properties.Resources.male;


            Controls.Add(picPerson);



            btnChooseImage =
                new Button();

            btnChooseImage.Text =
                "Choose Image";


            btnChooseImage.Location =
                new Point(60, 220);


            btnChooseImage.Click +=
                BtnChooseImage_Click;


            Controls.Add(btnChooseImage);



            txtNationalNo =
             CreateField(
                 "National No",
                 leftX,
                 startY,
                 "National Number",
                 1);


            txtFirstName =
                CreateField(
                    "First Name",
                    rightX,
                    startY,
                    "First Name",
                    2);



            txtSecondName =
                CreateField(
                    "Second Name",
                    leftX,
                    startY + gap,
                    "Second Name",
                    2 );



            txtThirdName =
                CreateField(
                    "Third Name",
                    rightX,
                    startY + gap,
                    "Third Name",
                    2 );



            txtLastName =
                CreateField(
                    "Last Name",
                    leftX,
                    startY + gap * 2,
                    "Last Name",
                    2);



            txtPhone =
                CreateField(
                    "Phone",
                    rightX,
                    startY + gap * 2,
                    "Phone",
                    1);



            txtEmail =
                CreateField(
                    "Email",
                    leftX,
                    startY + gap * 3,
                    "Email",
                    3);

            dtBirth =
            CreateDateField(
                "Date Of Birth",
                rightX,
                startY + gap * 3);



            cmbGender =
             CreateCombo(
                 "Gender",
                 leftX,
                 startY + gap * 4);


           


            cmbGender.Items.Add("Male");
            cmbGender.Items.Add("Female");

            cmbGender.SelectedIndex =
                0;



            cmbCountry =
            CreateCombo(
                "Nationality",
                rightX,
                startY + gap * 4);

            txtAddress =
                CreateField(
                    "Address",
                    leftX,
                    startY + gap * 5,
                    "Address",
                    0);




            txtAddress.Multiline = true;

            txtAddress.Height = 80;

            txtAddress.Width = 470;

            txtAddress.Multiline =
                true;

            txtAddress.Height =
                70;


            cmbGender.SelectedIndexChanged +=
                GenderChanged;

            txtFirstName.MaxLength = 15;
            txtSecondName.MaxLength = 15;
            txtThirdName.MaxLength = 15;
            txtLastName.MaxLength = 15;
            txtNationalNo.MaxLength = 20;
            txtPhone.MaxLength = 20;
            txtEmail.MaxLength = 50;
            txtAddress.MaxLength = 200;
            txtNationalNo.MinLength = 10;
            txtPhone.MinLength = 10;

            dtBirth.MinDate = DateTime.Now.AddYears(-100);
            dtBirth.MaxDate= DateTime.Now.AddYears(-18);

        }

        

        private bool ValidateField(RoundedTextBox txt, string fieldName)
        {
           
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.State = ValidationState.Invalid;

                txt.ValidationMessage =
                    $"{fieldName} is required";

                return false;
            }


            
            if (txt.MinLength > 0 &&
                txt.Text.Length < txt.MinLength)
            {
                txt.State = ValidationState.Invalid;

                txt.ValidationMessage =
                    $"{fieldName} must be at least {txt.MinLength} characters";

                return false;
            }


          
            if (txt.MaxLength > 0 &&
                txt.Text.Length > txt.MaxLength)
            {
                txt.State = ValidationState.Invalid;

                txt.ValidationMessage =
                    $"{fieldName} cannot exceed {txt.MaxLength} characters";

                return false;
            }


            txt.State = ValidationState.Valid;

            return true;
        }
        public bool ValidateData()
        {
            bool result = true;


            if (!ValidateField(
                txtNationalNo,
                "National Number"))
            {
                result = false;
            }

            
                if (People.GetPerson(txtNationalNo.Text).PersonID != 0)
                {
                if (lblPersonID.Visible == false||txtNationalNo.Text!=NationalNo)
                {
                    txtNationalNo.State = ValidationState.Invalid;
                    txtNationalNo.ValidationMessage = "National Number already exists"; result = false;

                }
                    
                }
            


            if (!ValidateField(
                txtFirstName,
                "First Name"))
            {
                result = false;
            }



            if (!ValidateField(
                txtSecondName,
                "Second Name"))
            {
                result = false;
            }



            if (!ValidateField(
                txtThirdName,
                "Third Name"))
            {
                result = false;
            }



            if (!ValidateField(
                txtLastName,
                "Last Name"))
            {
                result = false;
            }



            if (!ValidateField(
                txtPhone,
                "Phone Number"))
            {
                result = false;
            }



            if (!ValidateField(
                txtEmail,
                "Email"))
            {
                result = false;
            }



            if (!ValidateField(
                txtAddress,
                "Address"))
            {
                result = false;
            }



            if (dtBirth.Value >= DateTime.Now)
            {
                MessageBox.Show(
                    "Date of birth cannot be in the future",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                result = false;
            }



            if (cmbGender.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select gender",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                result = false;
            }



            if (cmbCountry.SelectedValue == null)
            {
                MessageBox.Show(
                    "Please select nationality",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                result = false;
            }



            return result;
        }
        private RoundedTextBox CreateField(
       string title,
       int x,
       int y,
       string placeholder,
       int type)
        {

            Label lbl = new Label();

            lbl.Text = title;

            lbl.Font =
                new Font(
                    "Segoe UI",
                    9,
                    FontStyle.Bold);


            lbl.ForeColor =
                Theme.TextPrimary;


            lbl.Location =
                new Point(
                    x,
                    y - 28);


            lbl.AutoSize = true;


            Controls.Add(lbl);



            RoundedTextBox txt =
                new RoundedTextBox();


            txt.Location =
                new Point(x, y);


            txt.Width =
                220;


            txt.Height =
                38;


           


            txt.Placeholder =
                placeholder;


            switch (type)
            {
                // Numbers
                case 1:
                    txt.OnlyNumbers = true;
                    break;


                // Letters
                case 2:
                    txt.OnlyLetters = true;
                    break;


                // Email
                case 3:
                    txt.EmailMode = true;
                    break;
            }


            Controls.Add(txt);


            return txt;
        }


        private void CenterPersonID()
        {
            lblPersonID.Location =
                new Point(
                    (Width - lblPersonID.Width) / 2,
                    10
                );
        }
        public void ShowPersonID(int id)
        {
            lblPersonID.Text =
                "Person ID: " + id;

            lblPersonID.Visible = true;

            CenterPersonID();
        }
        public void HidePersonID()
        {
            lblPersonID.Text = "";

            lblPersonID.Visible = false;
        }
        private DateTimePicker CreateDateField(
            string title,
            int x,
            int y)
        {

            Label lbl =
                new Label();


            lbl.Text =
                title;


            lbl.Location =
                new Point(x, y - 22);


            lbl.AutoSize =
                true;


            Controls.Add(lbl);



            DateTimePicker dt =
                new DateTimePicker();


            dt.Location =
                new Point(x, y);


            dt.Width =
                200;


            Controls.Add(dt);


            return dt;
        }



        private ComboBox CreateCombo(
            string title,
            int x,
            int y)
        {

            Label lbl =
                new Label();


            lbl.Text =
                title;


            lbl.Location =
                new Point(x, y - 22);


            lbl.AutoSize =
                true;


            Controls.Add(lbl);



            ComboBox cmb =
                new ComboBox();


            cmb.Location =
                new Point(x, y);


            cmb.Width =
                200;


            cmb.DropDownStyle =
                ComboBoxStyle.DropDownList;


            Controls.Add(cmb);


            return cmb;
        }



        public void LoadCountries(DataTable dt)
        {
            cmbCountry.DataSource =
                dt;

            cmbCountry.ValueMember =
              "CountryID";

            cmbCountry.DisplayMember =
                "CountryName";


          
        }




        private void GenderChanged(
            object sender,
            EventArgs e)
        {

            if (cmbGender.SelectedIndex == 0)
            {
                picPerson.Image =
                    Properties.Resources.male;
            }
            else
            {
                picPerson.Image =
                    Properties.Resources.female;
            }

        }




        private void BtnChooseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter =
                "Image Files|*.jpg;*.jpeg;*.png;*.bmp";


            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string sourcePath = dialog.FileName;


                string folder =
                    @"C:\DVLD\Images";


                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }


                string extension =
                    Path.GetExtension(sourcePath);


                string fileName =
                    DateTime.Now.ToString("yyyyMMddHHmmssfff")
                    + extension;


                string destination =
                    Path.Combine(folder, fileName);


                File.Copy(sourcePath, destination, true);


                _imagePath = destination;
                try
                {

                    picPerson.Image =
                        Image.FromFile(destination);
                }
                catch(Exception ex) { MessageBox.Show("Cannot load this pic please choose another pic", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

     

        public People GetPerson(int id)
        {


            if (id>0) {
                return new People(id, txtNationalNo.Text, txtFirstName.Text, txtSecondName.Text, txtThirdName.Text, txtLastName.Text
                , dtBirth.Value, cmbGender.SelectedIndex, txtAddress.Text, txtPhone.Text, txtEmail.Text, (int)cmbCountry.SelectedValue, _imagePath);
            };

            return new People( txtNationalNo.Text, txtFirstName.Text, txtSecondName.Text, txtThirdName.Text, txtLastName.Text
                    , dtBirth.Value, cmbGender.SelectedIndex, txtAddress.Text, txtPhone.Text, txtEmail.Text, (int)cmbCountry.SelectedValue, _imagePath);
        
       
        }




        public void LoadPerson(People person)
        {

            txtNationalNo.Text =
                person.NationalNo;


            txtFirstName.Text =
                person.FirstName;


            txtSecondName.Text =
                person.SecondName;


            txtThirdName.Text =
                person.ThirdName;


            txtLastName.Text =
                person.LastName;


            dtBirth.Value =
                person.DateOfBirth;


            cmbGender.SelectedIndex =
                person.Gender;


            txtPhone.Text =
                person.Phone;

            txtEmail.Text = person.Email;

            txtAddress.Text =
                person.Address;


            cmbCountry.SelectedValue =
                person.NationalityCountryID;


            _imagePath = person.ImagePath;


            if (File.Exists(_imagePath))
            {
                picPerson.Image =
                    Image.FromFile(_imagePath);
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
            lblPersonID.Text = "";
            lblPersonID.Visible = false;


            txtNationalNo.Clear();

            txtFirstName.Clear();

            txtSecondName.Clear();

            txtThirdName.Clear();

            txtLastName.Clear();

            txtPhone.Clear();

            txtEmail.Clear();

            txtAddress.Clear();



            dtBirth.Value =
                DateTime.Now;



            cmbGender.SelectedIndex = -1;


            cmbCountry.SelectedIndex = -1;



            _imagePath = "";

            picPerson.Image =
                Properties.Resources.male;
        }

     

       
        public void FillData(People person)
        {
            txtNationalNo.Text = person.NationalNo;

            txtFirstName.Text = person.FirstName;

            txtSecondName.Text = person.SecondName;

            txtThirdName.Text = person.ThirdName;

            txtLastName.Text = person.LastName;

            dtBirth.Value = person.DateOfBirth;

            txtPhone.Text = person.Phone;

            txtEmail.Text = person.Email;

            txtAddress.Text = person.Address;

            NationalNo= person.NationalNo;

            cmbGender.SelectedIndex = person.Gender;


            cmbCountry.SelectedValue =
                person.NationalityCountryID;


            if (!string.IsNullOrEmpty(person.ImagePath)
                 && File.Exists(person.ImagePath))
            {
                _imagePath = person.ImagePath;

                picPerson.Image =
                    Image.FromFile(_imagePath);
            }
            else
            {
                _imagePath = "";

                picPerson.Image =
                    person.Gender == 0 ?
                    Properties.Resources.male :
                    Properties.Resources.female;
            }
        }
    }
}