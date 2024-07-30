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
    public partial class Cart_Items : Form
    {
        int UserID1;
        string connection = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ali Khattak\documents\visual studio 2013\Projects\CanteenManagmentSystem\CanteenManagmentSystem\CanteenDatabase.mdf;Integrated Security=True";
        int TotalBill;

        DateTime now = DateTime.Now;  

        SqlConnection conn;
        SqlCommand command;
        SqlDataAdapter Adapter;
        public Cart_Items(int UserID)
        {
            InitializeComponent();

            UserID1 = UserID;

            conn = new SqlConnection(connection);

            conn.Open();

            string myquery = "SELECT ItemID,CartItemName,CartItemPrice,CartItemQuantity,CartItemCategory,QuantityPrice FROM CartItems WHERE UserID=@userID";

             command = new SqlCommand(myquery, conn);

             command.Parameters.AddWithValue("userID", UserID);

             Adapter = new SqlDataAdapter(command);

            DataTable Dat = new DataTable();

            Adapter.Fill(Dat);

            dataGridView1.DataSource = Dat;

            conn.Close();

            conn.Open();

            myquery = "SELECT SUM(QuantityPrice) FROM CartItems";

            command = new SqlCommand(myquery, conn);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                TotalBill = int.Parse(reader[0].ToString());             
            }

            label3.Text = TotalBill.ToString();           
            conn.Close();

        }

        private void PlaceOrder_Click(object sender, EventArgs e)
        {
            List<int> ItemNumbersList = new List<int>();
            List<string> ItemNamelist = new List<string>();


            conn.Open();

            string myquery = "SELECT ItemID FROM CartItems";

            SqlCommand command = new SqlCommand(myquery, conn);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ItemNumbersList.Add(reader.GetInt32(0));
            }
            reader.Close();


            // FOR ITEM NAMES and converting it to List and then storing in Varable

            

            myquery = "SELECT CartItemName FROM CartItems";

             command = new SqlCommand(myquery, conn);

             reader = command.ExecuteReader();

            while (reader.Read())
            {
                ItemNamelist.Add(reader[0].ToString());
            }
            reader.Close();


            string ITEM_NUMBERS = string.Join("-", ItemNumbersList);

            string ITEM_NAMES = string.Join("-", ItemNamelist);
        
            myquery = "INSERT INTO Token(TokenItems,ItemNames,OrderDateTime,TotalBill,BillPayed,UserID) VALUES (@Itemms,@ItemsName,@Dated,@bill,@BillPayed,@UserID)";
            
            command = new SqlCommand(myquery, conn);

            
            command.Parameters.AddWithValue("@Itemms", ITEM_NUMBERS);
            command.Parameters.AddWithValue("@ItemsName", ITEM_NAMES);
            command.Parameters.AddWithValue("@Dated", now);
            command.Parameters.AddWithValue("@bill", TotalBill);
            command.Parameters.AddWithValue("@BillPayed", "No");
            command.Parameters.AddWithValue("@UserID", UserID1);

            command.ExecuteNonQuery();

            conn.Close();          

           

            OrderConfirmation order = new OrderConfirmation(UserID1);
            order.Show();
            this.Hide();


        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connection);

            conn.Open();

            string myquery = "DELETE FROM CartItems Where ItemID=@Itemid";

            SqlCommand command = new SqlCommand(myquery, conn);

            command.Parameters.AddWithValue("@Itemid",  DeleteText.Text);

            command.ExecuteNonQuery();

            MessageBox.Show("Item Deleted from Cart !", "Deleted");

            conn.Close();

            conn.Open();

             myquery = "SELECT ItemID,CartItemName,CartItemPrice,CartItemQuantity,CartItemCategory,QuantityPrice FROM CartItems WHERE UserID=@userID";

            command = new SqlCommand(myquery, conn);

            command.Parameters.AddWithValue("userID", UserID1);

            Adapter = new SqlDataAdapter(command);

            DataTable Dat = new DataTable();

            Adapter.Fill(Dat);

            dataGridView1.DataSource = Dat;

            conn.Close();

            conn.Open();

            myquery = "SELECT SUM(QuantityPrice) FROM CartItems";

            command = new SqlCommand(myquery, conn);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                TotalBill = int.Parse(reader[0].ToString());
            }

            label3.Text = TotalBill.ToString();
            conn.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            CustomerMenu menu = new CustomerMenu(UserID1);
            menu.Show();
            this.Hide();
        }
    }
}
