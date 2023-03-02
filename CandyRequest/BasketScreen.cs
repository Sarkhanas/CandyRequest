using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CandyRequest
{
    public partial class BasketScreen : Form
    {
        public int i = 0;

        public BasketScreen()
        {
            InitializeComponent();
        }

        private void BasketScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ожидайте, администратор проверяет ваш заказ!");
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            if (i == timer1.Interval)
            {
                timer1.Enabled = false;
                MessageBox.Show("Ваш заказ одобрен");
            }
                
        }
    }
}
