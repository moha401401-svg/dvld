using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 using System.Drawing;
namespace DVLD.Presentation.UI
{
    
       
    
        public static class Theme
        {
            public static readonly Color PrimaryColor = Color.FromArgb(37, 99, 235);
            public static readonly Color PrimaryHoverColor = Color.FromArgb(29, 78, 216);
            public static readonly Color PrimaryPressedColor = Color.FromArgb(30, 64, 175);

            public static readonly Color AppBackground = Color.FromArgb(240, 243, 248);
            public static readonly Color CardBackground = Color.White;
            public static readonly Color SecondaryBackground = Color.FromArgb(248, 250, 252);

            public static readonly Color BorderColor = Color.FromArgb(220, 220, 220);
            public static readonly Color BorderFocusedColor = PrimaryColor;

            public static readonly Color TextPrimary = Color.FromArgb(35, 35, 35);
            public static readonly Color TextSecondary = Color.FromArgb(120, 120, 120);
            public static readonly Color TextLight = Color.White;

            public static readonly Color SuccessColor = Color.FromArgb(22, 163, 74);
            public static readonly Color WarningColor = Color.FromArgb(245, 158, 11);
            public static readonly Color ErrorColor = Color.FromArgb(220, 38, 38);

            public static readonly Font HeaderFont = new Font("Segoe UI", 22F, FontStyle.Bold);
            public static readonly Font TitleFont = new Font("Segoe UI", 16F, FontStyle.Bold);
            public static readonly Font NormalFont = new Font("Segoe UI", 10F, FontStyle.Regular);
            public static readonly Font SmallFont = new Font("Segoe UI", 9F, FontStyle.Regular);
            public static readonly Font ButtonFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            public static readonly Font TextBoxFont = new Font("Segoe UI", 10F, FontStyle.Regular);

            public const int BorderRadius = 18;
            public const int CardRadius = 20;
            public const int ButtonHeight = 45;
            public const int TextBoxHeight = 42;
            public const int ControlSpacing = 15;
            public const int ShadowSize = 6;
            public const int FadeSpeed = 10;
        }
    }


