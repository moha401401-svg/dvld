using System;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Presentation.UI
{
    public class CustomMessageBox : BaseForm
    {
        private Label lblMessage;
        private Label lblTitle;
        private RoundedButton btnOk;
        private Panel pnlContent;

        private Timer timer;

        public CustomMessageBox(string title, string message)
        {
            Width = 420;
            Height = 230;

            InitializeComponents(title, message);
        }

        private void InitializeComponents(string title, string message)
        {
            pnlContent = new Panel();

            pnlContent.Dock = DockStyle.Fill;
            pnlContent.BackColor = Theme.CardBackground;

            Controls.Add(pnlContent);


            lblTitle = new Label();

            lblTitle.Text = title;
            lblTitle.Font = Theme.TitleFont;
            lblTitle.ForeColor = Theme.TextPrimary;

            lblTitle.AutoSize = true;

            lblTitle.Location = new Point(30, 45);


            lblMessage = new Label();

            lblMessage.Text = message;

            lblMessage.Font = Theme.NormalFont;
            lblMessage.ForeColor = Theme.TextSecondary;

            lblMessage.AutoSize = false;

            lblMessage.Size = new Size(350, 60);

            lblMessage.Location = new Point(30, 90);


            btnOk = new RoundedButton();

            btnOk.Text = "OK";

            btnOk.Size = new Size(120, 40);

            btnOk.Location = new Point(145, 160);

            btnOk.Click += BtnOk_Click;


            pnlContent.Controls.Add(lblTitle);
            pnlContent.Controls.Add(lblMessage);
            pnlContent.Controls.Add(btnOk);
        }


        private void BtnOk_Click(object sender, EventArgs e)
        {
            FormAnimator.FadeOut(this, Close);
        }


        public static void Show(string title, string message)
        {
            CustomMessageBox box =
                new CustomMessageBox(title, message);

            box.ShowDialog();
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            FormAnimator.FadeIn(this);
        }
    }
}