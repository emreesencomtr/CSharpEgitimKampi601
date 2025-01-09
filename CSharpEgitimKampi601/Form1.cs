using CSharpEgitimKampi601.Entities;
using CSharpEgitimKampi601.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi601
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        CustomerOperations customerOperations = new CustomerOperations();
        private void btnCustomerCreate_Click(object sender, EventArgs e)
        {
            var customer = new Customer()
            {
                CustomerName = txtCustomerName.Text,
                CustomerSurname = txtCustomerSurname.Text,
                CustomerBalance= decimal.Parse(txtCustomerBalance.Text),
                CustomerCity= txtCustomerCity.Text,
                CustomerShopingCount= int.Parse(txtCustomerShoppingCount.Text)
            };
            customerOperations.AddCustomer(customer);
            MessageBox.Show("Müşteri Ekleme İşlemi Başarılı","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Customer> customerList = customerOperations.GetAllCustomer();
            dataGridView1.DataSource = customerList;
        }

        private void btnCustomerDelete_Click(object sender, EventArgs e)
        {
            string customerId = txtCustomerId.Text;
            customerOperations.DeleteCustomer(customerId);
            MessageBox.Show("Müşteri Başarıyla Silindi", "Uyarı",MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnCustomerUpdate_Click(object sender, EventArgs e)
        {
            string id = txtCustomerId.Text;
            var updateCustomer = new Customer()
            {
                CustomerName = txtCustomerName.Text,
                CustomerSurname = txtCustomerSurname.Text,
                CustomerCity = txtCustomerCity.Text,
                CustomerBalance = decimal.Parse(txtCustomerBalance.Text),
                CustomerShopingCount = int.Parse(txtCustomerShoppingCount.Text),
                CustomerId = id
            };
            customerOperations.UpdateCustomer(updateCustomer);
            MessageBox.Show("Müşteri Başarıyla Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGetByCustomerId_Click(object sender, EventArgs e)
        {
            string id = txtCustomerId.Text;
            Customer customers= customerOperations.GetCustomerById(id);
            dataGridView1.DataSource = new List<Customer> { customers};
        }
    }
}
