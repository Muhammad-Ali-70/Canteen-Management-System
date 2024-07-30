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


namespace CanteenManagmentSystem
{
    public partial class AllOrders : Form
    {
        string connection = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ali Khattak\documents\visual studio 2013\Projects\CanteenManagmentSystem\CanteenManagmentSystem\CanteenDatabase.mdf;Integrated Security=True";

        public AllOrders()
        {
            
            InitializeComponent();

            dataGridView1.RowTemplate.MinimumHeight = 40;
            


            SqlConnection conn = new SqlConnection(connection);

            conn.Open();

            string myquery = "SELECT TokenID,TokenItems,ItemNames,OrderDateTime,TotalBill,BillPayed,UserID FROM Token";

            SqlCommand command = new SqlCommand(myquery, conn);

            SqlDataAdapter Adapter = new SqlDataAdapter(command);

            DataTable Dat = new DataTable();

            Adapter.Fill(Dat);

            dataGridView1.DataSource = Dat;

            conn.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty || textBox3.Text != string.Empty)
            {
                SqlConnection conn = new SqlConnection(connection);

                conn.Open();

                string myquery = "SELECT * FROM Token WHERE TokenID=@token AND UserID=@inputID";

                SqlCommand command = new SqlCommand(myquery, conn);

                command.Parameters.AddWithValue("@token", textBox1.Text);
                command.Parameters.AddWithValue("@inputID", textBox3.Text);

                SqlDataAdapter Adapter = new SqlDataAdapter(command);

                DataTable Dat = new DataTable();

                Adapter.Fill(Dat);

                dataGridView1.DataSource = Dat;

                conn.Close();

            }
            else
            {
                MessageBox.Show("Enter Token ID and UserID First");
            }
        }

        private void BillPayed_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty || textBox3.Text != string.Empty)
            {
                SqlConnection conn = new SqlConnection(connection);

                conn.Open();

                string Payed = "Yes";

                string myquery = "UPDATE Token SET BillPayed=@Check WHERE TokenID=@token AND UserID=@inputID";

                SqlCommand command = new SqlCommand(myquery, conn);

                command.Parameters.AddWithValue("@Check", Payed);
                command.Parameters.AddWithValue("@token", textBox1.Text);
                command.Parameters.AddWithValue("@inputID", textBox3.Text);

                SqlDataAdapter Adapter = new SqlDataAdapter(command);

                DataTable Dat = new DataTable();

                Adapter.Fill(Dat);

                dataGridView1.DataSource = Dat;

                conn.Close();

            }
            else
            {
                MessageBox.Show("Enter Token ID and UserID First");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox3.Text = string.Empty;


            SqlConnection conn = new SqlConnection(connection);

            conn.Open();

            string myquery = "SELECT TokenID,TokenItems,ItemNames,OrderDateTime,TotalBill,BillPayed,UserID FROM Token";

            SqlCommand command = new SqlCommand(myquery, conn);

            SqlDataAdapter Adapter = new SqlDataAdapter(command);

            DataTable Dat = new DataTable();

            Adapter.Fill(Dat);

            dataGridView1.DataSource = Dat;

            conn.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminWelcome Welcome = new AdminWelcome("Saba");
            Welcome.Show();
            this.Hide();
        }
    }
}
