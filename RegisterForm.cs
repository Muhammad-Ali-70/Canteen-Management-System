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
    public partial class RegisterForm : Form
    {
        string connection = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ali Khattak\documents\visual studio 2013\Projects\CanteenManagmentSystem\CanteenManagmentSystem\CanteenDatabase.mdf;Integrated Security=True";

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (Nametextbox.Text != string.Empty || Passwordtext.Text != string.Empty || AgeCombo.Text != string.Empty || Phonetextbox.Text != string.Empty || Emailtext.Text != string.Empty || FavouriteDish.Text != string.Empty)
            {

                SqlConnection conn = new SqlConnection(connection);

                conn.Open();

                string myquery = "INSERT INTO UserDetails(UserName,UserAge,UserPhone,UserEmail,UserPassword,FavouriteDish) VALUES (@Name,@Age,@Phone,@Email,@Password,@Fav)";

                SqlCommand command = new SqlCommand(myquery, conn);

                command.Parameters.AddWithValue("@Name", Nametextbox.Text);
                command.Parameters.AddWithValue("@Age", AgeCombo.Text);
                command.Parameters.AddWithValue("@Phone", Phonetextbox.Text);
                command.Parameters.AddWithValue("@Email", Emailtext.Text);
                command.Parameters.AddWithValue("@Password", Passwordtext.Text);
                command.Parameters.AddWithValue("@Fav", FavouriteDish.Text);

                 command.ExecuteNonQuery();

                 conn.Close();

                 MessageBox.Show("CUSTOMER REGISTERED!");


                 CustomerLogin login = new CustomerLogin();
                 login.Show();
                 this.Hide();
  
            }
            else
            {
                MessageBox.Show("Please Fill all the Required Data First");
            }
        }
    }
}
