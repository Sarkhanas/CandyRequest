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
        public string id_basket = "";
        double sum = 0;
        public static string connstr = "server=localhost;user=root;database=candys;password=9573541@.y;";
        public static MySqlConnection conn = new MySqlConnection(connstr);
        MySqlDataAdapter msda;
        DataTable dt;
        public string command = "SELECT product.name, grade.description, product.price, product.description FROM product, grade WHERE product.id_grade = grade._id AND product.id_basket = \'";

        public BasketScreen()
        {
            InitializeComponent();

            List<Person> persons = SQL.searchInfo("basket");
            List<Basket> baskets = new List<Basket>();

            foreach (var person in persons)
            {
                if (person is Basket)
                {
                    baskets.Add(new Basket(person.retValues()));
                }
            }

            id_basket = (int.Parse(baskets[baskets.Count - 1].id)).ToString();

            command += id_basket + "\';";

            msda = new MySqlDataAdapter(command, conn);
            dt = new DataTable();
            msda.Fill(dt);
            dataGridView1.DataSource = dt;

            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                sum += double.Parse(dataGridView1[2, i].Value.ToString());
            }

            label1.Text = $"Итоговая сумма: {sum}";

            int numOfProd = dataGridView1.Rows.Count - 1;

            SQL.updateInfo("basket", id_basket,
                new List<string>() { "_id", "numOfProd", "price" },
                new List<string>() { id_basket, numOfProd.ToString(), sum.ToString() });

        }

        public void addBasketId(string id)
        {
            id_basket = id;
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

            dt = new DataTable();
            dataGridView1.DataSource = dt;
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
            string FONT_LOCATION = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.TTF");
            BaseFont baseFont = BaseFont.CreateFont(FONT_LOCATION, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fontParagraph = new iTextSharp.text.Font(baseFont, 17, iTextSharp.text.Font.NORMAL);

            PdfPTable table = new PdfPTable(dataGridView1.Columns.Count);

            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    table.AddCell(new Phrase(dataGridView1.Rows[i].Cells[j].Value.ToString(), fontParagraph));
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
