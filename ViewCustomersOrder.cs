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
    public partial class ViewCustomersOrder : Form
    {
        string connection = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ali Khattak\documents\visual studio 2013\Projects\CanteenManagmentSystem\CanteenManagmentSystem\CanteenDatabase.mdf;Integrated Security=True";
        int user;
        public ViewCustomersOrder(int UserID)
        {
            InitializeComponent();

            user = UserID;

            dataGridView1.RowTemplate.MinimumHeight = 40;

            SqlConnection conn = new SqlConnection(connection);

            conn.Open();

            string myquery = "SELECT TokenID,TokenItems,ItemNames,OrderDateTime,TotalBill,BillPayed,UserID FROM Token Where UserID=@UserID1 AND BillPayed=@BillPayed";

            SqlCommand command = new SqlCommand(myquery, conn);

            command.Parameters.AddWithValue("@UserID1", UserID);
            command.Parameters.AddWithValue("@BillPayed","No");            

            SqlDataAdapter Adapter = new SqlDataAdapter(command);

            DataTable Dat = new DataTable();

            Adapter.Fill(Dat);

            dataGridView1.DataSource = Dat;

            conn.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CustomerWelcome welcome = new CustomerWelcome(user);
            welcome.Show();
            this.Hide();
        }
    }
}
