using Npgsql;
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
    public partial class FrmCustomer : Form
    {
        public FrmCustomer()
        {
            InitializeComponent();
        }
        string connectionString = "Server=localhost; port=5432; Database=CustomerDb; user Id= postgres; Password=13587410";

        void GetAllCustomers()
        {
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "Select * from Customers";
            var command = new NpgsqlCommand(query, connection);
            var adapter = new NpgsqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            GetAllCustomers();
        }

        private void btnCustomerCreate_Click(object sender, EventArgs e)
        {
            string customerName= txtCustomerName.Text;
            string customerSurname = txtCustomerSurname.Text;
            string customerCity = txtCustomerCity.Text;
            var connnection = new NpgsqlConnection(connectionString);
            connnection.Open();
            string query = "insert into Customers (CustomerName,CustomerSurname,CustomerCity) values (@customerName, @customerSurname, @customerCity) ";
            var command = new NpgsqlCommand(@query, connnection);
            command.Parameters.AddWithValue("@customerName", customerName);
            command.Parameters.AddWithValue("@customerSurname", customerSurname);
            command.Parameters.AddWithValue("@customerCity", customerCity);
            command.ExecuteNonQuery();
            MessageBox.Show("Ekleme işlemi başarılı","Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Information);
            connnection.Close();    
            GetAllCustomers();
        }

        private void btnCustomerDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCustomerId.Text);
            var connnection = new NpgsqlConnection( connectionString);
            connnection.Open();
            string query = "Delete from customers where CustomerId=@customerId";
            var command = new NpgsqlCommand(query, connnection);
            command.Parameters.AddWithValue("@customerId",id);
            command.ExecuteNonQuery();
            MessageBox.Show("Ekleme işlemi başarılı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            connnection.Close();
            GetAllCustomers();


        }

        private void btnCustomerUpdate_Click(object sender, EventArgs e)
        {
            string customerName = txtCustomerName.Text;
            string customerSurname = txtCustomerSurname.Text;
            string customerCity = txtCustomerCity.Text;
            int id = int.Parse(txtCustomerId.Text);
            var connnection = new NpgsqlConnection(connectionString);
            connnection.Open();
            string query = "Update Customers Set CustomerName=@customerName, CustomerSurname=@customerSurname, CustomerCity=@customerCity where CustomerId=@customerId";
            var command = new NpgsqlCommand(@query, connnection);
            command.Parameters.AddWithValue("@customerName", customerName);
            command.Parameters.AddWithValue("@customerSurname", customerSurname);
            command.Parameters.AddWithValue("@customerCity", customerCity);
            command.Parameters.AddWithValue("@customerId", id);
            command.ExecuteNonQuery();
            MessageBox.Show("Güncelle işlemi başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            connnection.Close();
            GetAllCustomers();
        }
    }
}
