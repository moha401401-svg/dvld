using BusinessLayer.Models;
using DVLD.Business.Models;
using DVLD.Controls;
using DVLD.Presentation.UI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Forms
{
    

    public partial class frmAddEditPerson : BaseForm
    {
        public delegate void GetBack(object sender);
        public event GetBack Back;
        private PersonCard personCard;

        private RoundedButton btnSave;
        private Label lblPersonID;
        private RoundedButton btnCancel;
       
        private int? _personID;


        public frmAddEditPerson(int? personID = null)
        {

            _personID = personID;


            InitializeForm();

            InitializeComponents();


            if (_personID != null)
            {
                LoadPerson();
            }

        }



        private void InitializeForm()
        {

            Size =
                new Size(950, 650);


            StartPosition =
                FormStartPosition.CenterScreen;


            BackColor =
                Theme.AppBackground;


            Text =
                _personID == null ?
                "Add Person" :
                "Update Person";

        }




        private void InitializeComponents()
        {

            personCard =
                new PersonCard();


            personCard.Location =
                new Point(40, 50);

            personCard.LoadCountries(Countries.GetAll());

            Controls.Add(personCard);



            btnSave =
                new RoundedButton();


            btnSave.Text =
                "Save";


            btnSave.Size =
                new Size(120, 45);


            btnSave.Location =
                new Point(350, 600);


            btnSave.Click +=
                BtnSave_Click;


            Controls.Add(btnSave);




            btnCancel =
                new RoundedButton();


            btnCancel.Text =
                "Cancel";


            btnCancel.Size =
                new Size(120, 45);


            btnCancel.Location =
                new Point(500, 600);


            btnCancel.Click +=
                BtnCancel_Click;


            Controls.Add(btnCancel);

            if (_personID != null)
            {
                lblPersonID = new Label();

                lblPersonID.Text =
                    "Person ID: " + _personID.Value;

                lblPersonID.Font =
                    new Font("Segoe UI", 12, FontStyle.Bold);

                lblPersonID.AutoSize = true;

                lblPersonID.Location =
                    new Point(40, 10);

                Controls.Add(lblPersonID);
            }

        }




        
        public int ID = 0;
        private void LoadPerson()
        {
            People person =
                People.GetPerson(_personID.Value);


            if (person != null)
            {
                personCard.FillData(person);
                personCard.ShowPersonID(person.PersonID);
                ID = person.PersonID;
                
            }
           
           
        }





        private void BtnSave_Click(
            object sender,
            EventArgs e)
        {

            if (!personCard.ValidateData())
            {
                CustomMessageBox.Show(
                    "Validation",
                    "Please fill all required fields."
                );

                return;
            }


            
                People person =
                    personCard.GetPerson(ID);

            
           

            if (person.save())
            {
                CustomMessageBox.Show("Done!", "Saved Successfully");
            }
            else CustomMessageBox.Show("Error!", "cannot save in Database");
            Back?.Invoke(this);
            Close();
        }





       





 




        private void BtnCancel_Click(
            object sender,
            EventArgs e)
        {
            Close();
        }

    }
}