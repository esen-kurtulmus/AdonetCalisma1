using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace demo_Adonet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
           // Data Source = LAPTOP - IQULJ22J\SQLEXPRESS; Initial Catalog = soldoutDb; Integrated Security = True
            SqlConnection connection = new SqlConnection("Data Source=LAPTOP-IQULJ22J\\SQLEXPRESS;Initial Catalog=DbistanbulAkademi;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand("select * from Tblcategory", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);  //veri çekmek için kullanılır
            DataTable datatable = new DataTable();  //sanal tablom
            adapter.Fill(datatable);
            dataGridView1.DataSource = datatable;
             connection.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=LAPTOP-IQULJ22J\\SQLEXPRESS;Initial Catalog=DbistanbulAkademi;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand("insert into TblCategory (categoryName) values (@p1)", connection);
            command.Parameters.AddWithValue("@p1", txtCategoryName.Text);
            command.ExecuteNonQuery();  //değişikliklerin kaydedilmesini sağlar.
            connection.Close();
            MessageBox.Show("Kategori eklendi");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=LAPTOP-IQULJ22J\\SQLEXPRESS;Initial Catalog=DbistanbulAkademi;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand("delete from TblCategory where CategoryID=@p1", connection);
            command.Parameters.AddWithValue("@p1", txtCategoryID.Text);
            command.ExecuteNonQuery();

            connection.Close();
            MessageBox.Show("KATEGORİ SİLİNDİ");

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=LAPTOP-IQULJ22J\\SQLEXPRESS;Initial Catalog=DbistanbulAkademi;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand("update TblCategory set CategoryName=@p1 where CategoryId=@p2", connection);
            command.Parameters.AddWithValue("@p1", txtCategoryName.Text);
            command.Parameters.AddWithValue("@p2", txtCategoryID.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kategori Güncellendi");

        }
    }
}
