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
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;

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

            int numOfProd = dataGridView1.Rows.Count-1;

            SQL.updateInfo("basket", id_basket,
                new List<string>() { "_id", "numOfProd", "price"},
                new List<string>() { id_basket, numOfProd.ToString(), sum.ToString()});
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

        private void clearBtn_Click(object sender, EventArgs e)
        {
            SQL.deleteInfo("product", new List<string>() { "id_basket"},
                new List<string>() { id_basket });

            SQL.updateInfo("basket", id_basket, new List<string>() { "_id", "numOfProd", "price" },
                new List<string>() { id_basket, "0", "0" });
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            MenuScreen menuScreen = new MenuScreen();
            menuScreen.addBasketId(id_basket);
            menuScreen.Visible = true;
            menuScreen.Enabled = true;
            this.Visible = false;
            this.Enabled = false;
        }

        private void saveBillBtn_Click(object sender, EventArgs e)
        {
            PdfPTable table = new PdfPTable(dataGridView1.Columns.Count);

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    table.AddCell(new Phrase(dataGridView1.Rows[i].Cells[j].Value.ToString()));
                }
            }
            string folderPath = "..\\..\\Bills\\";

            if (File.Exists(folderPath + "Bill.pdf"))
                File.Delete(folderPath + "Bill.pdf");

            using (FileStream stream = new FileStream(folderPath + "Bill.pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(table);
                pdfDoc.Close();
                stream.Close();
            }

            MessageBox.Show("Отчёт собран");
        }
    }
}
