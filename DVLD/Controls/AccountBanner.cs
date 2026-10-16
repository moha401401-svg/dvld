using DVLD.Presentation.UI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Controls
{
    public class AccountBanner : MenuBanner
    {

        private bool isHover;

        private float imageScale = 1f;

        private Timer animationTimer;



        public AccountBanner()
        {

            Width = 380;

            Height = 110;



            picture.Size =
                new Size(70, 70);


            picture.Location =
                new Point(20, 20);



            lblTitle.Size =
                new Size(250, 30);


            lblTitle.Location =
                new Point(110, 20);



            lblTitle.TextAlign =
                ContentAlignment.MiddleLeft;



            lblTitle.Font =
                new Font(
                    "Segoe UI",
                    14,
                    FontStyle.Bold);



            lblDescription.Size =
                new Size(250, 25);



            lblDescription.Location =
                new Point(110, 55);



            lblDescription.TextAlign =
                ContentAlignment.MiddleLeft;



            lblDescription.Font =
                Theme.SmallFont;



            Title =
                "Manage Account";



            animationTimer =
                new Timer();


            animationTimer.Interval =
                15;


            animationTimer.Tick +=
                AnimationTimer_Tick;



            MouseEnter +=
                AccountBanner_MouseEnter;


            MouseLeave +=
                AccountBanner_MouseLeave;


            foreach (Control c in Controls)
            {
                c.MouseEnter +=
                    AccountBanner_MouseEnter;


                c.MouseLeave +=
                    AccountBanner_MouseLeave;
            }

        }




        public string FullName
        {
            get
            {
                return Description;
            }

            set
            {
                Description = value;
            }
        }





        public Image ProfileImage
        {
            get
            {
                return BannerImage;
            }

            set
            {
                BannerImage = value;
            }
        }






        private void AccountBanner_MouseEnter(
            object sender,
            EventArgs e)
        {

            isHover = true;

            animationTimer.Start();

        }





        private void AccountBanner_MouseLeave(
            object sender,
            EventArgs e)
        {

            isHover = false;

            animationTimer.Start();

        }







        protected override void AnimationTimer_Tick(
            object sender,
            EventArgs e)
        {

            float speed = 0.18f;



            Color normalColor =
                ThemeManager.IsDarkMode ?
                DarkTheme.CardBackground :
                Theme.CardBackground;



            Color hoverColor =
                ThemeManager.IsDarkMode ?
                Color.FromArgb(
                    70,
                    70,
                    70)
                :
                Color.FromArgb(
                    190,
                    230,
                    200);





            Color normalBorder =
                ThemeManager.IsDarkMode ?
                DarkTheme.BorderColor :
                Theme.BorderColor;



            Color hoverBorder =
                ThemeManager.IsDarkMode ?
                Color.FromArgb(
                    130,
                    130,
                    130)
                :
                Color.FromArgb(
                    46,
                    139,
                    87);







            BackColor =
                BlendColor(
                    BackColor,
                    isHover ?
                    hoverColor :
                    normalColor,
                    speed);






            currentBorderColor =
                BlendColor(
                    currentBorderColor,
                    isHover ?
                    hoverBorder :
                    normalBorder,
                    speed);






            if (isHover)
            {

                imageScale =
                    Math.Min(
                        1.05f,
                        imageScale + 0.03f);

            }

            else
            {

                imageScale =
                    Math.Max(
                        1f,
                        imageScale - 0.03f);

            }







            int size =
                (int)
                (70 * imageScale);





            picture.Size =
                new Size(
                    size,
                    size);





            // تكبير من نفس المكان
            picture.Location =
                new Point(
                    20 - (size - 70) / 2,
                    20 - (size - 70) / 2);







            Invalidate();





            if (Math.Abs(
                imageScale -
                (isHover ? 1.05f : 1f))
                < 0.01f)
            {

                animationTimer.Stop();

            }

        }








        private Color BlendColor(
            Color current,
            Color target,
            float amount)
        {

            return Color.FromArgb(

                current.A +
                (int)((target.A -
                current.A) * amount),


                current.R +
                (int)((target.R -
                current.R) * amount),


                current.G +
                (int)((target.G -
                current.G) * amount),


                current.B +
                (int)((target.B -
                current.B) * amount)

            );

        }

    }
}