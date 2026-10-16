using DVLD.Presentation.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer.Models;
namespace DVLD.Forms.Types
{
    public partial class frmEditFees : BaseForm
    {

        public Action RefreshFees;

        string title;
        string des;
        int fees, id;
        
        public frmEditFees(string title, string des, int fees,int id) 
        {

            InitializeComponent();
            this.title = title;
            this.des = des;
            this.fees = fees;
            this.id = id;
            InitializeComponents();
            
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtFees.Text == "") { txtFees.State = ValidationState.Invalid; CustomMessageBox.Show("Faild", "Please, fill the feild"); return; }
            if (des == "")
            {
                if (ApplicationTypes.UpdateFees(id, Convert.ToInt32(txtFees.Text)))
                {
                    CustomMessageBox.Show("Done", "Updated Successfully");
                    RefreshFees?.Invoke();
                    Close();
                    return;
                }
            }
            else if (TestTypes.UpdateFees(id, Convert.ToInt32(txtFees.Text)))
            {
                CustomMessageBox.Show("Done", "Updated Successfully");
                RefreshFees?.Invoke();
                Close();
                return;


            }
            else CustomMessageBox.Show("Faild!", "Error in Database");
           
          RefreshFees?.Invoke();
        }

        public void InitializeComponents()
        {   
           lblName.Text = title;
            txtFees.Text = fees.ToString();
         
            if (des != "") {lblDescrbtion.Visible=true; lblDescrbtion.Text = des; }

        }

    }
}
