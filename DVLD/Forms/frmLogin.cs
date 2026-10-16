using System;
using System.Drawing;
using System.Windows.Forms;
using BusinessLayer.Models;
using DVLD.Forms;
using DVLD.Presentation.UI;
using BCrypt.Net;
using BusinessLayer;
namespace DVLD.Presentation.Forms
{
    public partial class frmLogin : BaseForm
    {
        private PictureBox backgroundImage;
      
        private ShadowPanel loginCard;

        private Label lblTitle;
        private Label lblSubTitle;

        private RoundedTextBox txtUsername;
        private RoundedTextBox txtPassword;

        private CheckBox chkShowPassword;
        private CheckBox chkRememberMe;

        private RoundedButton btnLogin;

        private Label lblFooter;


        public frmLogin()
        {
            

            InitializeForm();
            InitializeComponents();
        }


        private void InitializeForm()
        {
            Width = 1000;
            Height = 600;

            StartPosition = FormStartPosition.CenterScreen;

            BackColor = Theme.AppBackground;

            Load += frmLogin_Load;
        }


        private void InitializeComponents()
        {
            backgroundImage = new PictureBox();

            backgroundImage.Dock = DockStyle.Fill;

            backgroundImage.Image = Image.FromFile(
                @"C:\DVLD\main.jpg"
            );

            backgroundImage.SizeMode =
                PictureBoxSizeMode.StretchImage;

            Controls.Add(backgroundImage);



            loginCard = new ShadowPanel();

            loginCard.Size =
                new Size(400, 430);


            loginCard.Location =
                new Point(
                    Width - 400,
                    90
                );


            loginCard.BackColor =
                Color.White;


            Controls.Add(loginCard);


            loginCard.BringToFront();



            lblTitle = new Label();

            lblTitle.Text =
                "Welcome Back";

            lblTitle.Font =
                Theme.HeaderFont;

            lblTitle.ForeColor =
                Theme.TextPrimary;

            lblTitle.AutoSize = true;

            lblTitle.Location =
                new Point(80, 50);



            loginCard.Controls.Add(lblTitle);



            lblSubTitle = new Label();

            lblSubTitle.Text =
                "Login to DVLD System";

            lblSubTitle.Font =
                Theme.NormalFont;

            lblSubTitle.ForeColor =
                Theme.TextSecondary;

            lblSubTitle.AutoSize = true;

            lblSubTitle.Location =
                new Point(90, 95);



            loginCard.Controls.Add(lblSubTitle);



            txtUsername = new RoundedTextBox();

            txtUsername.Placeholder =
                "Username";

            txtUsername.Size =
                new Size(300, 42);

            txtUsername.Location =
                new Point(50, 150);



            loginCard.Controls.Add(txtUsername);



            txtPassword = new RoundedTextBox();

            txtPassword.Placeholder =
                "Password";

            txtPassword.UsePassword =
                true;

            txtPassword.Size =
                new Size(300, 42);

            txtPassword.Location =
                new Point(50, 210);



            loginCard.Controls.Add(txtPassword);



            chkShowPassword = new CheckBox();

            chkShowPassword.Text =
                "Show Password";

            chkShowPassword.Font =
                Theme.NormalFont;

            chkShowPassword.ForeColor =
                Theme.TextSecondary;

            chkShowPassword.AutoSize =
                true;

            chkShowPassword.Location =
                new Point(52, 270);


            chkShowPassword.CheckedChanged +=
                ChkShowPassword_CheckedChanged;



            loginCard.Controls.Add(chkShowPassword);


            chkRememberMe = new CheckBox();

            chkRememberMe.Text =
                "Remember Me";

            chkRememberMe.Font =
                Theme.NormalFont;

            chkRememberMe.ForeColor =
                Theme.TextSecondary;

            chkRememberMe.AutoSize =
                true;

            chkRememberMe.Location =
                new Point(230, 270);



            loginCard.Controls.Add(chkRememberMe);



            btnLogin = new RoundedButton();

            btnLogin.Text =
                "LOGIN";


            btnLogin.Size =
                new Size(300, 45);


            btnLogin.Location =
                new Point(50, 320);


            btnLogin.Click +=
                BtnLogin_Click;



            loginCard.Controls.Add(btnLogin);



            lblFooter = new Label();

            lblFooter.Text =
                "Authorized Personnel Only";


            lblFooter.Font =
                Theme.SmallFont;


            lblFooter.ForeColor =
                Theme.TextSecondary;


            lblFooter.AutoSize = true;


            lblFooter.Location =
                new Point(110, 385);



            loginCard.Controls.Add(lblFooter);
        }



        private void ChkShowPassword_CheckedChanged(
            object sender,
            EventArgs e)
        {
            txtPassword.UsePassword =
                !chkShowPassword.Checked;
        }

       

        private void BtnLogin_Click(object sender, EventArgs e)
        {

            Users.LoginResult res = new Users.LoginResult();

            res = Users.login(txtUsername.Text, txtPassword.Text);

            switch (res)
            {
                case Users.LoginResult.Success:
                    if (chkRememberMe.Checked) { Users.SaveInRememberMe(txtUsername.Text); }
                    Hide();
                    frmMainMenu frm = new frmMainMenu(); frm.ShowDialog();
                    return;
                case Users.LoginResult.WrongPassword:
                    CustomMessageBox.Show("Faild", "UserName or Password incorrect");
                    return;
                case Users.LoginResult.Inactive:
                    CustomMessageBox.Show("Faild", "This account is disabled");
                    return;
                case Users.LoginResult.UserNotFound:
                    CustomMessageBox.Show("Faild", "UserName or Password incorrect");
                    return;
            }
        }

           

        

        private void frmLogin_Load(
            object sender,
            EventArgs e)
        {
            FormAnimator.FadeIn(this);
        }
    }
}