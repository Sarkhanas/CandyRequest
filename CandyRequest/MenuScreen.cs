using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CandyRequest.Classes;
using MySql.Data.MySqlClient;

namespace CandyRequest
{
    public partial class MenuScreen : Form
    {
        static string path = Path.GetFullPath(@"..\..\Images\woocommerce-placeholder-600x600.png");
        List<PictureBox> pictures;
        List<Label> names;
        List<Label> descriptions;
        List<Label> prices;
        List<Label> adders;
        List<Person> persons;
        List<Product> products;
        public int inc = 6;
        public int min = 0;
        public int pageCounter = 1;

        public MenuScreen()
        {
            InitializeComponent();

            pictures = new List<PictureBox>() { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6 };
            names = new List<Label>() { prodName1, prodName2, prodName3, prodName4, prodName5, prodName6};
            descriptions = new List<Label>() { description1, description2, description3, description4, description5, description6};
            prices = new List<Label>() { price1, price2, price3, price4, price5, price6};
            adders = new List<Label>() { basketAdd1, basketAdd2, basketAdd3, basketAdd4, basketAdd5, basketAdd6};

            persons = SQL.searchInfo("product", "1");

            foreach (var person in persons)
                if (person is Product)
                    products.Add(new Product(person.retValues()));

            foreach (var pictureBox in pictures)
                pictureBox.Image = Image.FromFile(path);

            int maxPage = persons.Count / 6 < 1 ? 1 : persons.Count;

            page.Text = $"{pageCounter}/{maxPage}";

            for (int i = min; i < (min+inc > products.Count ? products.Count : min+inc); i++)
            {
                pictures[i].Image = Image.FromFile(Path.GetFullPath(products[i].image));
                names[i].Text = products[i].name;
                descriptions[i].Text = products[i].description;
                prices[i].Text = products[i].price;

                pictures[i].Enabled = true;
                pictures[i].Visible = true;
                names[i].Enabled = true;
                names[i].Visible = true;
                descriptions[i].Enabled = true;
                descriptions[i].Visible = true;
                prices[i].Enabled = true;
                prices[i].Visible = true;
                adders[i].Enabled = true;
                adders[i].Visible = true;
            }

            if (pageCounter >= products.Count / inc)
            {
                arrowRight.Visible = false;
                arrowRight.Enabled = false;
            }
            else
            {
                arrowRight.Visible = true;
                arrowRight.Enabled = true;
                min += inc;
            }

            if (pageCounter <= 1)
            {
                arrowLeft.Visible = false;
                arrowLeft.Enabled = false;
            }
            else
            {
                arrowLeft.Visible = true;
                arrowLeft.Enabled = true;
                min += inc;
            }
        }

        private void MenuScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void arrowRight_Click(object sender, EventArgs e)
        {
            if (pageCounter >= products.Count / inc)
            {
                arrowRight.Visible = false;
                arrowRight.Enabled = false;
            } else
            {
                arrowRight.Visible = true;
                arrowRight.Enabled = true;
                min += inc;
            }

           

            for (int i = min; i < (min + inc > products.Count ? products.Count : min + inc); i++)
            {
                pictures[i].Image = Image.FromFile(Path.GetFullPath(products[i].image));
                names[i].Text = products[i].name;
                descriptions[i].Text = products[i].description;
                prices[i].Text = products[i].price;

                pictures[i].Enabled = true;
                pictures[i].Visible = true;
                names[i].Enabled = true;
                names[i].Visible = true;
                descriptions[i].Enabled = true;
                descriptions[i].Visible = true;
                prices[i].Enabled = true;
                prices[i].Visible = true;
                adders[i].Enabled = true;
                adders[i].Visible = true;
            }
        }

        private void arrowLeft_Click(object sender, EventArgs e)
        {
            if (pageCounter <= 1)
            {
                arrowLeft.Visible = false;
                arrowLeft.Enabled = false;
            }
            else
            {
                arrowLeft.Visible = true;
                arrowLeft.Enabled = true;
                min += inc;
            }



            for (int i = min; i < (min + inc > products.Count ? products.Count : min + inc); i++)
            {
                pictures[i].Image = Image.FromFile(Path.GetFullPath(products[i].image));
                names[i].Text = products[i].name;
                descriptions[i].Text = products[i].description;
                prices[i].Text = products[i].price;

                pictures[i].Enabled = true;
                pictures[i].Visible = true;
                names[i].Enabled = true;
                names[i].Visible = true;
                descriptions[i].Enabled = true;
                descriptions[i].Visible = true;
                prices[i].Enabled = true;
                prices[i].Visible = true;
                adders[i].Enabled = true;
                adders[i].Visible = true;
            }
        }
    }
}
