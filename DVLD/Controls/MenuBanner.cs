using BusinessLayer;
using DVLD.Presentation.UI;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DVLD.Controls
{
    public class MenuBanner : UserControl
    {
        protected PictureBox picture;
  
        protected Label lblTitle;

        protected Label lblDescription;

        protected Timer animationTimer;

        protected Color normalColor =
            Theme.CardBackground;

        private Color hoverColor;

        protected Color currentBorderColor;

        protected Color hoverBorderColor =
            Color.FromArgb(30, 90, 200);

        protected bool isHover;

        protected int radius = 20;

        protected float imageScale = 1f;

        public bool KeepBorder { get; set; }
        public enPermissions Permission { get; set; }
        public event EventHandler BannerClick;

        public Color SelectedBorderColor { get; set; } = Color.Green;

        public Color SelectedBackColor { get; set; } = Color.FromArgb(40, 150, 40);

        public string Title
        {
            get => lblTitle.Text;
            set => lblTitle.Text = value;
        }



        public string Description
        {
            get => lblDescription.Text;
            set => lblDescription.Text = value;
        }

        public Image LightImage { get; set; }

        public Image DarkImage { get; set; }
        public Color NormalThemeColor { get; set; }

        public Color ThemeTextColor { get; set; }

        public Color ThemeDescriptionColor { get; set; }

        public Color ThemeBorderColor { get; set; }


        public Image BannerImage
        {
            get => picture.Image;
            set => picture.Image = value;
        }



        public MenuBanner()
        {
            Width = 260;

            Height = 190;

            DoubleBuffered = true;

            Cursor = Cursors.Hand;

            NormalThemeColor = Theme.CardBackground;

            ThemeTextColor = Theme.TextPrimary;

            ThemeDescriptionColor = Theme.TextSecondary;

            ThemeBorderColor = Theme.BorderColor;
            hoverColor =
                Color.FromArgb(170, 210, 255);

            BackColor = NormalThemeColor;

            InitializeComponents();

            RegisterEvents();

            animationTimer = new Timer();

            animationTimer.Interval = 15;

            animationTimer.Tick += AnimationTimer_Tick;


            currentBorderColor =
                ThemeManager.IsDarkMode ?
                DarkTheme.BorderColor :
                Theme.BorderColor;
        }


        public void ApplyTheme(bool dark)
        {

            currentBorderColor =
                dark ?
                DarkTheme.BorderColor :
                Theme.BorderColor;


            BackColor =
                dark ?
                DarkTheme.CardBackground :
                Theme.CardBackground;


            lblTitle.ForeColor =
                dark ?
                DarkTheme.TextPrimary :
                Theme.TextPrimary;


            lblDescription.ForeColor =
                dark ?
                DarkTheme.TextSecondary :
                Theme.TextSecondary;


            Invalidate();

        }
        protected void InitializeComponents()
        {
            picture = new PictureBox();

            picture.Size = new Size(100, 100);

            picture.Location =
                new Point(
                    (Width - picture.Width) / 2,
                    18);

            picture.SizeMode =
                PictureBoxSizeMode.Zoom;



            lblTitle = new Label();

            lblTitle.Size =
                new Size(220, 30);

            lblTitle.Location =
                new Point(20, 108);

            lblTitle.TextAlign =
                ContentAlignment.MiddleCenter;

            lblTitle.Font =
                new Font(
                    "Segoe UI",
                    13,
                    FontStyle.Bold);

            lblTitle.ForeColor =
             ThemeTextColor;



            lblDescription = new Label();

            lblDescription.Size =
                new Size(220, 40);

            lblDescription.Location =
                new Point(20, 142);

            lblDescription.TextAlign =
                ContentAlignment.TopCenter;

            lblDescription.Font =
                Theme.SmallFont;

            lblDescription.ForeColor =
            ThemeDescriptionColor;



            Controls.Add(picture);

            Controls.Add(lblTitle);

            Controls.Add(lblDescription);
        }



        protected void RegisterEvents()
        {
            MouseEnter += Banner_MouseEnter;
            MouseLeave += Banner_MouseLeave;
            MouseClick += Banner_MouseClick;

            foreach (Control c in Controls)
            {
                c.MouseEnter += Banner_MouseEnter;

                c.MouseLeave += Banner_MouseLeave;

                c.MouseClick += Banner_MouseClick;
            }
        }



        protected void Banner_MouseClick(object sender, MouseEventArgs e)
        {
            BannerClick?.Invoke(this, EventArgs.Empty);
        }



        protected void Banner_MouseEnter(object sender, EventArgs e)
        {
            if (KeepBorder)
            {
                return;
            }
            isHover = true;

            animationTimer.Start();
        }



        protected void Banner_MouseLeave(object sender, EventArgs e)
        {

            if (KeepBorder)
            {
                return;
            }

                isHover = false;

            animationTimer.Start();
        }



        protected virtual void AnimationTimer_Tick(object sender, EventArgs e)
        {
            float speed = .18f;


            if (KeepBorder)
            {
                BackColor =
                    BlendColor(
                        BackColor,
                        SelectedBackColor,
                        speed);


                currentBorderColor =
                    SelectedBorderColor;
            }
            else
            {
                BackColor =
                    BlendColor(
                        BackColor,
                        isHover
                        ? hoverColor
                        : NormalThemeColor,
                        speed);


                currentBorderColor =
                    BlendColor(
                        currentBorderColor,
                        isHover
                        ? hoverBorderColor
                        : Theme.BorderColor,
                        speed);
            }



            if (isHover)
            {
                imageScale =
                    Math.Min(
                        1.07f,
                        imageScale + .02f);
            }
            else
            {
                imageScale =
                    Math.Max(
                        1f,
                        imageScale - .02f);
            }



            picture.Size =
                new Size(
                    (int)(100 * imageScale),
                    (int)(100 * imageScale));



            picture.Location =
                new Point(
                    (Width - picture.Width) / 2,
                    10);



            Invalidate();



            if (Math.Abs(imageScale -
                (isHover ? 1.07f : 1f))
                < .01f)
            {
                animationTimer.Stop();
            }
        }



        protected Color BlendColor(
            Color current,
            Color target,
            float amount)
        {
            return Color.FromArgb(
                current.A + (int)((target.A - current.A) * amount),

                current.R + (int)((target.R - current.R) * amount),

                current.G + (int)((target.G - current.G) * amount),

                current.B + (int)((target.B - current.B) * amount));
        }



        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            Region =
                new Region(
                    Helpers.GetRoundedPath(
                        ClientRectangle,
                        radius));
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
                using (Pen pen =
                    new Pen(
                        currentBorderColor,
                        1.5f))
                {
                    e.Graphics.DrawPath(
                        pen,
                        path);
                }
            }
        }
    }
}