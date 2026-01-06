using Accounting.DataLayer;
using Accounting.DataLayer.Context;
using Accounting.Utilities.Convertor;
using Accounting.ViewModels.Customer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accounting.App
{

    public partial class frmReport : Form
    {
        public int typeid = 0;
        
        public frmReport()
        {
            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            
            using (UnitOfWork db = new UnitOfWork())
            {
                List<ListCustomerViewModel> list = new List<ListCustomerViewModel>();
                list.Add(new ListCustomerViewModel()
                {
                    CustomerId = 0,
                    FullName = "انتخاب کنید "
                });
                list.AddRange(db.CustomerRepository.GetCustomerNames());
                cbCustomer.DataSource = list;
                cbCustomer.DisplayMember = "FullName";
                cbCustomer.ValueMember = "CustomerId";
            }
                
            if (typeid == 1)
            {
                this.Text = "گزارش دریافتی ها";
            }
            else
            {
                this.Text = "گزارش پرداختی ها";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            Filter();
        }
        void Filter()
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                List<DataLayer.Accounting> result = new List<DataLayer.Accounting>();


                DateTime? StartDate;                // ? it could be null
                DateTime? EndDate;
                // combobox
                if ((int)cbCustomer.SelectedValue != 0)
                {
                    int customerId = int.Parse(cbCustomer.SelectedValue.ToString());
                    result.AddRange(db.AccountingRepository.Get(a => a.TypeId == typeid && a.CustomerId == customerId));
                }
                else
                {
                    result.AddRange(db.AccountingRepository.Get(a => a.TypeId == typeid));
                }
                //datefrom_to
                if (txtFromDate.Text != "    /  /")
                {
                    StartDate = Convert.ToDateTime(txtFromDate.Text);
                    StartDate = DateConvertor.ToMiladi(StartDate.Value);
                    result = result.Where(r => r.DateTime >= StartDate.Value).ToList();
                }
                if (txtUntilDate.Text != "    /  /")
                {
                    EndDate = Convert.ToDateTime(txtUntilDate.Text);
                    EndDate = DateConvertor.ToMiladi(EndDate.Value);
                    result = result.Where(r => r.DateTime <= EndDate.Value).ToList();
                }

                //dgReport.AutoGenerateColumns = false;
                //dgReport.DataSource = result;
                dgReport.Rows.Clear();
                foreach (var item in result)
                {
                    string customerName = db.CustomerRepository.GetCustomerNameByID(item.CustomerId);
                    dgReport.Rows.Add(item.ID, customerName, item.Amount, item.DateTime.ToShamsi());


                }
            }

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Filter();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgReport.CurrentRow != null)
            {
                int id = int.Parse(dgReport.CurrentRow.Cells[0].Value.ToString());
                if (RtlMessageBox.Show("آیا از حذف رکورد مطمئن هستید ؟", "هشدار", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (UnitOfWork db = new UnitOfWork())
                    {
                        db.AccountingRepository.Delete(id);
                        db.save();
                        Filter();
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgReport.CurrentRow != null)
            {
                int id = int.Parse(dgReport.CurrentRow.Cells[0].Value.ToString());
                frmNewAccounting frmNew = new frmNewAccounting();
                frmNew.accountId = id;
                if(frmNew.ShowDialog() == DialogResult.OK)
                {
                    Filter();
                }
            }
        }

        private void cbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataTable dtprint=new DataTable();
            dtprint.Columns.Add("Customer");
            dtprint.Columns.Add("Amount");
            dtprint.Columns.Add("Date");
            dtprint.Columns.Add("Description");
            foreach (DataGridViewRow item in dgReport.Rows)
            {
                dtprint.Rows.Add(
                    item.Cells[0].Value.ToString(),
                    item.Cells[1].Value.ToString(),
                    item.Cells[2].Value.ToString(),
                    item.Cells[3].Value.ToString()
                    );

            }
            stiPrint.Load(Application.StartupPath + "/Report2.mrt");
            stiPrint.RegData("DT", dtprint);
            stiPrint.Show();

        }
    }
}
