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
    public partial class AddItem : Form
    {
        string connection = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ali Khattak\documents\visual studio 2013\Projects\CanteenManagmentSystem\CanteenManagmentSystem\CanteenDatabase.mdf;Integrated Security=True";

        public AddItem()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connection);

            conn.Open();

            string myquery = "INSERT INTO Items (ItemName,ItemPrice,ItemCategory,ItemQuantityLeft)  VALUES (@ItemName,@Price,@Category,@Quantityleft)";

             SqlCommand command = new SqlCommand(myquery, conn);
        
            command.Parameters.AddWithValue("@ItemName", textBox1.Text );
            command.Parameters.AddWithValue("@Price", textBox2.Text );
            command.Parameters.AddWithValue("@Category", comboBox1.Text);
            command.Parameters.AddWithValue("@Quantityleft", textBox4.Text );

            command.ExecuteNonQuery();

            MessageBox.Show("Item Added to Database");

            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";

        }
    }
}
