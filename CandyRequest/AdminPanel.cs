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
            switch (dataBaseChoose.SelectedItem.ToString())
            {
                case "orders":
                    foreach(var elem in added)
                    {
                        List<string> val = elem.retValues();
                        
                        SQL.addInfo("orders",
                            new List<string>() { "_id", "lastname", "firstname", "patronymic",
                            "address", "telephone", "mail", "obtain", "payment", "id_basket" },
                            new List<string>() 
                            {
                                val[0],
                                val[1].Split(' ')[0] is null || val[1].Split(' ')[0] == "" ? " ": val[1].Split(' ')[0], 
                                val[1].Split(' ')[1] is null || val[1].Split(' ')[1] == "" ? " ": val[1].Split(' ')[1], 
                                val[1].Split(' ')[2] is null || val[1].Split(' ')[2] == "" ? " ": val[1].Split(' ')[2], 
                                val[2], val[3], val[4], val[5], val[6], val[7] 
                            });
                    }

                    foreach (var elem in deleted)
                    {
                        List<string> val = elem.retValues();
                        SQL.deleteInfo("orders",
                            new List<string>() { "_id", "lastname", "firstname", "patronymic",
                            "address", "telephone", "mail", "obtain", "payment", "id_basket" },
                            new List<string>()
                            {
                                val[0],
                                val[1].Split(' ')[0] is null || val[1].Split(' ')[0] == "" ? " ": val[1].Split(' ')[0],
                                val[1].Split(' ')[1] is null || val[1].Split(' ')[1] == "" ? " ": val[1].Split(' ')[1],
                                val[1].Split(' ')[2] is null || val[1].Split(' ')[2] == "" ? " ": val[1].Split(' ')[2],
                                val[2], val[3], val[4], val[5], val[6], val[7]
                            });
                    }


                    break;

                case "basket":
                    break;

                case "product":
                    break;

                case "sale":
                    break;

                case "holiday":
                    break;

                case "grade":
                    break;
            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (!isFirstLoad)
            {
                int row = dataGridView1.Rows.Count - 1;
                switch (dataBaseChoose.SelectedItem.ToString())
                {
                    case "orders":
                        added.Add(new Order(new List<string>()
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
                        added.Add(new Basket(new List<string>()
                    {
                        dataGridView1[0,row].Value.ToString(),
                        dataGridView1[1,row].Value.ToString(),
                        dataGridView1[2,row].Value.ToString()
                    }));
                        break;

                    case "product":
                        added.Add(new Product(new List<string>()
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
                        added.Add(new Sale(new List<string>()
                        {
                            dataGridView1[0,row].Value.ToString(),
                            dataGridView1[1,row].Value.ToString()
                        }));
                        break;

                    case "holiday":
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


                        added.Add(new Holiday(new List<string>()
                        {
                            dataGridView1[0,row].Value.ToString(),
                            dataGridView1[1,row].Value.ToString(),
                            dataGridView1[2,row].Value.ToString(),
                            startDate,
                            endDate,
                            dataGridView1[5,row].Value.ToString()
                        }));
                        break;

                    case "grade":
                        added.Add(new Grade(new List<string>()
                        {
                            dataGridView1[0,row].Value.ToString(),
                            dataGridView1[1,row].Value.ToString()
                        }));
                        break;
                }
                isFirstLoad = false;
            }
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            switch (dataBaseChoose.SelectedItem.ToString())
            {
                case "orders":
                    secondPeople = new List<Person>();
                    for (int row = 0; row < dataGridView1.Rows.Count - 1; row++)
                        secondPeople.Add(new Order(new List<string>()
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
                    secondPeople = new List<Person>();                    for (int row = 0; row < dataGridView1.Rows.Count - 1; row++)
                        secondPeople.Add(new Basket(new List<string>()
                        {
                            dataGridView1[0,row].Value.ToString(),
                            dataGridView1[1,row].Value.ToString(),
                            dataGridView1[2,row].Value.ToString()
                        }));
                    break;

                case "product":
                    secondPeople = new List<Person>();                    for (int row = 0; row < dataGridView1.Rows.Count - 1; row++)
                        secondPeople.Add(new Product(new List<string>()
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
                    secondPeople = new List<Person>();                    for (int row = 0; row < dataGridView1.Rows.Count - 1; row++)
                        secondPeople.Add(new Sale(new List<string>()
                        {
                            dataGridView1[0,row].Value.ToString(),
                            dataGridView1[1,row].Value.ToString()
                        }));
                    break;

                case "holiday":
                    secondPeople = new List<Person>();
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


                        secondPeople.Add(new Holiday(new List<string>()
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
                    secondPeople = new List<Person>();                    
                    for (int row = 0; row < dataGridView1.Rows.Count - 1; row++)
                        secondPeople.Add(new Grade(new List<string>()
                        {
                            dataGridView1[0,row].Value.ToString(),
                            dataGridView1[1,row].Value.ToString()
                        }));
                    break;
            }

            int count = 0;

            for (int i = 0; i < firstPeople.Count; i++)
            {
                for (int j = 0; j < secondPeople.Count; j++)
                {
                    if (firstPeople[i] == secondPeople[j])
                        count++;
                    if (count == 1)
                    {
                        break;
                    }
                }

                if (count != 1)
                {
                    deleted.Add(firstPeople[i]);
                    count = 0;
                }
            }
                    
        }
    }
}
