using Accounting.Buesiness;
using Accounting.Utilities.Convertor;
using Accounting.ViewModels.Accounting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accounting.App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin frmLogin = new frmLogin();
            if (frmLogin.ShowDialog()==DialogResult.OK)
            {
                this.Show();
                lblDate.Text = DateTime.Now.ToShamsi();
                //lblTime.Text = DateTime.Now.ToString("HH:mm");
                Timer timer = new Timer();
                timer.Interval = 1000;
                timer.Tick += Timer_Tick;
                timer.Start();
                // for buiseness form
                report();
            }
            else
            {
                Application.Exit();
            }
        }
        void report()
        {
            ReportViewModel report = Account.ReportForm();
            lblPay.Text = report.Pay.ToString("#,0");
            lblReceive.Text = report.Receive.ToString("#,0");
            lblBalance.Text = report.AccountBalance.ToString("#,0");

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");     // u can use timer in toolbox and adding on your form
        }

        private void process1_Exited(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btncustomers_Click(object sender, EventArgs e)
        {
            frmCustomers frmCustomers = new frmCustomers();
            frmCustomers.ShowDialog();
        }

        private void btnNewAccount_Click(object sender, EventArgs e)
        {
            frmNewAccounting frm = new frmNewAccounting();
            frm.ShowDialog();
        }

        private void btnReportPay_Click(object sender, EventArgs e)
        {
            frmReport frmreport = new frmReport();
            frmreport.typeid = 2;
            frmreport.ShowDialog();
        }

        private void btnReportReceive_Click(object sender, EventArgs e)
        {
            frmReport frmreport = new frmReport();
            frmreport.typeid = 1;
            frmreport.ShowDialog();
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void btnEditLogin_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.IsEdit = true;
            frmLogin.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            report();
        }
    }
}
