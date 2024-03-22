using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HedgedeskApplication
{
    public partial class frmKillSwitch : Form
    {
        DataTable dtUsers = new DataTable();
        Maintenance clsMaintenance = new Maintenance();
        int mColumnIndex;
        int mRowIndex;
        Boolean isNotValidated = false;
        Boolean isRowChanged = false;
        public frmKillSwitch()
        {
            InitializeComponent();
        }
         
        private void btnClose_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void frmKillSwitch_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void LoadForm()
        {
            int inActive = 0;
            clsMaintenance.GetUsers(dtUsers);
            dgvKillSwitch.AutoGenerateColumns = false;
            this.dgvKillSwitch.DataSource = dtUsers;
     



        }

 
        private void dgvKillSwitch_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (isNotValidated)
                e.Cancel = true;
        }

  

        private void dgvKillSwitch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int UserID = 0;
            int allowTrading = 0;
            string ReturnMessage = "";
            if (dgvKillSwitch.Columns[e.ColumnIndex].Name == "Activate")
            {
                dgvKillSwitch.EndEdit();
                Maintenance maint = new Maintenance();
                UserID = Convert.ToInt32(dgvKillSwitch.Rows[e.RowIndex].Cells["UserID"].Value.ToString());
                if (dgvKillSwitch.Rows[e.RowIndex].Cells["Activate"].Value.ToString() == "1")
                {
                    allowTrading = 1;
                }
                else
                {
                    allowTrading = 0;
                }
                if (maint.InactivateUser(allowTrading, UserID, ref ReturnMessage))
                {
                    dtUsers.Clear();
                    clsMaintenance.GetUsers(dtUsers);
                    dgvKillSwitch.AutoGenerateColumns = false;
                    this.dgvKillSwitch.DataSource = dtUsers;
                }

            }
            
        }

        private void dgvKillSwitch_CellLeave(object sender, DataGridViewCellEventArgs e)
        {


            if (e.ColumnIndex == dgvKillSwitch.Columns["Activate"].Index)
            {
                isRowChanged = false;
                isNotValidated = false;
                return;

            }
           
        }

  
 
        private void dgvKillSwitch_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (isNotValidated)
                e.Cancel = true;
        }

        private void dgvKillSwitch_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (isRowChanged == false)
            {
                mColumnIndex = dgvKillSwitch.CurrentCell.ColumnIndex;
                mRowIndex = dgvKillSwitch.CurrentCell.RowIndex;
            }
            isRowChanged = true;
        }

        private void dgvKillSwitch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {

                dgvKillSwitch.EndEdit();
                isRowChanged = false;
            }
        }

        
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (tabControl1.SelectedTab == tpCommodity)
            //{
            //    MessageBox.Show("Currently in testing", "Hedgedesk");
            //    tabControl1.SelectedTab = tabPage2;

            //}
        }


    }
            
}



