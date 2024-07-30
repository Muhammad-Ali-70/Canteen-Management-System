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
    public partial class OrderConfirmation : Form
    {
        string connection = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ali Khattak\documents\visual studio 2013\Projects\CanteenManagmentSystem\CanteenManagmentSystem\CanteenDatabase.mdf;Integrated Security=True";
        SqlConnection conn;
        SqlCommand command;
        SqlDataAdapter Adapter;
        int totalbill;
        int userId;
        public OrderConfirmation(int USERID)
        {
            InitializeComponent();

            userId = USERID;

            conn = new SqlConnection(connection);

            conn.Open();

            string myquery = "SELECT ItemID,CartItemName,CartItemPrice,CartItemQuantity,QuantityPrice,CartItemCategory FROM CartItems WHERE UserID=@userID";

            command = new SqlCommand(myquery, conn);

            command.Parameters.AddWithValue("userID", USERID);

            Adapter = new SqlDataAdapter(command);

            DataTable Dat = new DataTable();

            Adapter.Fill(Dat);

            dataGridView1.DataSource = Dat;

            conn.Close();

            conn.Open();

            myquery = "SELECT TokenID FROM Token WHERE UserID=@User";

            command = new SqlCommand(myquery, conn);

            command.Parameters.AddWithValue("@User", USERID);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                label10.Text = reader[0].ToString();                
            }
            reader.Close();

            conn.Close();

            conn.Open();

            myquery = "SELECT SUM(QuantityPrice) FROM CartItems";

            command = new SqlCommand(myquery, conn);

             reader = command.ExecuteReader();
            
            if (reader.Read())
            {
                totalbill = int.Parse(reader[0].ToString());
            }

            label8.Text = totalbill.ToString();
            label6.Text = USERID.ToString();
            conn.Close();

            conn.Open();

            myquery = "DELETE FROM CartItems";

            command = new SqlCommand(myquery, conn);

            command.ExecuteNonQuery();
          
            conn.Close();



        }

        private void CheckOut_Click(object sender, EventArgs e)
        {
            CustomerWelcome welcome = new CustomerWelcome(userId);
            welcome.Show();
            this.Hide();


        }
    }
}
