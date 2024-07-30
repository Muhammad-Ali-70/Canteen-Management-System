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
    public partial class LoadingScreen : Form
    {
        public LoadingScreen()
        {
            InitializeComponent();
        }

        Timer t1;
        private void LoadingScreen_Shown(object sender, EventArgs e)
        {
            t1 = new Timer();
            t1.Interval = 3000;
            t1.Start();
            t1.Tick += tick_click;
        }

        private void tick_click(object sender, EventArgs e)
        {
            t1.Stop();
            this.Hide();

            Home Home = new Home();
            Home.Show();

        }



    }
}
