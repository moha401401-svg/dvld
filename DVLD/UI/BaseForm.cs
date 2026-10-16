using System;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Presentation.UI
{
    public class BaseForm : Form
    {
        private Panel headerPanel;

        private Button minimizeButton;
        private Button maximizeButton;
        private Button closeButton;

        private bool isMaximized = false;

        public bool ShowWindowButtons { get; set; } = true;


        public BaseForm()
        {
            Load += BaseForm_Load;
            FormBorderStyle = FormBorderStyle.None;

            StartPosition = FormStartPosition.CenterScreen;

            BackColor = Theme.AppBackground;

            DoubleBuffered = true;

            CreateHeader();

            Resize += BaseForm_Resize;
        }

        private void BaseForm_Load(
            object sender,
            EventArgs e)
        {

            ThemeManager.ApplyTheme(this);

        }
        private void CreateHeader()
        {
            headerPanel = new Panel();

            headerPanel.Dock = DockStyle.Top;

            headerPanel.Height = 40;

            headerPanel.BackColor =
                Theme.AppBackground;


            Controls.Add(headerPanel);


            closeButton = CreateButton("X");
            

            closeButton.Dock = DockStyle.Right;

            closeButton.Click += (s, e) =>
            {
                Close();
            };


            maximizeButton = CreateButton("□");

            maximizeButton.Dock = DockStyle.Right;

            maximizeButton.Click += (s, e) =>
            {
                ToggleMaximize();
            };


            minimizeButton = CreateButton("—");

            minimizeButton.Dock = DockStyle.Right;

            minimizeButton.Click += (s, e) =>
            {
                WindowState =
                    FormWindowState.Minimized;
            };


            headerPanel.Controls.Add(minimizeButton);
            headerPanel.Controls.Add(maximizeButton);
            headerPanel.Controls.Add(closeButton);


            Helpers.MakeDraggable(this, headerPanel);
        }


        private Button CreateButton(string text)
        {
            Button btn = new Button();

            btn.Text = text;

            btn.Font =
                new Font(
                    "Segoe UI",
                    12,
                    FontStyle.Bold
                );

            btn.ForeColor =
                Theme.TextSecondary;

            btn.BackColor =
                Theme.AppBackground;

            btn.FlatStyle =
                FlatStyle.Flat;

            btn.FlatAppearance.BorderSize = 0;

            btn.Width = 45;

            btn.Cursor = Cursors.Hand;


            btn.MouseEnter += (s, e) =>
            {
                if (btn == closeButton)
                {
                    btn.BackColor =
                        Color.Red;

                    btn.ForeColor =
                        Color.White;
                }
                else
                {
                    btn.BackColor =
                        Color.FromArgb(230, 230, 230);
                }
            };


            btn.MouseLeave += (s, e) =>
            {
                btn.BackColor =
                    Theme.AppBackground;

                btn.ForeColor =
                    Theme.TextSecondary;
            };


            return btn;
        }
        private void ToggleMaximize()
        {
            if (WindowState ==
                FormWindowState.Maximized)
            {
                WindowState =
                    FormWindowState.Normal;

                maximizeButton.Text = "□";
            }
            else
            {
                WindowState =
                    FormWindowState.Maximized;

                maximizeButton.Text = "❐";
            }
        }


        private void BaseForm_Resize(
            object sender,
            EventArgs e)
        {
            if (WindowState ==
                FormWindowState.Maximized)
            {
                isMaximized = true;
            }
            else
            {
                isMaximized = false;
            }
        }
    }
}