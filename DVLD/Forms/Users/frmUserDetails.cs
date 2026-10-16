using BusinessLayer.Models;
using DVLD.Business.Models;
using DVLD.Controls;
using DVLD.Presentation.UI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Forms
{
    public partial class frmUserDetails : BaseForm
    {

        private UserDetailsCard userCard;

        private RoundedButton btnPersonDetails;
        private RoundedButton btnClose;


        private int _userID;



        public frmUserDetails(int userID)
        {

            _userID = userID;


            InitializeComponent();

            InitializeForm();

            InitializeComponents();

            LoadUser();

        }





        private void InitializeForm()
        {

            Size =
                new Size(850, 550);


            StartPosition =
                FormStartPosition.CenterScreen;


            BackColor =
                Theme.AppBackground;


            Text =
                "User Details";

        }







        private void InitializeComponents()
        {


            userCard =
                new UserDetailsCard();


            userCard.Location =
                new Point(40, 40);


            Controls.Add(userCard);






            btnPersonDetails =
                new RoundedButton();


            btnPersonDetails.Text =
                "Show Person Details";


            btnPersonDetails.Size =
                new Size(180, 45);


            btnPersonDetails.Location =
                new Point(220, 450);


            btnPersonDetails.Click +=
                BtnPersonDetails_Click;


            Controls.Add(btnPersonDetails);







            btnClose =
                new RoundedButton();


            btnClose.Text =
                "Close";


            btnClose.Size =
                new Size(120, 45);


            btnClose.Location =
                new Point(430, 450);


            btnClose.Click +=
                BtnClose_Click;


            Controls.Add(btnClose);

        }







        private void LoadUser()
        {

            userCard.LoadUser(
                _userID
            );

        }







        private void BtnPersonDetails_Click(
            object sender,
            EventArgs e)
        {


            Users user =
                Users.GetUser(
                    _userID
                );


            if (user == null)
                return;



            frmPersonDetails frm =
                new frmPersonDetails(
                    user.PersonID
                );


            frm.ShowDialog();

        }







        private void BtnClose_Click(
            object sender,
            EventArgs e)
        {

            Close();

        }


    }
}