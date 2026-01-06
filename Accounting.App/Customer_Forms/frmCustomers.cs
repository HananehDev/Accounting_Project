using Accounting.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accounting.App
{
    public partial class frmCustomers : Form
    {
        public frmCustomers()
        {
            InitializeComponent();
        }

        private void frmCustomers_Load(object sender, EventArgs e)
        {
            BindGrid();
        }
        void BindGrid()
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                dgCustomers.AutoGenerateColumns = false;
                dgCustomers.DataSource = db.CustomerRepository.GetAllCustomers();
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                dgCustomers.DataSource = db.CustomerRepository.GetCustomersByFilter(txtFilter.Text).ToList();
            }
        }

        private void btnRefreshCustomer_Click(object sender, EventArgs e)
        {
            txtFilter.Text = "";
            BindGrid();
        }

        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            frmAddirEditCustomer frmAdd = new frmAddirEditCustomer();
            if (frmAdd.ShowDialog() == DialogResult.OK)
            {
                BindGrid();
            }
        }
        private void txtFilter_Click(object sender, EventArgs e)
        {

        }

        private void btnDelCustomer_Click(object sender, EventArgs e)
        {
            if (dgCustomers.CurrentRow != null)
            {
                int customerId = int.Parse(dgCustomers.CurrentRow.Cells[0].Value.ToString());
                string customerName = dgCustomers.CurrentRow.Cells[1].Value .ToString();
                if(RtlMessageBox.Show($"  مطمئن هستید ؟{customerName} آیا از حذف", "تایید حذف " , MessageBoxButtons.YesNo , MessageBoxIcon.Question)== DialogResult.Yes )
                {
                    using (UnitOfWork db = new UnitOfWork())
                    {
                        db.CustomerRepository.DeleteCustomer(customerId);
                        db.save();
                        BindGrid();
                    }
                }
            }
            else 
            {
                RtlMessageBox.Show("لطفا یک رکورد را انتخاب کنید ");
            }
        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            if(dgCustomers.CurrentRow != null)
            {
                int customerid = int.Parse(dgCustomers.CurrentRow.Cells [0].Value.ToString());
                frmAddirEditCustomer frm = new frmAddirEditCustomer();
                frm.customerID = customerid;    // customerID is public variable in frmaddoredit
                if(frm.ShowDialog() == DialogResult.OK)
                {
                    BindGrid();
                }

            }
            else
            {
                RtlMessageBox.Show("لطفا یک رکورد را انتخاب کنید ");
            }
        }
    }
}
