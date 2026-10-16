using System;
using System.Drawing;
using System.Windows.Forms;
using DVLD.Controls;
namespace DVLD.Presentation.UI
{
    public static class ThemeManager
    {

        public static bool IsDarkMode { get; private set; }



        public static void ToggleTheme()
        {

            IsDarkMode =
                !IsDarkMode;


            ThemeSettings.Save(
                IsDarkMode);



            foreach (Form form in Application.OpenForms)
            {
                ApplyTheme(form);
                form.Refresh();
            }

        }


        private static void ApplyBannerTheme(MenuBanner banner)
        {

            if (IsDarkMode)
            {

                banner.NormalThemeColor =
                    DarkTheme.CardBackground;


                banner.ThemeTextColor =
                    DarkTheme.TextPrimary;


                banner.ThemeDescriptionColor =
                    DarkTheme.TextSecondary;


                banner.ThemeBorderColor =
                    DarkTheme.BorderColor;

            }
            else
            {

                banner.NormalThemeColor =
                    Theme.CardBackground;


                banner.ThemeTextColor =
                    Theme.TextPrimary;


                banner.ThemeDescriptionColor =
                    Theme.TextSecondary;


                banner.ThemeBorderColor =
                    Theme.BorderColor;

            }

            if (IsDarkMode)
            {
                if (banner.DarkImage != null)
                    banner.BannerImage = banner.DarkImage;
            }
            else
            {
                if (banner.LightImage != null)
                    banner.BannerImage = banner.LightImage;
            }

            banner.BackColor =
                banner.NormalThemeColor;


            banner.Refresh();

        }


        public static void LoadTheme()
        {
            IsDarkMode =
                ThemeSettings.Load();
        }
        public static void ApplyTheme(Form form)
        {

            form.BackColor =
                IsDarkMode ?
                DarkTheme.AppBackground :
                Theme.AppBackground;



            foreach (Control control in form.Controls)
            {
                ApplyControlTheme(control);
            }

        }

        private static void ApplyControlTheme(Control control)
        {

            if (control is MenuBanner banner)
            {

                ApplyBannerTheme(banner);

            }

        



            else if (control is AccountActionBanner accountBanner)
            {

                accountBanner.BackColor =
                    IsDarkMode ?
                    DarkTheme.CardBackground :
                    Theme.CardBackground;


                accountBanner.Refresh();

            }



            else if (control is RoundedTextBox roundedTextBox)
            {

                roundedTextBox.BackColor =
                    IsDarkMode ?
                    DarkTheme.CardBackground :
                    Color.White;



                roundedTextBox.ForeColor =
                    IsDarkMode ?
                    DarkTheme.TextPrimary :
                    Color.Black;



                roundedTextBox.Refresh();

            }



            else if (control is RoundedButton roundedButton)
            {

                roundedButton.BackColor =
                    IsDarkMode ?
                    DarkTheme.CardBackground :
                    Theme.CardBackground;



                roundedButton.ForeColor =
                    IsDarkMode ?
                    DarkTheme.TextPrimary :
                    Theme.TextPrimary;



                roundedButton.Refresh();

            }



            else if (control is Label label)
            {

                label.ForeColor =
                    IsDarkMode ?
                    DarkTheme.TextPrimary :
                    Theme.TextPrimary;

            }



            else if (control is Panel panel)
            {

                panel.BackColor =
                    IsDarkMode ?
                    DarkTheme.AppBackground :
                    Theme.AppBackground;

            }



            else if (control is TextBox textBox)
            {

                textBox.BackColor =
                    IsDarkMode ?
                    DarkTheme.CardBackground :
                    Color.White;


                textBox.ForeColor =
                    IsDarkMode ?
                    DarkTheme.TextPrimary :
                    Color.Black;

            }



            foreach (Control child in control.Controls)
            {
                ApplyControlTheme(child);
            }

        }


    }
}