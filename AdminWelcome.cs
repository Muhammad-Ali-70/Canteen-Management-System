using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanteenManagmentSystem
{
    public partial class AdminWelcome : Form
    {
        public AdminWelcome(string name)
        {
            InitializeComponent();

            label2.Text = name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddItem Add = new AddItem();
            Add.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewAllCustomers view = new ViewAllCustomers();
            view.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AllOrders all = new AllOrders();
            all.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Delete_EditItems Delete_Edit = new Delete_EditItems();
            Delete_Edit.Show();
            this.Hide();

        
        }
    }
}
