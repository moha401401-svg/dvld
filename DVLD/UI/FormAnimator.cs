using System;
using System.Windows.Forms;

namespace DVLD.Presentation.UI
{
    public static class FormAnimator
    {
        public static void FadeIn(Form form)
        {
            form.Opacity = 0;

            Timer timer = new Timer();

            timer.Interval = Theme.FadeSpeed;

            timer.Tick += (s, e) =>
            {
                if (form.Opacity < 1)
                {
                    form.Opacity += 0.05;
                }
                else
                {
                    timer.Stop();
                    timer.Dispose();
                }
            };

            timer.Start();
        }

        public static void FadeOut(Form form, Action action)
        {
            Timer timer = new Timer();

            timer.Interval = Theme.FadeSpeed;

            timer.Tick += (s, e) =>
            {
                if (form.Opacity > 0)
                {
                    form.Opacity -= 0.05;
                }
                else
                {
                    timer.Stop();
                    timer.Dispose();

                    action?.Invoke();
                }
            };

            timer.Start();
        }
    }
}