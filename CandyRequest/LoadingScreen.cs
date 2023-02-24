using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CandyRequest.Classes;

namespace CandyRequest
{
    public partial class LoadingScreen : Form
    {

        public int progressBarCurentPosition = 0;
        public OrderScreen orderScreen = new OrderScreen();

        public LoadingScreen()
        {
            InitializeComponent();

            orderScreen.Visible = false;
            timer1.Interval = 300;
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            progressBar1.Maximum = 100;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.PerformStep();

            progressBarCurentPosition += progressBar1.Step;

            if (progressBarCurentPosition == progressBar1.Maximum)
            {
                this.Visible = false;
                orderScreen.Enabled = true;
                orderScreen.Visible = true;
                timer1.Stop();
                this.Enabled = false;
            }
        }
    }
}
