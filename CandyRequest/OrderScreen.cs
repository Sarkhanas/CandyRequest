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
using CandyRequest.Classes;
using System.IO;

namespace CandyRequest
{
    public partial class OrderScreen : Form
    {
        public List<TextBox> textBoxes = new List<TextBox>();
        public string path = Path.GetFullPath(@"..\..\Defaults\Admins.json");
        Admin admin = new Admin();

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
            textBoxes = new List<TextBox> { fio, adress, tel, mail };
            var json = File.ReadAllText(path);
            admin = Newtonsoft.Json.JsonConvert.DeserializeObject<Admin>(json);
            int count = 0;

            foreach (var box in textBoxes)
            {
                if (box.Text == admin.FIO)
                    count++;
            }

            if (count == 4)
            {
                AdminPanel adminPanel = new AdminPanel();
                this.Visible = false;
                this.Enabled = false;
                adminPanel.E
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxes = new List<TextBox> { fio, adress, tel, mail };
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
