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

            obtain.SelectedIndex = 0;
            payment.SelectedIndex = 0;
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

            List<Person> persons = SQL.searchInfo("basket");
            List<Basket> baskets = new List<Basket>();

            foreach(var person in persons)
            {
                if (person is Basket)
                {
                    baskets.Add(new Basket(person.retValues()));
                }
            }

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
                adminPanel.Enabled = true;
                adminPanel.Visible = true;
            } else
            {
                SQL.addInfo("basket",
                new List<string>() { "_id", "numOfProd", "price" },
                new List<string>() { (int.Parse(baskets[baskets.Count - 1].id) + 1).ToString(), "0", "0" });

                SQL.addInfo("orders", 
                    new List<string>() {
                        "lastname", "firstname", "patronymic", "address", "telephone", "mail", "obtain", "payment", "id_basket"
                    },
                    new List<string>() {
                        fio.Text.Split(' ')[0] is null ||  fio.Text.Split(' ')[0] == "" ? "" : fio.Text.Split(' ')[0],
                        fio.Text.Split(' ')[1] is null ||  fio.Text.Split(' ')[1] == "" ? "" : fio.Text.Split(' ')[1],
                        fio.Text.Split(' ')[2] is null ||  fio.Text.Split(' ')[2] == "" ? "" : fio.Text.Split(' ')[2],
                        adress.Text, tel.Text, mail.Text, obtain.SelectedItem.ToString(), payment.SelectedItem.ToString(),
                        (baskets[baskets.Count-1].id + 1).ToString()
                    }
                    );

                MenuScreen menuScreen = new MenuScreen();
                this.Visible = false;
                this.Enabled = false;
                menuScreen.Visible = true;
                menuScreen.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            readyCheck();
        }

        public void readyCheck()
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

        private void fio_TextChanged(object sender, EventArgs e)
        {
            readyCheck();
        }
    }
}
