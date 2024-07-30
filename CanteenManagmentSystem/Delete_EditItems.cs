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
    public partial class Delete_EditItems : Form
    {
        string connection = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ali Khattak\documents\visual studio 2013\Projects\CanteenManagmentSystem\CanteenManagmentSystem\CanteenDatabase.mdf;Integrated Security=True";

        public Delete_EditItems()
        {
            InitializeComponent();

            SqlConnection conn = new SqlConnection(connection);

            conn.Open();

            string myquery = "SELECT ItemID,ItemName,ItemPrice,ItemCategory,ItemQuantityLeft FROM Items";

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

            string myquery = "DELETE FROM Items Where ItemID=@Itemid";

            SqlCommand command = new SqlCommand(myquery, conn);

            command.Parameters.AddWithValue("@Itemid", deletiontext.Text);

            command.ExecuteNonQuery();

            MessageBox.Show("Item Deleted from Database !", "Deleted");

             myquery = "SELECT ItemID,ItemName,ItemPrice,ItemCategory,ItemQuantityLeft FROM Items";

             command = new SqlCommand(myquery, conn);

            SqlDataAdapter Adapter = new SqlDataAdapter(command);

            DataTable Dat = new DataTable();

            Adapter.Fill(Dat);

            dataGridView1.DataSource = Dat;

            conn.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connection);

            conn.Open();

            string myquery = "UPDATE Items SET ItemName=@ItemName,ItemPrice=@itemprice,ItemCategory=@Category,ItemQuantityLeft=@left WHERE ItemID=@inputID";

            SqlCommand command = new SqlCommand(myquery, conn);


            command.Parameters.AddWithValue("@ItemName", textBox1.Text);
            command.Parameters.AddWithValue("@itemprice", textBox2.Text);
            command.Parameters.AddWithValue("@Category", comboBox1.Text);
            command.Parameters.AddWithValue("@left", textBox4.Text);
            command.Parameters.AddWithValue("@inputID", textBox5.Text);

            command.ExecuteNonQuery();

            MessageBox.Show("Item Updated in Database !", "Updated");

            myquery = "SELECT ItemID,ItemName,ItemPrice,ItemCategory,ItemQuantityLeft FROM Items";

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
