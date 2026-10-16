using BusinessLayer;
using BusinessLayer.Models;
using DVLD.Business;
using DVLD.Business.Models;
using DVLD.Controls;
using DVLD.Presentation.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace DVLD.Forms
{
    public class frmAddLocalLicense : BaseForm
    {

        private Panel pnlPersonSelection;
        private Panel pnlLicenseDetails;
        private Panel pnlApplicationInfo;
        private int personID;
        private Label lblApplicationIDValue;
        private Label lblApplicationDateValue;
        private ComboBox cmbLicenseClass;
        private Label lblApplicationFeesValue;
        private int LDLID;
        private Label lblCreatedByValue;
        private DataGridView dgv;
        private Label lblTitle;
        private DataTable allLicenseClasses;
        private InfoSelectorControl personSelector;
        private RoundedButton btnCancel;
        private RoundedButton btnNext;

        private enApplicationType type;
        public frmAddLocalLicense()
        {
            InitializeForm();

            InitializeUI();

            InitializeButtons();

            InitializeApplicationPanel();

            LoadPeople();
        }
        private void InitializeForm()
        {
            Text =
                "Add Local Driving License";


            StartPosition =
                FormStartPosition.CenterScreen;


            ClientSize =
                new Size(1250, 720);


            MinimumSize =
                new Size(1100, 650);


            BackColor =
                Theme.AppBackground;
        }
        private void SearchGrid_RowClicked()
        {
             personID= Convert.ToInt32(dgv.CurrentRow.Cells["PersonID"].Value); 

            
            RefreshLicenseClasses(personID);
        }
        private void RefreshLicenseClasses(int personID)
        {
            HashSet<int> blocked =
                LicenseClasses.BlockedClasses(personID);

            DataTable filtered =
                allLicenseClasses.Clone();

            foreach (DataRow row in allLicenseClasses.Rows)
            {
                int classID =
                    Convert.ToInt32(row["LicenseClassID"]);

                if (!blocked.Contains(classID))
                {
                    filtered.ImportRow(row);
                }
            }

            cmbLicenseClass.DataSource = null;
            cmbLicenseClass.DisplayMember = "ClassName";
            cmbLicenseClass.ValueMember = "LicenseClassID";
            cmbLicenseClass.DataSource = filtered;
        }
        private void InitializeUI()
        {

            lblTitle =
                new Label();


            lblTitle.Text =
                "Add Local Driving License";


            lblTitle.Font =
                new Font(
                    "Segoe UI",
                    20,
                    FontStyle.Bold);


            lblTitle.ForeColor =
                Theme.TextPrimary;


            lblTitle.Dock =
                DockStyle.Top;


            lblTitle.Height =
                70;


            lblTitle.TextAlign =
                ContentAlignment.MiddleCenter;



            Controls.Add(lblTitle);





            pnlPersonSelection =
                new Panel();


            pnlPersonSelection.Location =
                new Point(30, 80);



            pnlPersonSelection.Size =
                new Size(
                    ClientSize.Width - 60,
                    ClientSize.Height - 160);



            pnlPersonSelection.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;



            pnlPersonSelection.BackColor =
                Theme.CardBackground;



            Controls.Add(
                pnlPersonSelection);







            pnlLicenseDetails =
                new Panel();


            pnlLicenseDetails.Location =
                pnlPersonSelection.Location;



            pnlLicenseDetails.Size =
                pnlPersonSelection.Size;



            pnlLicenseDetails.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;



            pnlLicenseDetails.BackColor =
                Theme.CardBackground;



            pnlLicenseDetails.Visible =
                false;



            Controls.Add(
                pnlLicenseDetails);




            InitializePersonSelector();

        }
        private void InitializePersonSelector()
        {

            personSelector =
                new InfoSelectorControl();



            personSelector.Dock =
                DockStyle.Fill;

            personSelector.InfoCard = new PersonInfoCard();

            personSelector.LoadSelectedItem =
                id =>
                {
                    People person =
                        People.GetPerson(id);

                    ((PersonInfoCard)personSelector.InfoCard).LoadPerson(person);
                };

                    personSelector.Padding =
                new Padding(20);



            personSelector.InfoColumnName =
                "PersonID";



            personSelector.SearchColumns =
                new Dictionary<string, string>
                {
                    {
                        "Person ID",
                        "PersonID"
                    },

                    {
                        "Full Name",
                        "FullName"
                    },

                    {
                        "Phone",
                        "Phone"
                    },

                    {
                        "National No",
                        "NationalNo"
                    }
                };



            pnlPersonSelection.Controls.Add(
                personSelector);
            dgv = personSelector.dgv;
        }
        private void InitializeButtons()
        {

            btnCancel =
                new RoundedButton();



            btnCancel.Text =
                "Cancel";



            btnCancel.Size =
                new Size(130, 45);



            btnCancel.Location =
                new Point(
                    ClientSize.Width - 320,
                    ClientSize.Height - 60);



            btnCancel.Anchor =
                AnchorStyles.Bottom |
                AnchorStyles.Right;



            btnCancel.NormalColor =
                Color.FromArgb(
                    100,
                    100,
                    100);



            btnCancel.Click +=
                BtnCancel_Click;



            Controls.Add(
                btnCancel);

            



            btnNext =
                new RoundedButton();



            btnNext.Text =
                "Next";



            btnNext.Size =
                new Size(130, 45);



            btnNext.Location =
                new Point(
                    ClientSize.Width - 170,
                    ClientSize.Height - 60);



            btnNext.Anchor =
                AnchorStyles.Bottom |
                AnchorStyles.Right;



            btnNext.NormalColor =
                Color.CornflowerBlue;



            btnNext.Click +=
                BtnNext_Click;



            Controls.Add(
                btnNext);

        }
        private void InitializeApplicationPanel()
        {

            pnlApplicationInfo =
                new Panel();



            pnlApplicationInfo.Dock =
                DockStyle.Fill;



            pnlApplicationInfo.BackColor =
                Theme.CardBackground;



            pnlLicenseDetails.Controls.Add(
                pnlApplicationInfo);



            CreateApplicationControls();

        }
        private void CreateInfoRow(
            string title,
            int y,
            out Label valueLabel)
        {


            Label lbl =
                new Label();


            lbl.Text =
                title;



            lbl.Font =
                new Font(
                    "Segoe UI",
                    13,
                    FontStyle.Bold);



            lbl.Location =
                new Point(
                    180,
                    y);



            lbl.AutoSize =
                true;



            pnlApplicationInfo.Controls.Add(
                lbl);





            valueLabel =
                new Label();



            valueLabel.Text =
                "???";



            valueLabel.Font =
                new Font(
                    "Segoe UI",
                    13);



            valueLabel.Location =
                new Point(
                    420,
                    y);



            valueLabel.AutoSize =
                true;



            pnlApplicationInfo.Controls.Add(
                valueLabel);

        }
        private void CreateApplicationControls()
        {

            CreateInfoRow(
                "Application ID",
                80,
                out lblApplicationIDValue);



            CreateInfoRow(
                "Application Date",
                160,
                out lblApplicationDateValue);



            CreateInfoRow(
                "Application Fees",
                320,
                out lblApplicationFeesValue);



            CreateInfoRow(
                "Created By",
                400,
                out lblCreatedByValue);

            




            Label lblClass =
                new Label();



            lblClass.Text =
                "License Class";



            lblClass.Font =
                new Font(
                    "Segoe UI",
                    13,
                    FontStyle.Bold);



            lblClass.Location =
                new Point(
                    180,
                    240);



            lblClass.AutoSize =
                true;



            pnlApplicationInfo.Controls.Add(  lblClass);





            cmbLicenseClass =
                new ComboBox();



            cmbLicenseClass.Location =
                new Point(
                    420,
                    235);



            cmbLicenseClass.Width =
                220;



            cmbLicenseClass.DropDownStyle =
                ComboBoxStyle.DropDownList;



      



            pnlApplicationInfo.Controls.Add(
                cmbLicenseClass);


            LoadLicenseClasses();

        }
        private void LoadLicenseClasses()
        {
            allLicenseClasses =
                LicenseClasses.GetAll();

            cmbLicenseClass.DisplayMember =
                "ClassName";

            cmbLicenseClass.ValueMember =
                "LicenseClassID";

            cmbLicenseClass.DataSource =
                allLicenseClasses;

            cmbLicenseClass.SelectedIndexChanged += cmbLicenseClass_SelectedIndexChanged;

            string fees;
            if (Licenses.IsFirstLicense(Convert.ToInt32(cmbLicenseClass.SelectedValue), personID))
            {
                fees = ApplicationTypes.GetFees((int)enApplicationType.NewLocalLicense).ToString();
            }
            fees = ApplicationTypes.GetFees((int)enApplicationType.RenewLicense).ToString();

            lblApplicationFeesValue.Text = fees;
        }

        public  void cmbLicenseClass_SelectedIndexChanged(object sender,EventArgs e)
        {
            string fees;
            if (Licenses.IsFirstLicense(Convert.ToInt32(cmbLicenseClass.SelectedValue), personID))
            {
                type = enApplicationType.NewLocalLicense;
                fees = ApplicationTypes.GetFees((int)type).ToString();
                lblTitle.Text = "Add local driving license";
            }
            else
            {
                type = enApplicationType.RenewLicense;
                fees = ApplicationTypes.GetFees((int)type).ToString();
                lblTitle.Text = "Renew local driving license";
            }

            lblApplicationFeesValue.Text = fees;

        }
        private void LoadPeople()
        {

            DataTable people =
                People.GetAllFewDetails();



            personSelector.LoadData(people);

        }
        private void BtnNext_Click(
            object sender,
            EventArgs e)
        {
            if (!pnlLicenseDetails.Visible)
            {

                if (personSelector.SelectedId == null)
                {
                    CustomMessageBox.Show(
                        "Failed",
                        "Please select a person");

                    return;
                }



                pnlPersonSelection.Visible =
                    false;



                pnlLicenseDetails.Visible =
                    true;



                btnCancel.Text =
                    "Back";



                btnNext.Text =
                    "Save";



                lblApplicationDateValue.Text =
                    DateTime.Now.ToString(
                        "dd/MM/yyyy");



                lblCreatedByValue.Text =
                    CurrentUser.User.UserName;
                SearchGrid_RowClicked();
                return;
            }

            else if (cmbLicenseClass.SelectedValue == null)
            {
                CustomMessageBox.Show(
                        "Failed",
                        "No licenses available");

                return;
            }

             LDLID = LDLApplications.Add(Convert.ToInt32(cmbLicenseClass.SelectedValue), personID,type);
           if ( LDLID == 0)
            {
                CustomMessageBox.Show(
                        "Failed",
                        "Error in Database");

                return;
            }
            lblApplicationIDValue.Text = LDLID.ToString();
            SearchGrid_RowClicked();
            CustomMessageBox.Show(
                       "Done!",
                       "Registred successfully");







        }
        private void BtnCancel_Click(
            object sender,
            EventArgs e)
        {

            if (pnlLicenseDetails.Visible)
            {

                pnlLicenseDetails.Visible =
                    false;


                pnlPersonSelection.Visible =
                    true;


                btnCancel.Text =
                    "Cancel";


                btnNext.Text =
                    "Next";

                return;
            }


            Close();

        }

    }
}