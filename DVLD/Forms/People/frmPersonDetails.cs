using DVLD.Business.Models;
using DVLD.Controls;
using DVLD.Presentation.UI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Forms
{
    public partial class frmPersonDetails : BaseForm
    {
        private readonly int _personID;

        private PersonInfoCard personInfoCard;

        private RoundedButton btnClose;

        public frmPersonDetails(int personID)
        {
            InitializeComponent();

            _personID = personID;

            InitializeForm();

            InitializeControls();

            LoadPerson();
        }

        private void InitializeForm()
        {
            Text = "Person Details";

            Size = new Size(950, 650);

            StartPosition = FormStartPosition.CenterScreen;

            MaximizeBox = false;

            BackColor = Theme.AppBackground;
        }

        private void InitializeControls()
        {
            personInfoCard = new PersonInfoCard();

            personInfoCard.Location = new Point(25, 25);

            Controls.Add(personInfoCard);



            btnClose = new RoundedButton();

            btnClose.Text = "Close";

            btnClose.Size = new Size(120, 45);

            btnClose.Location = new Point(390, 560);

            btnClose.Click += BtnClose_Click;

            Controls.Add(btnClose);
        }

        private void LoadPerson()
        {
            People person = People.GetPerson(_personID);

            if (person == null)
            {
                CustomMessageBox.Show(
                    "Error",
                    "Person not found."
                );

                Close();

                return;
            }

            personInfoCard.LoadPerson(person);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}