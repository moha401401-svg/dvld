using BusinessLayer;
using System.Linq;
using System.Windows.Forms;
using DVLD.Presentation.Forms;

namespace DVLD.Presentation.UI
{
    public static class ApplicationSession
    {

        public static void Logout()
        {

            CurrentUser.logout();



            foreach (Form form in Application.OpenForms
                .Cast<Form>()
                .ToList())
            {

                form.Hide();

            }

            RememberME.Logout();

            frmLogin frm =
                new frmLogin();


            frm.Show();

        }

    }
}