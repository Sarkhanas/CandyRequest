using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CandyRequest
{
    public partial class OrderScreen : Form
    {

        public OrderScreen()
        {
            InitializeComponent();
        }

        private void OrderScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<TextBox> textBoxes = new List<TextBox>() { fio, adress, tel, mail };

            int count = 0;

            foreach (TextBox textbox in textBoxes)
                if (!(textbox.Text is null) && textbox.Text != "")
                {
                    count++;
                }

            button1.Enabled = count == 4 ? true : false;
        }
    }
}
