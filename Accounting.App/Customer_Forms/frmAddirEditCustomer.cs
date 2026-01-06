using Accounting.DataLayer;
using Accounting.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValidationComponents;

namespace Accounting.App
{
    public partial class frmAddirEditCustomer : Form
    {
        public int customerID = 0;
        UnitOfWork db = new UnitOfWork();
        public frmAddirEditCustomer()
        {
            InitializeComponent();
        }

        private void AddirEditCustomer_Load(object sender, EventArgs e)
        {
            if (customerID != 0)
            {
                this.Text = "ویرایش شخص";
                btnSaveNewCustomer.Text = "ویرایش";
                var customer = db.CustomerRepository.GetCustomersbyID(customerID);
                txtMobile.Text = customer.Mobile;
                txtName.Text = customer.FullName;
                txtAddress.Text = customer.Address;
                txtEmail.Text = customer.Email;
                picCustomer.ImageLocation = Application.StartupPath + "/Images/" + customer.CustomerImage;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void selectPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            { 
                picCustomer.ImageLocation = openFile.FileName;  
            }
        }

        private void btnSaveNewCustomer_Click(object sender, EventArgs e)
        {
            string imageName = Guid.NewGuid().ToString() + Path.GetExtension(picCustomer.ImageLocation);    // نظارت میکنه اسم عکس ها تکراری نباشن
            string path = Application.StartupPath + "/Images/";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            picCustomer.Image.Save(path+imageName);
            if (BaseValidator.IsFormValid(this.components))
            {
                Customers customer = new Customers()
                {
                   FullName=txtName.Text,
                   Mobile = txtMobile.Text,
                   Email = txtEmail.Text,
                   Address = txtAddress.Text,
                   CustomerImage=imageName
                };
                if (customerID == 0)
                {
                    db.CustomerRepository.InsertCustomer(customer);
                }
                else
                {
                    customer.customerID= customerID;
                    db.CustomerRepository.UpdateCustomer(customer);
                }
                
                db.save();
                DialogResult = DialogResult.OK;
            }
        }
    }
}
