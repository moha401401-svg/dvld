using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DVLD.Presentation.UI
{
    public static class Helpers
    {
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        public static GraphicsPath GetRoundedPath(Rectangle rectangle, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            int diameter = radius * 2;

            path.StartFigure();

            path.AddArc(rectangle.X, rectangle.Y, diameter, diameter, 180, 90);
            path.AddArc(rectangle.Right - diameter, rectangle.Y, diameter, diameter, 270, 90);
            path.AddArc(rectangle.Right - diameter, rectangle.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rectangle.X, rectangle.Bottom - diameter, diameter, diameter, 90, 90);

            path.CloseFigure();

            return path;
        }

        public static void SetRoundedRegion(Control control, int radius)
        {
            if (control.Width <= 0 || control.Height <= 0)
                return;

            using (GraphicsPath path = GetRoundedPath(control.ClientRectangle, radius))
            {
                control.Region = new Region(path);
            }
        }

        public static void MakeDraggable(Form form, Control control)
        {
            control.MouseDown += (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(form.Handle, 0xA1, 0x2, 0);
                }
            };
        }

        public static void CenterControl(Control control)
        {
            if (control.Parent == null)
                return;

            control.Left = (control.Parent.ClientSize.Width - control.Width) / 2;
        }

        public static void CenterControl(Control control, int top)
        {
            CenterControl(control);
            control.Top = top;
        }

        public static void CenterInParent(Control control)
        {
            if (control.Parent == null)
                return;

            control.Left = (control.Parent.ClientSize.Width - control.Width) / 2;
            control.Top = (control.Parent.ClientSize.Height - control.Height) / 2;
        }
    }
}
