using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CandyRequest.Classes;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CandyRequest
{
    public partial class AdminPanel : Form
    {
        List<Order> orders = new List<Order>();
        MySqlDataAdapter msda;
        DataTable dt;
        MySqlConnection conn = SQL.conn;
        List<Person> added = new List<Person>();
        List<Person> deleted = new List<Person>();
        List<Person> firstPeople = new List<Person>();
        List<Person> secondPeople = new List<Person>();
        bool isFirstLoad = true;

        public AdminPanel()
        {
            InitializeComponent();
            dataBaseChoose.SelectedIndex = 0;

            msda = new MySqlDataAdapter(SQL.searchCommand("orders"), conn);
            dt = new DataTable();
            msda.Fill(dt);
            dataGridView1.DataSource = dt;

            for (int row = 0; row < dataGridView1.Rows.Count - 1; row++)
                firstPeople.Add(new Order(new List<string>()
                {
                    dataGridView1[0,row].Value.ToString(),
                    dataGridView1[1,row].Value.ToString() + " " + dataGridView1[2,row].Value.ToString() + " " + dataGridView1[3,row].Value.ToString(),
                    dataGridView1[4,row].Value.ToString(),
                    dataGridView1[5,row].Value.ToString(),
                    dataGridView1[6,row].Value.ToString(),
                    dataGridView1[7,row].Value.ToString(),
                    dataGridView1[8,row].Value.ToString(),
                    dataGridView1[9,row].Value.ToString()
                }));

        }

        private void dataBaseChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            isFirstLoad = true;
            switch (dataBaseChoose.SelectedItem.ToString())
            {
                case "orders":
                    added = new List<Person>();
                    firstPeople = new List<Person>();
                    msda = new MySqlDataAdapter(SQL.searchCommand("orders"), conn);
                    dt = new DataTable();
                    msda.Fill(dt);
                    dataGridView1.DataSource = dt;
                    for (int row = 0; row < dataGridView1.Rows.Count - 1; row++)
                        firstPeople.Add(new Order(new List<string>()
                        {
                            dataGridView1[0,row].Value.ToString(),
                            dataGridView1[1,row].Value.ToString() + " " + dataGridView1[2,row].Value.ToString() + " " + dataGridView1[3,row].Value.ToString(),
                            dataGridView1[4,row].Value.ToString(),
                            dataGridView1[5,row].Value.ToString(),
                            dataGridView1[6,row].Value.ToString(),
                            dataGridView1[7,row].Value.ToString(),
                            dataGridView1[8,row].Value.ToString(),
                            dataGridView1[9,row].Value.ToString()
                        }));
                    break;

                case "basket":
                    added = new List<Person>();
                    firstPeople = new List<Person>();
                    msda = new MySqlDataAdapter(SQL.searchCommand("basket"), conn);
                    dt = new DataTable();
                    msda.Fill(dt);
                    dataGridView1.DataSource = dt;
                    for (int row = 0; row < dataGridView1.Rows.Count - 1; row++)
                        firstPeople.Add(new Basket(new List<string>()
                        {
                            dataGridView1[0,row].Value.ToString(),
                            dataGridView1[1,row].Value.ToString(),
                            dataGridView1[2,row].Value.ToString()
                        }));
                    break;

                case "product":
                    added = new List<Person>();
                    firstPeople = new List<Person>();
                    msda = new MySqlDataAdapter(SQL.searchCommand("product"), conn);
                    dt = new DataTable();
                    msda.Fill(dt);
                    dataGridView1.DataSource = dt;
                    for (int row = 0; row < dataGridView1.Rows.Count - 1; row++)
                        firstPeople.Add(new Product(new List<string>()
                        {
                            dataGridView1[0,row].Value.ToString(),                            
                            dataGridView1[1,row].Value.ToString(),                            
                            dataGridView1[2,row].Value.ToString(),                            
                            dataGridView1[3,row].Value.ToString(),                            
                            dataGridView1[4,row].Value.ToString(),                            
                            dataGridView1[5,row].Value.ToString(),                            
                            dataGridView1[6,row].Value.ToString(),                            
                            dataGridView1[7,row].Value.ToString()                            
                        }));
                    break;

                case "sale":
                    added = new List<Person>();
                    firstPeople = new List<Person>();
                    msda = new MySqlDataAdapter(SQL.searchCommand("sale"), conn);
                    dt = new DataTable();
                    msda.Fill(dt);
                    dataGridView1.DataSource = dt;
                    for (int row = 0; row < dataGridView1.Rows.Count - 1; row++)
                        firstPeople.Add(new Sale(new List<string>()
                        {
                            dataGridView1[0,row].Value.ToString(),
                            dataGridView1[1,row].Value.ToString()
                        }));
                    break;

                case "holiday":
                    added = new List<Person>();
                    firstPeople = new List<Person>();
                    msda = new MySqlDataAdapter(SQL.searchCommand("holiday"), conn);
                    dt = new DataTable();
                    msda.Fill(dt);
                    dataGridView1.DataSource = dt;
                    for (int row = 0; row < dataGridView1.Rows.Count - 1; row++)
                    {
                        List<string> startDateList = dataGridView1[3, row].Value.ToString().Split('.').Reverse().ToList<string>();
                        List<string> endDateList = dataGridView1[4, row].Value.ToString().Split('.').Reverse().ToList<string>();
                        string startDate = "";
                        string endDate = "";

                        for (int i = 0; i < startDateList.Count; i++)
                            if (i != startDateList.Count - 1)
                                startDate += startDateList[i] + "-";
                            else startDate += startDateList[i];

                        for (int i = 0; i < endDateList.Count; i++)
                            if (i != endDateList.Count - 1)
                                endDate += endDateList[i] + "-";
                            else endDate += endDateList[i];


                        firstPeople.Add(new Holiday(new List<string>()
                        {
                            dataGridView1[0,row].Value.ToString(),
                            dataGridView1[1,row].Value.ToString(),
                            dataGridView1[2,row].Value.ToString(),
                            startDate,
                            endDate,
                            dataGridView1[5,row].Value.ToString()
                        }));
                    }
                    break;

                case "grade":
                    firstPeople = new List<Person>();
                    msda = new MySqlDataAdapter(SQL.searchCommand("grade"), conn);
                    dt = new DataTable();
                    msda.Fill(dt);
                    dataGridView1.DataSource = dt;
                    for (int row = 0; row < dataGridView1.Rows.Count - 1; row++)
                        firstPeople.Add(new Grade(new List<string>()
                        {
                            dataGridView1[0,row].Value.ToString(),
                            dataGridView1[1,row].Value.ToString()
                        }));
                    break;
            }

            added = new List<Person>();

            dt = new DataTable();
            msda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            int row = dataGridView1.Rows.Count - 2;
            switch (dataBaseChoose.SelectedItem.ToString())
            {
                case "orders":
                    msda = new MySqlDataAdapter(SQL.searchCommand("orders"), conn);
                    SQL.addInfo(
                        "orders",
                        new List<string>() { "_id", "lastname", "firstname", "patronymic",
                            "address", "telephone", "mail", "obtain", "payment", "id_basket" },
                        new List<string>()
                        {
                                dataGridView1[0,row].Value.ToString(),
                                dataGridView1[1,row].Value.ToString(),
                                dataGridView1[2,row].Value.ToString(),
                                dataGridView1[3,row].Value.ToString(),
                                dataGridView1[4,row].Value.ToString(),
                                dataGridView1[5,row].Value.ToString(),
                                dataGridView1[6,row].Value.ToString(),
                                dataGridView1[7,row].Value.ToString(),
                                dataGridView1[8,row].Value.ToString(),
                                dataGridView1[9,row].Value.ToString()
                        }
                        );
                    break;

                case "basket":
                    msda = new MySqlDataAdapter(SQL.searchCommand("basket"), conn);
                    SQL.addInfo(
                        "basket",
                        new List<string>() { "_id", "numOfProd", "price" },
                        new List<string>() {
                            dataGridView1[0,row].Value.ToString(),
                            dataGridView1[1,row].Value.ToString(),
                            dataGridView1[2,row].Value.ToString()
                        });

                    break;

                case "product":
                    msda = new MySqlDataAdapter(SQL.searchCommand("product"), conn);
                    SQL.addInfo(
                        "product",
                        new List<string>() { "_id", "id_holiday", "name", "id_grade", "price", "image", "description", "id_basket" },
                        new List<string>()
                        {
                            dataGridView1[0,row].Value.ToString(),
                            dataGridView1[1,row].Value.ToString(),
                            dataGridView1[2,row].Value.ToString(),
                            dataGridView1[3,row].Value.ToString(),
                            dataGridView1[4,row].Value.ToString(),
                            dataGridView1[5,row].Value.ToString(),
                            dataGridView1[6,row].Value.ToString(),
                            dataGridView1[7,row].Value.ToString()
                        });

                    break;

                case "sale":
                    msda = new MySqlDataAdapter(SQL.searchCommand("sale"), conn);
                    SQL.addInfo(
                        "sale",
                        new List<string>() {"_id", "procent"},
                        new List<string>()
                        {
                            dataGridView1[0,row].Value.ToString(),
                            dataGridView1[1,row].Value.ToString(),
                        });
                    break;

                case "holiday":
                    msda = new MySqlDataAdapter(SQL.searchCommand("holiday"), conn);
                    List<string> startDateList = dataGridView1[3, row].Value.ToString().Split('.').Reverse().ToList<string>();
                    List<string> endDateList = dataGridView1[4, row].Value.ToString().Split('.').Reverse().ToList<string>();
                    string startDate = "";
                    string endDate = "";

                    for (int i = 0; i < startDateList.Count; i++)
                        if (i != startDateList.Count - 1)
                            startDate += startDateList[i] + "-";
                        else startDate += startDateList[i];

                    for (int i = 0; i < endDateList.Count; i++)
                        if (i != endDateList.Count - 1)
                            endDate += endDateList[i] + "-";
                        else endDate += endDateList[i];

                    SQL.addInfo(
                        "holiday",
                        new List<string>() { "_id", "name", "description", "startDate", "endDate", "id_sale"},
                        new List<string>()
                        {
                            dataGridView1[0,row].Value.ToString(),
                            dataGridView1[1,row].Value.ToString(),
                            dataGridView1[2,row].Value.ToString(),
                            startDate,
                            endDate,
                            dataGridView1[5,row].Value.ToString()
                        });
                    break;

                case "grade":
                    msda = new MySqlDataAdapter(SQL.searchCommand("grade"), conn);
                    SQL.addInfo(
                        "grade",
                        new List<string>() { "_id", "description" },
                        new List<string>()
                        {
                            dataGridView1[0,row].Value.ToString(),
                            dataGridView1[1,row].Value.ToString()
                        });
                    break;
            }

            dt = new DataTable();
            msda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void changeBtn_Click(object sender, EventArgs e)
        {
            int row = dataGridView1.CurrentRow.Index;

            switch (dataBaseChoose.SelectedItem.ToString())
            {
                case "orders":
                    msda = new MySqlDataAdapter(SQL.searchCommand("orders"), conn);
                    SQL.updateInfo(
                        "orders", dataGridView1[0, row].Value.ToString(),
                        new List<string>() { "_id", "lastname", "firstname", "patronymic",
                            "address", "telephone", "mail", "obtain", "payment", "id_basket" },
                        new List<string>()
                        {
                                dataGridView1[0,row].Value.ToString(),
                                dataGridView1[1,row].Value.ToString(),
                                dataGridView1[2,row].Value.ToString(),
                                dataGridView1[3,row].Value.ToString(),
                                dataGridView1[4,row].Value.ToString(),
                                dataGridView1[5,row].Value.ToString(),
                                dataGridView1[6,row].Value.ToString(),
                                dataGridView1[7,row].Value.ToString(),
                                dataGridView1[8,row].Value.ToString(),
                                dataGridView1[9,row].Value.ToString(),
                        }
                        );
                    break;

                case "basket":
                    msda = new MySqlDataAdapter(SQL.searchCommand("basket"), conn);
                    SQL.updateInfo(
                        "basket", dataGridView1[0, row].Value.ToString(),
                        new List<string>() { "_id", "numOfProd", "price" },
                        new List<string>() {
                            dataGridView1[0,row].Value.ToString(),
                            dataGridView1[1,row].Value.ToString(),
                            dataGridView1[2,row].Value.ToString()
                        });
                    break;

                case "product":
                    msda = new MySqlDataAdapter(SQL.searchCommand("product"), conn);
                    SQL.updateInfo(
                        "product", dataGridView1[0, row].Value.ToString(),
                        new List<string>() { "_id", "id_holiday", "name", "id_grade", "price", "image", "description", "id_basket" },
                        new List<string>()
                        {
                            dataGridView1[0,row].Value.ToString(),
                            dataGridView1[1,row].Value.ToString(),
                            dataGridView1[2,row].Value.ToString(),
                            dataGridView1[3,row].Value.ToString(),
                            dataGridView1[4,row].Value.ToString(),
                            dataGridView1[5,row].Value.ToString(),
                            dataGridView1[6,row].Value.ToString(),
                            dataGridView1[7,row].Value.ToString()
                        });
                    break;

                case "sale":
                    msda = new MySqlDataAdapter(SQL.searchCommand("sale"), conn);
                    SQL.updateInfo(
                        "sale", dataGridView1[0, row].Value.ToString(),
                        new List<string>() { "_id", "procent" },
                        new List<string>()
                        {
                            dataGridView1[0,row].Value.ToString(),
                            dataGridView1[1,row].Value.ToString()
                        });
                    break;

                case "holiday":
                    msda = new MySqlDataAdapter(SQL.searchCommand("holiday"), conn);
                    List<string> startDateList = dataGridView1[3, row].Value.ToString().Split('.').Reverse().ToList<string>();
                    List<string> endDateList = dataGridView1[4, row].Value.ToString().Split('.').Reverse().ToList<string>();
                    string startDate = "";
                    string endDate = "";

                    for (int i = 0; i < startDateList.Count; i++)
                        if (i != startDateList.Count - 1)
                            startDate += startDateList[i] + "-";
                        else startDate += startDateList[i];

                    for (int i = 0; i < endDateList.Count; i++)
                        if (i != endDateList.Count - 1)
                            endDate += endDateList[i] + "-";
                        else endDate += endDateList[i];

                    SQL.updateInfo(
                        "holiday", dataGridView1[0, row].Value.ToString(),
                        new List<string>() { "_id", "name", "description", "startDate", "endDate", "id_sale" },
                        new List<string>()
                        {
                            dataGridView1[0,row].Value.ToString(),
                            dataGridView1[1,row].Value.ToString(),
                            dataGridView1[2,row].Value.ToString(),
                            startDate,
                            endDate,
                            dataGridView1[5,row].Value.ToString()
                        });
                    break;

                case "grade":
                    msda = new MySqlDataAdapter(SQL.searchCommand("grade"), conn);
                    SQL.updateInfo(
                        "grade", dataGridView1[0, row].Value.ToString(),
                        new List<string>() { "_id", "description" },
                        new List<string>()
                        {
                            dataGridView1[0,row].Value.ToString(),
                            dataGridView1[1,row].Value.ToString()
                        });
                    break;
            }

            dt = new DataTable();
            msda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            int row = dataGridView1.CurrentRow.Index;

            switch (dataBaseChoose.SelectedItem.ToString())
            {
                case "orders":
                    msda = new MySqlDataAdapter(SQL.searchCommand("orders"), conn);
                    SQL.deleteInfo(
                        "orders", 
                        new List<string>() { "_id" },
                        new List<string>()
                        {
                                dataGridView1[0,row].Value.ToString()
                        }
                        );
                    break;

                case "basket":
                    msda = new MySqlDataAdapter(SQL.searchCommand("basket"), conn);
                    SQL.deleteInfo(
                        "basket",
                        new List<string>() { "_id"},
                        new List<string>() {
                            dataGridView1[0,row].Value.ToString()
                        });
                    break;

                case "product":
                    msda = new MySqlDataAdapter(SQL.searchCommand("product"), conn);
                    SQL.deleteInfo(
                        "product",
                        new List<string>() { "_id"},
                        new List<string>()
                        {
                            dataGridView1[0,row].Value.ToString()
                        });
                    break;

                case "sale":
                    msda = new MySqlDataAdapter(SQL.searchCommand("sale"), conn);
                    SQL.deleteInfo(
                        "sale",
                        new List<string>() { "_id", "procent" },
                        new List<string>()
                        {
                            dataGridView1[0,row].Value.ToString(),
                            dataGridView1[1,row].Value.ToString()
                        });
                    break;

                case "holiday":
                    msda = new MySqlDataAdapter(SQL.searchCommand("holiday"), conn);

                    SQL.deleteInfo(
                        "holiday",
                        new List<string>() { "_id"},
                        new List<string>()
                        {
                            dataGridView1[0,row].Value.ToString()
                        });
                    break;

                case "grade":
                    msda = new MySqlDataAdapter(SQL.searchCommand("grade"), conn);
                    SQL.deleteInfo(
                        "grade",
                        new List<string>() { "_id"},
                        new List<string>()
                        {
                            dataGridView1[0,row].Value.ToString()
                        });
                    break;
            }

            dt = new DataTable();
            msda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void AdminPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            OrderScreen orderScreen = new OrderScreen();
            orderScreen.Enabled = true;
            orderScreen.Visible = true;
            this.Enabled = false;
            this.Visible = false;
        }
    }
}
