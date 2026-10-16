
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DVLD.Presentation.UI
{
    public class RoundedButton : Button
    {
        private int radius = 15;

        private Color normalColor =
            Color.FromArgb(60, 80, 90);

        private Color hoverColor =
            Color.FromArgb(80, 130, 170);

        private Color pressedColor =
            Color.FromArgb(45, 65, 75);


        public int Radius
        {
            get
            {
                return radius;
            }

            set
            {
                radius = value;
                UpdateRegion();
                Invalidate();
            }
        }


        public Color NormalColor
        {
            get
            {
                return normalColor;
            }

            set
            {
                normalColor = value;
                BackColor = normalColor;
                Invalidate();
            }
        }


        public Color HoverColor
        {
            get
            {
                return hoverColor;
            }

            set
            {
                hoverColor = value;
                Invalidate();
            }
        }


        public Color PressedColor
        {
            get
            {
                return pressedColor;
            }

            set
            {
                pressedColor = value;
                Invalidate();
            }
        }


        public RoundedButton()
        {
            FlatStyle =
                FlatStyle.Flat;

            FlatAppearance.BorderSize =
                0;

            UseVisualStyleBackColor =
                false;

            BackColor =
                normalColor;

            ForeColor =
                Color.White;

            Cursor =
                Cursors.Hand;

            DoubleBuffered =
                true;

            TabStop =
                false;
        }


        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            BackColor =
                hoverColor;

            Invalidate();
        }


        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            BackColor =
                normalColor;

            Invalidate();
        }


        protected override void OnMouseDown(
            MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Left)
            {
                BackColor =
                    pressedColor;

                Invalidate();
            }
        }


        protected override void OnMouseUp(
            MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (e.Button == MouseButtons.Left)
            {
                if (ClientRectangle.Contains(
                    PointToClient(Cursor.Position)))
                {
                    BackColor =
                        hoverColor;
                }
                else
                {
                    BackColor =
                        normalColor;
                }

                Invalidate();
            }
        }


        protected override void OnPaint(
            PaintEventArgs e)
        {
            e.Graphics.SmoothingMode =
                SmoothingMode.AntiAlias;


            using (GraphicsPath path =
                Helpers.GetRoundedPath(
                    ClientRectangle,
                    radius))
            {
                using (SolidBrush brush =
                    new SolidBrush(BackColor))
                {
                    e.Graphics.FillPath(
                        brush,
                        path);
                }
            }


            TextRenderer.DrawText(
                e.Graphics,
                Text,
                Font,
                ClientRectangle,
                ForeColor,
                TextFormatFlags.HorizontalCenter |
                TextFormatFlags.VerticalCenter |
                TextFormatFlags.NoPadding);
        }


        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            UpdateRegion();
        }


        private void UpdateRegion()
        {
            if (Width <= 0 ||
                Height <= 0)
                return;


            using (GraphicsPath path =
                Helpers.GetRoundedPath(
                    ClientRectangle,
                    radius))
            {
                Region =
                    new Region(path);
            }
        }
    }
}

