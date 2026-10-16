using DVLD.Presentation.UI;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DVLD.Controls
{
    public class AccountActionBanner : UserControl
    {
        private Label lblTitle;
        private Label lblDescription;


        private Image bannerImage;


        private Timer animationTimer;


        private bool isHover;


        private float imageScale = 1.2f;
        private float targetScale = 1.2f;


        private Color currentBackColor =
            Theme.CardBackground;

        private Color targetBackColor;


        private Color currentBorderColor =
            Theme.BorderColor;

        private Color targetBorderColor =
            Theme.BorderColor;



        private int radius = 20;

        [Category("Banner Layout")]
        public int ImageOffsetY { get; set; } = 25;

        [Category("Banner Layout")]
        public int ImageBaseSize { get; set; } = 120;

        [Category("Banner Layout")]
        public int TitleOffsetY { get; set; } = 165;

        [Category("Banner Layout")]
        public int DescriptionOffsetY { get; set; } = 215;


        [Browsable(true)]
        [Category("Banner Layout")]
        public Point TitleLocation
        {
            get => lblTitle.Location;
            set
            {
                lblTitle.Location = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Banner Layout")]
        public Size TitleSize
        {
            get => lblTitle.Size;
            set
            {
                lblTitle.Size = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Banner Layout")]
        public Point DescriptionLocation
        {
            get => lblDescription.Location;
            set
            {
                lblDescription.Location = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Banner Layout")]
        public Size DescriptionSize
        {
            get => lblDescription.Size;
            set
            {
                lblDescription.Size = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Banner Layout")]
        public float TitleTextSize
        {
            get => lblTitle.Font.Size;
            set
            {
                lblTitle.Font =
                    new Font(
                        lblTitle.Font.FontFamily,
                        value,
                        lblTitle.Font.Style);

                Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Banner Layout")]
        public float DescriptionTextSize
        {
            get => lblDescription.Font.Size;
            set
            {
                lblDescription.Font =
                    new Font(
                        lblDescription.Font.FontFamily,
                        value,
                        lblDescription.Font.Style);

                Invalidate();
            }
        }

        public Color HoverColor { get; set; }
            = Color.FromArgb(170, 210, 255);



        public Color HoverBorderColor { get; set; }
            = Color.FromArgb(40, 120, 220);



        public event EventHandler BannerClick;



        private bool enabledBanner = true;

        public bool EnabledBanner
        {
            get
            {
                return enabledBanner;
            }

            set
            {
                enabledBanner = value;
                Invalidate();
            }
        }
        public string Title
        {
            get
            {
                return lblTitle.Text;
            }

            set
            {
                lblTitle.Text = value;
            }
        }



        public string Description
        {
            get
            {
                return lblDescription.Text;
            }

            set
            {
                lblDescription.Text = value;
            }
        }



        public Image BannerImage
        {
            get
            {
                return bannerImage;
            }

            set
            {
                bannerImage = value;

                Invalidate();
            }
        }



        public AccountActionBanner()
        {
            Width = 500;

            Height = 330;


            DoubleBuffered = true;
            SetStyle(
    ControlStyles.UserPaint |
    ControlStyles.AllPaintingInWmPaint |
    ControlStyles.OptimizedDoubleBuffer,
    true);

            Cursor =
                Cursors.Hand;



            InitializeComponents();



            animationTimer =
                new Timer();


            animationTimer.Interval = 15;


            animationTimer.Tick +=
                AnimationTimer_Tick;



            MouseMove +=
                AccountActionBanner_MouseMove;


            MouseLeave +=
                AccountActionBanner_MouseLeave;


            MouseClick +=
                AccountActionBanner_MouseClick;



            targetBackColor =
                ThemeManager.IsDarkMode ?
                DarkTheme.CardBackground :
                Theme.CardBackground;


        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);


            e.Graphics.SmoothingMode =
                SmoothingMode.AntiAlias;



            using (GraphicsPath path =
                Helpers.GetRoundedPath(
                    ClientRectangle,
                    radius))
            {

                using (SolidBrush brush =
                    new SolidBrush(
                        currentBackColor))
                {
                    e.Graphics.FillPath(
                        brush,
                        path);
                }



                using (Pen pen =
                    new Pen(
                        currentBorderColor,
                        2))
                {
                    e.Graphics.DrawPath(
                        pen,
                        path);
                }
            }





            if (bannerImage != null)
            {
                int size =
                    (int)(ImageBaseSize * imageScale);

                int x =
                    (Width - size) / 2;

                int y =
                    ImageOffsetY -
                    ((size - ImageBaseSize) / 2);

                Rectangle rect =
                    new Rectangle(
                        x,
                        y,
                        size,
                        size);

                e.Graphics.DrawImage(
                    bannerImage,
                    rect);
            }
        }
        
        private void InitializeComponents()
        {
            lblTitle =
                new Label();

            lblTitle.Size =
                new Size(
                    Width - 40,
                    40);

            lblTitle.Location =new Point(20, TitleOffsetY);

            lblTitle.TextAlign =
                ContentAlignment.MiddleCenter;

            lblTitle.Font =
                new Font(
                    "Segoe UI",
                    18,
                    FontStyle.Bold);

            lblTitle.ForeColor =
                Theme.TextPrimary;

            lblTitle.BackColor =
                Color.Transparent;
            lblDescription = new Label();

            lblDescription.AutoSize = false;

            lblDescription.Size =
                new Size(
                    Width - 40,
                    100);
            lblDescription.Location =
                    new Point(
                        20,
                        DescriptionOffsetY);

            lblDescription.TextAlign =
                ContentAlignment.TopCenter;

            lblDescription.Font =
                new Font(
                    "Segoe UI",
                    11,
                    FontStyle.Regular);

            lblDescription.ForeColor =
                Theme.TextSecondary;

            lblDescription.BackColor =
                Color.Transparent;


            Controls.Add(lblTitle);

            Controls.Add(lblDescription);
        }
        private void AccountActionBanner_MouseMove(
          object sender,
          MouseEventArgs e)
        {

            if (!isHover)
            {

                isHover = true;


                targetScale = 1.08f;



                targetBackColor =
                    ThemeManager.IsDarkMode ?
                    Color.FromArgb(75, 75, 75) :
                    HoverColor;



                targetBorderColor =
                    ThemeManager.IsDarkMode ?
                    Color.FromArgb(120, 120, 120) :
                    HoverBorderColor;



                animationTimer.Start();

            }

        }



        private void AccountActionBanner_MouseLeave(
    object sender,
    EventArgs e)
        {

            isHover = false;

            targetScale = 1f;


            targetBackColor =
                ThemeManager.IsDarkMode ?
                DarkTheme.CardBackground :
                Theme.CardBackground;



            targetBorderColor =
                ThemeManager.IsDarkMode ?
                DarkTheme.BorderColor :
                Theme.BorderColor;



            animationTimer.Start();

        }



        private void AccountActionBanner_MouseClick(
            object sender,
            MouseEventArgs e)
        {

            BannerClick?.Invoke(
                this,
                EventArgs.Empty);

        }





        private void AnimationTimer_Tick(
      object sender,
      EventArgs e)
        {

            float speed = .15f;



            imageScale +=
                (targetScale - imageScale)
                * speed;




            currentBackColor =
                BlendColor(
                    currentBackColor,
                    targetBackColor,
                    speed);




            currentBorderColor =
                BlendColor(
                    currentBorderColor,
                    targetBorderColor,
                    speed);




            BackColor =
                currentBackColor;



            Invalidate();




            if (Math.Abs(
                imageScale - targetScale)
                < .01f)
            {

                imageScale =
                    targetScale;


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
                (int)
                ((target.A - current.A)
                * amount),


                current.R +
                (int)
                ((target.R - current.R)
                * amount),


                current.G +
                (int)
                ((target.G - current.G)
                * amount),


                current.B +
                (int)
                ((target.B - current.B)
                * amount)

            );

        }






        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);


            Region =
                new Region(
                    Helpers.GetRoundedPath(
                        ClientRectangle,
                        radius));


            if (lblTitle != null)
            {
                lblTitle.Size =
                    new Size(
                        Width - 40,
                        40);
            }


            if (lblDescription != null)
            {
                lblDescription.Size =
                    new Size(
                        Width - 40,
                        300);
            }
        }

    }
}