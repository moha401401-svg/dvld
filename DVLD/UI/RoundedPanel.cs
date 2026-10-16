using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DVLD.Presentation.UI
{
    public class RoundedPanel : Panel
    {
        private int radius = Theme.CardRadius;
        private Color borderColor = Theme.BorderColor;
        private int borderSize = 1;

        public int Radius
        {
            get { return radius; }
            set
            {
                radius = value;
                UpdateRegion();
                Invalidate();
            }
        }

        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                borderSize = value;
                Invalidate();
            }
        }

        public RoundedPanel()
        {
            DoubleBuffered = true;
            BackColor = Theme.CardBackground;
        }

        protected override void OnResize(System.EventArgs eventargs)
        {
            base.OnResize(eventargs);
            UpdateRegion();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(
                borderSize,
                borderSize,
                Width - (borderSize * 2),
                Height - (borderSize * 2)
            );

            using (GraphicsPath path = Helpers.GetRoundedPath(rect, radius))
            using (Pen pen = new Pen(borderColor, borderSize))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }

        private void UpdateRegion()
        {
            if (Width > 0 && Height > 0)
            {
                Region = new Region(
                    Helpers.GetRoundedPath(ClientRectangle, radius)
                );
            }
        }
    }
}
