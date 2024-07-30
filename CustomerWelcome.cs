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
    public partial class CustomerWelcome : Form
    {
        int UserIDD;
        string connection = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ali Khattak\documents\visual studio 2013\Projects\CanteenManagmentSystem\CanteenManagmentSystem\CanteenDatabase.mdf;Integrated Security=True";

        public CustomerWelcome(int UserID)
        {
            InitializeComponent();
            UserIDD = UserID;

            SqlConnection conn = new SqlConnection(connection);

            conn.Open();

            string myquery = "SELECT UserName FROM UserDetails WHERE UserID=@User";

            SqlCommand command = new SqlCommand(myquery, conn);

            command.Parameters.AddWithValue("@User", UserID);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                 label2.Text= reader[0].ToString();
            }

            conn.Close();
            }


        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("LOGGING OUT.....","Back to Login Page");

            CustomerLogin Login = new CustomerLogin();
            Login.Show();
            this.Hide();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomerMenu Menu = new CustomerMenu(UserIDD);
            Menu.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewCustomersOrder order = new ViewCustomersOrder(UserIDD);
            order.Show();
            this.Hide();
        }
    }
}
