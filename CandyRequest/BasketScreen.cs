using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using CandyRequest.Classes;

namespace CandyRequest
{
    public partial class BasketScreen : Form
    {
        public int i = 0;
        public string id_basket;

        public BasketScreen()
        {
            InitializeComponent();

            double sum = 0;

            MySqlDataAdapter msda = new MySqlDataAdapter($"SELECT orders.lastname, orders.firstname, orders.patronymic, orders.address, product.name , product.price from orders, product "+
            $"WHERE orders.id_basket like \'{id_basket}\' and product.id_basket like \'{id_basket}\'; " ,SQL.conn);

            DataTable dt = new DataTable();
            msda.Fill(dt);

            dataGridView1.DataSource = dt;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                sum += double.Parse(dataGridView1[5, i].Value.ToString());
            }

            label1.Text = $"Итоговая сумма: {sum}";
        }

        private void BasketScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ожидайте, администратор рассматривает ваш заказ!");
            Thread.Sleep(5000);
            MessageBox.Show("Ваш заказ был одобрен");
        }
    }
}
