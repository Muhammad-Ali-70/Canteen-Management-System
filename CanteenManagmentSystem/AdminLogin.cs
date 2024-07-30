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
    public partial class AdminLogin : Form
    {
        string connection = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ali Khattak\documents\visual studio 2013\Projects\CanteenManagmentSystem\CanteenManagmentSystem\CanteenDatabase.mdf;Integrated Security=True";
        string adminName;
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty || textBox2.Text != string.Empty)
            {
                SqlConnection conn = new SqlConnection(connection);

                conn.Open();

                string myquery = "SELECT * FROM AdminDetails WHERE AdminEmail=@Email AND AdminPassword=@Password";

                SqlCommand command = new SqlCommand(myquery, conn);

                command.Parameters.AddWithValue("@Email", textBox1.Text);
                command.Parameters.AddWithValue("@Password", textBox2.Text);

                SqlDataAdapter Adapter = new SqlDataAdapter(command);

                DataTable Dat = new DataTable();

                Adapter.Fill(Dat);

                if (Dat.Rows.Count == 1)
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        adminName = reader[1].ToString();
                    }

                    conn.Close();

                    AdminWelcome admin = new AdminWelcome(adminName);
                    admin.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Invalid Details", "ERROR");

                }


            }
            else
            {
                MessageBox.Show("PLEASE ENTER EMAIL AND PASSWORD FIRST", "ERROR");
            }
        }

        
    }
}
