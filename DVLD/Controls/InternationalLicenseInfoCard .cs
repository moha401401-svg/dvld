using DVLD.Business.Models;
using DVLD.Presentation.UI;
using BusinessLayer.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Controls
{
    public class InternationalLicenseInfoCard : UserControl
    {
        private InternationalLicenses_View _license;


        private PictureBox picDriver;

        private Label lblTitle;


        private Label lblInternationalIDTitle;
        private Label lblInternationalIDValue;

        private Label lblLocalLicenseIDTitle;
        private Label lblLocalLicenseIDValue;

        private Label lblDriverIDTitle;
        private Label lblDriverIDValue;

        private Label lblDriverNameTitle;
        private Label lblDriverNameValue;

        private Label lblIssueDateTitle;
        private Label lblIssueDateValue;

        private Label lblExpirationDateTitle;
        private Label lblExpirationDateValue;

        private Label lblActiveTitle;
        private Label lblActiveValue;



        public InternationalLicenseInfoCard()
        {
            InitializeControl();
            InitializeUI();
        }



        private void InitializeControl()
        {
            Dock =
                DockStyle.Fill;

            Height =
                250;

            BackColor =
                Theme.CardBackground;

            Padding =
                new Padding(15);
        }



        private void InitializeUI()
        {

            lblTitle =
                CreateTitle(
                    "🌍 International License Information");


            lblTitle.Location =
                new Point(
                    200,
                    15);

            lblTitle.Size =
                new Size(
                    500,
                    35);

            Controls.Add(
                lblTitle);



            // Image Left

            picDriver =
                new PictureBox();

            picDriver.Location =
                new Point(
                    20,
                    55);

            picDriver.Size =
                new Size(
                    140,
                    170);

            picDriver.SizeMode =
                PictureBoxSizeMode.Zoom;

            Controls.Add(
                picDriver);



            int y = 60;



            CreateRow(
                "🌍 International ID",
                out lblInternationalIDTitle,
                out lblInternationalIDValue,
                y);

            y += 35;



            CreateRow(
                "🪪 Local License ID",
                out lblLocalLicenseIDTitle,
                out lblLocalLicenseIDValue,
                y);

            y += 35;



            CreateRow(
                "🆔 Driver ID",
                out lblDriverIDTitle,
                out lblDriverIDValue,
                y);

            y += 35;



            CreateRow(
                "👤 Driver Name",
                out lblDriverNameTitle,
                out lblDriverNameValue,
                y);

            y += 35;



            CreateRow(
                "📅 Issue Date",
                out lblIssueDateTitle,
                out lblIssueDateValue,
                y);



            y += 35;



            CreateRow(
                "⏳ Expiration Date",
                out lblExpirationDateTitle,
                out lblExpirationDateValue,
                y);



            y += 35;



            CreateRow(
                "🟢 Active",
                out lblActiveTitle,
                out lblActiveValue,
                y);
        }



        private void CreateRow(
            string text,
            out Label title,
            out Label value,
            int y)
        {

            title =
                CreateLabel(text, true);


            value =
                CreateLabel("", false);



            title.Location =
                new Point(
                    200,
                    y);



            value.Location =
                new Point(
                    370,
                    y);



            Controls.Add(title);
            Controls.Add(value);
        }




        public void LoadInternationalLicense( InternationalLicenses_View license)
        {

            _license = license;


            if (_license == null)
                return;



         

            int PersonID= InternationalLicenses.GetPersonID( _license.InternationalLicenseID );


            People person =
                People.GetPerson( PersonID);



            lblInternationalIDValue.Text =
                _license.InternationalLicenseID
                .ToString();



            lblLocalLicenseIDValue.Text =
                _license.IssuedUsingLocalLicenseID
                .ToString();



            lblDriverIDValue.Text =
                _license.DriverID
                .ToString();



            lblDriverNameValue.Text =
                person.FirstName+" "+person.SecondName+" "+person.ThirdName+" "+person.LastName;



            lblIssueDateValue.Text =
                _license.IssueDate
                .ToString("dd/MM/yyyy");



            lblExpirationDateValue.Text =
                _license.ExpirationDate
                .ToString("dd/MM/yyyy");



            lblActiveValue.Text =
                _license.IsActive
                ? "Yes"
                : "No";



            if (!string.IsNullOrEmpty(
                person.ImagePath))
            {
                picDriver.Image =
                    Image.FromFile(
                        person.ImagePath);
            }
        }




        private Label CreateLabel(
            string text,
            bool title)
        {

            Label lbl =
                new Label();


            lbl.Text =
                text;


            lbl.Font =
                new Font(
                    "Segoe UI",
                    10,
                    title
                    ? FontStyle.Bold
                    : FontStyle.Regular);


            lbl.ForeColor =
                title
                ? Theme.TextPrimary
                : Theme.TextSecondary;



            lbl.Size =
                new Size(
                    160,
                    25);



            return lbl;
        }



        private Label CreateTitle(
            string text)
        {
            Label lbl =
                new Label();


            lbl.Text =
                text;


            lbl.Font =
                new Font(
                    "Segoe UI",
                    15,
                    FontStyle.Bold);


            lbl.ForeColor =
                Theme.TextPrimary;


            return lbl;
        }
    }
}