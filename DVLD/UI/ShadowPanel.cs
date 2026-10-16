using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DVLD.Presentation.UI
{
    public class ShadowPanel : Panel
    {
        private int radius = Theme.CardRadius;
        private int shadowSize = Theme.ShadowSize;
        private Color shadowColor = Color.FromArgb(50, 0, 0, 0);

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

        public int ShadowSize
        {
            get
            {
                return shadowSize;
            }
            set
            {
                shadowSize = value;
                Invalidate();
            }
        }

        public Color ShadowColor
        {
            get
            {
                return shadowColor;
            }
            set
            {
                shadowColor = value;
                Invalidate();
            }
        }

        public ShadowPanel()
        {
            DoubleBuffered = true;
            BackColor = Theme.CardBackground;
            Padding = new Padding(ShadowSize);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            UpdateRegion();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle shadowRectangle = new Rectangle(
                shadowSize,
                shadowSize,
                Width - shadowSize * 2,
                Height - shadowSize * 2
            );

            using (GraphicsPath shadowPath = Helpers.GetRoundedPath(shadowRectangle, radius))
            using (SolidBrush shadowBrush = new SolidBrush(shadowColor))
            {
                e.Graphics.FillPath(shadowBrush, shadowPath);
            }

            Rectangle panelRectangle = new Rectangle(
                0,
                0,
                Width - shadowSize,
                Height - shadowSize
            );

            using (GraphicsPath panelPath = Helpers.GetRoundedPath(panelRectangle, radius))
            using (SolidBrush panelBrush = new SolidBrush(BackColor))
            {
                e.Graphics.FillPath(panelBrush, panelPath);
            }
        }

        private void UpdateRegion()
        {
            if (Width > 0 && Height > 0)
            {
                Region = new Region(
                    Helpers.GetRoundedPath(
                        ClientRectangle,
                        radius
                    )
                );
            }
        }
    }
}