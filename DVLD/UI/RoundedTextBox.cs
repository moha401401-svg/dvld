using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DVLD.Presentation.UI
{
    public enum ValidationState
    {
        Normal,
        Valid,
        Invalid
    }


    public class RoundedTextBox : UserControl
    {
        public int MinLength { get; set; } = 0;
        public new event EventHandler TextChanged;
        public bool OnlyNumbers { get; set; }

        public bool OnlyLetters { get; set; }

        public bool EmailMode { get; set; }
        private TextBox textBox;
        private PictureBox picWarning;
        private ToolTip toolTip;


        private int radius = 15;

        private Color borderColor = Theme.BorderColor;
        private Color focusBorderColor = Theme.PrimaryColor;


        private string placeholder = "";
        private Color placeholderColor = Theme.TextSecondary;

        private bool isPlaceholder = false;
        private bool usePassword = false;


        private ValidationState state =
            ValidationState.Normal;


        private string validationMessage = "";



        public RoundedTextBox()
        {
            Height = Theme.TextBoxHeight;

            Width = 250;

            BackColor = Theme.CardBackground;

            DoubleBuffered = true;



            textBox = new TextBox();

            textBox.BorderStyle =
                BorderStyle.None;

            textBox.Font =
                Theme.TextBoxFont;

            textBox.ForeColor =
                Theme.TextPrimary;

            textBox.BackColor =
                Theme.CardBackground;


            textBox.Location =
                 new Point(15, 10);

            textBox.Width =
                Width - 45;


            Controls.Add(textBox);

            textBox.TextChanged += TextBox_TextChanged;







            picWarning = new PictureBox();

            picWarning.Size =
                new Size(18, 18);


            picWarning.Location =
                new Point(
                    Width - 28,
                    11
                );


            picWarning.SizeMode =
                PictureBoxSizeMode.Zoom;


            picWarning.Visible =
                false;


            Controls.Add(picWarning);



            toolTip =
                new ToolTip();



            textBox.Enter +=
                TextBox_Enter;


            textBox.Leave +=
                TextBox_Leave;

            textBox.KeyPress += TextBox_KeyPress;
            Resize +=
                RoundedTextBox_Resize;


            UpdateRegion();
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            TextChanged?.Invoke(this, e);
        }
        
        
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (OnlyNumbers)
            {
                if (!char.IsDigit(e.KeyChar) &&
                    !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }


            if (OnlyLetters)
            {
                if (!char.IsLetter(e.KeyChar) &&
                    !char.IsControl(e.KeyChar) &&
                    e.KeyChar != ' ')
                {
                    e.Handled = true;
                }
            }


            if (EmailMode)
            {
                if (!char.IsLetterOrDigit(e.KeyChar) &&
                    e.KeyChar != '@' &&
                    e.KeyChar != '.' &&
                    !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        public override string Text
        {
            get
            {
                return isPlaceholder ? "" : textBox.Text;
            }
            set
            {
                isPlaceholder = false;

                textBox.ForeColor = Theme.TextPrimary;

                textBox.UseSystemPasswordChar = usePassword;

                textBox.Text = value;
            }
        }

        public int MaxLength
        {
            get
            {
                return textBox.MaxLength;
            }

            set
            {
                textBox.MaxLength = value;
            }
        }


        public string Placeholder
        {
            get
            {
                return placeholder;
            }

            set
            {
                placeholder = value;
                ShowPlaceholder();
            }
        }

        public Color LightBackColor { get; set; } = Color.White;

        public Color DarkBackColor { get; set; } =
            Color.FromArgb(50, 50, 50);


        public Color LightForeColor { get; set; } =
            Color.Black;

        public Color DarkForeColor { get; set; } =
            Color.WhiteSmoke;



        public void ApplyTheme(bool dark)
        {
            BackColor =
                dark ?
                DarkBackColor :
                LightBackColor;


            ForeColor =
                dark ?
                DarkForeColor :
                LightForeColor;


            Invalidate();
        }



        public bool UsePassword
        {
            get
            {
                return usePassword;
            }

            set
            {
                usePassword = value;


                if (!isPlaceholder)
                    textBox.UseSystemPasswordChar =
                        value;
            }
        }




        public ValidationState State
        {
            get
            {
                return state;
            }

            set
            {
                state = value;

                switch (state)
                {
                    case ValidationState.Normal:
                        borderColor = Theme.BorderColor;
                        break;

                    case ValidationState.Valid:
                        borderColor = Color.SeaGreen;
                        break;

                    case ValidationState.Invalid:
                        borderColor = Color.IndianRed;
                        break;
                }

                UpdateWarning();

                Invalidate();
            }
        }
     





        public string ValidationMessage
        {
            get
            {
                return validationMessage;
            }

            set
            {
                validationMessage = value;


                toolTip.SetToolTip(
                    picWarning,
                    validationMessage
                );
            }
        }





        private void UpdateWarning()
        {
            if (state == ValidationState.Invalid)
            {
                picWarning.Visible = true;

                picWarning.Image =
                    SystemIcons.Warning.ToBitmap();
            }
            else
            {
                picWarning.Visible = false;
            }
        }





        private void RoundedTextBox_Resize(
       object sender,
       EventArgs e)
        {
            if (textBox == null)
                return;


            textBox.Width =
                Width - 45;


            if (textBox.Multiline)
            {
                textBox.Height =
                    Height - 20;
            }


            if (picWarning != null)
            {
                picWarning.Location =
                    new Point(
                        Width - 28,
                        11);
            }


            UpdateRegion();
        }



     





        private void TextBox_Enter(
            object sender,
            EventArgs e)
        {
            HidePlaceholder();


            if (state == ValidationState.Normal)
                borderColor =
                    focusBorderColor;


            Invalidate();
        }





        private void TextBox_Leave(
            object sender,
            EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox.Text))
                ShowPlaceholder();


            if (state == ValidationState.Normal)
                borderColor =
                    Theme.BorderColor;


            Invalidate();
        }





        private void ShowPlaceholder()
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                isPlaceholder = true;

                textBox.Text =
                    placeholder;

                textBox.ForeColor =
                    placeholderColor;


                textBox.UseSystemPasswordChar =
                    false;
            }
        }





        private void HidePlaceholder()
        {
            if (isPlaceholder)
            {
                isPlaceholder = false;


                textBox.Text =
                    "";


                textBox.ForeColor =
                    Theme.TextPrimary;


                textBox.UseSystemPasswordChar =
                    usePassword;
            }
        }





        protected override void OnPaint(
            PaintEventArgs e)
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
                        borderColor,
                        2))
                {
                    e.Graphics.DrawPath(
                        pen,
                        path);
                }
            }
        }





        private void UpdateRegion()
        {
            if (Width > 0 &&
               Height > 0)
            {
                Region =
                    new Region(
                        Helpers.GetRoundedPath(
                            ClientRectangle,
                            radius));
            }
        }





        public void Clear()
        {
            textBox.Clear();
        }




        public bool Multiline
        {
            get
            {
                return textBox.Multiline;
            }

            set
            {
                textBox.Multiline = value;

                if (value)
                {
                    textBox.ScrollBars =
                        ScrollBars.Vertical;

                    textBox.Height =
                        Height - 20;

                    textBox.Location =
                        new Point(15, 10);
                }
            }
        }
        public void FocusText()
        {
            textBox.Focus();
        }
    }
}