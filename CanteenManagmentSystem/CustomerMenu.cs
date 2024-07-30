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

    public partial class CustomerMenu : Form
    {
        string connection = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ali Khattak\documents\visual studio 2013\Projects\CanteenManagmentSystem\CanteenManagmentSystem\CanteenDatabase.mdf;Integrated Security=True";

        int User_ID;

        int ItemID;
        int ItemPrice;
        string ItemName;
        string ItemCategory;


        public CustomerMenu(int UserID)
        {
            InitializeComponent();

            User_ID = UserID;

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

        private void AddtoCart_Click(object sender, EventArgs e)
        {
                        
            SqlConnection conn = new SqlConnection(connection);

            conn.Open();

            string myquery = "SELECT ItemID,ItemName,ItemPrice,ItemCategory FROM Items WHERE ItemID=@ItemIDtextbox";

            SqlCommand command = new SqlCommand(myquery, conn);

            command.Parameters.AddWithValue("@ItemIDtextbox", ItemIDtext.Text);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                ItemID = int.Parse(reader[0].ToString());
                ItemName = reader[1].ToString();
                ItemPrice = int.Parse(reader[2].ToString());
                ItemCategory = reader[3].ToString();
            }
            conn.Close();

            conn.Open();

            myquery = "INSERT INTO CartItems(ItemID,CartItemName,CartItemPrice,CartItemQuantity,CartItemCategory,QuantityPrice,UserID) VALUES (@ItemID1,@Name,@Price,@Quantity,@Category,@QuantityPrice,@UserID)";

            command = new SqlCommand(myquery, conn);

            int Quantity = int.Parse(QuantityCombo.Text);

            command.Parameters.AddWithValue("@ItemID1",ItemID );
            command.Parameters.AddWithValue("@Name", ItemName );
            command.Parameters.AddWithValue("@Price", ItemPrice);
            command.Parameters.AddWithValue("@Quantity", Quantity );
            command.Parameters.AddWithValue("@Category", ItemCategory);
            command.Parameters.AddWithValue("@QuantityPrice", ItemPrice * Quantity);
            command.Parameters.AddWithValue("@UserID", User_ID);

            command.ExecuteNonQuery();

            MessageBox.Show("Item Added to Cart");


        }

        private void CheckOut_Click(object sender, EventArgs e)
        {
            Cart_Items Cart = new Cart_Items(User_ID);
            Cart.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CustomerWelcome welcome = new CustomerWelcome(User_ID);
            welcome.Show();
            this.Hide();
        }

             }
        }

