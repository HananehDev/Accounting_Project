using Accounting.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValidationComponents;

namespace Accounting.App
{
    public partial class frmNewAccounting : Form
    {
        UnitOfWork db = new UnitOfWork();
        public int accountId = 0;
        public frmNewAccounting()
        {
            InitializeComponent();
        }

        private void frmNewAccounting_Load(object sender, EventArgs e)
        {
            dgvCustomerName.AutoGenerateColumns =false;
            dgvCustomerName.DataSource = db.CustomerRepository.GetCustomerNames();
            if (accountId !=0)
            {
                var account = db.AccountingRepository.GetById(accountId);
                txtAmount.Text = account.Amount.ToString();
                txtDescription.Text = account.Description;
                txtName.Text = db.CustomerRepository.GetCustomerNameByID(account.CustomerId);
                if (account.TypeId==1)
                {
                    rbReceive.Checked= true;
                }
                else
                {
                    rbPay.Checked = true;
                }
                this.Text = "ویرایش";
                btnSave.Text = "ویرایش";
            }
        }

        private void dgvCustomerName_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            dgvCustomerName.AutoGenerateColumns = false;
            dgvCustomerName.DataSource = db.CustomerRepository.GetCustomerNames(txtFilter.Text);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvCustomerName_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtName.Text = dgvCustomerName.CurrentRow.Cells[0].Value.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (BaseValidator.IsFormValid(this.components))
            {
                if(rbPay.Checked ||  rbReceive.Checked)
                {
                    DataLayer.Accounting accounting = new DataLayer.Accounting()
                    {
                        Amount = int.Parse(txtAmount.Value.ToString()),
                        CustomerId = db.CustomerRepository.GetCustomerIdByName(txtName.Text),
                        TypeId = (rbReceive.Checked) ? 1 : 2  ,  // condition if
                        DateTime = DateTime.Now,
                        Description= txtDescription.Text,
                    };
                    if (accountId==0)
                    {
                        db.AccountingRepository.Insert(accounting);
                        db.save();
                    }
                    else
                    {
                        using (UnitOfWork db2 = new UnitOfWork())
                        {
                            accounting.ID = accountId;
                            db2.AccountingRepository.Update(accounting);
                            db2.save();
                        } 
                    }

                    DialogResult = DialogResult.OK;
                }
                else
                {
                    RtlMessageBox.Show("لطفا نوع تراکنش را مشخص کنید ");
                }
            }

        }
    }
}
