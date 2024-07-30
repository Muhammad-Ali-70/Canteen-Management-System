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
    public partial class ViewAllCustomers : Form
    {
        string connection = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ali Khattak\documents\visual studio 2013\Projects\CanteenManagmentSystem\CanteenManagmentSystem\CanteenDatabase.mdf;Integrated Security=True";

        public ViewAllCustomers()
        {
            InitializeComponent();

            SqlConnection conn = new SqlConnection(connection);

            conn.Open();

            string myquery = "SELECT UserID,Username,UserAge,UserPhone,UserEmail,FavouriteDish FROM UserDetails";

            SqlCommand command = new SqlCommand(myquery, conn);

            SqlDataAdapter Adapter = new SqlDataAdapter(command);

            DataTable Dat = new DataTable();

            Adapter.Fill(Dat);

            dataGridView1.DataSource = Dat;

            conn.Close();

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connection);

            conn.Open();

            string myquery = "DELETE FROM UserDetails WHERE UserID=@userid";

            SqlCommand command = new SqlCommand(myquery, conn);

            command.Parameters.AddWithValue("@userid", textBox3.Text);

            command.ExecuteNonQuery();

            MessageBox.Show("user Deleted");

            myquery = "SELECT UserID,Username,UserAge,UserPhone,UserEmail,FavouriteDish FROM UserDetails";

             command = new SqlCommand(myquery, conn);

            SqlDataAdapter Adapter = new SqlDataAdapter(command);

            DataTable Dat = new DataTable();

            Adapter.Fill(Dat);

            dataGridView1.DataSource = Dat;

            conn.Close();


        }

        private void CheckOut_Click(object sender, EventArgs e)
        {
            AdminWelcome Welcome = new AdminWelcome("Saba");
            Welcome.Show();
            this.Hide();
        }
    }
}
