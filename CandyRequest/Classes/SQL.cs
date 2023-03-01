using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CandyRequest.Classes
{
    class SQL
    {
        public MySqlCommand comand;
        public const string connstr = "server=localhost;user=root;database=bdtur_firm;password=9573541@.y;";

        public MySqlConnection conn = new MySqlConnection(connstr);

        public List<Person> searchInfo(string database)
        {
            database = database.ToLower();
            List<Person> list = new List<Person>();

            conn.Open();

            string sql = "SELECT * FROM "+ database + ";";

            comand = new MySqlCommand(sql, conn);

            MySqlDataReader reader = comand.ExecuteReader();

            switch (database) {
                case "basket":
                    while (reader.Read())
                    {
                        list.Add(new Basket
                        {
                            id = reader.GetString(0),
                            numOfProd = reader.GetString(1),
                            price = reader.GetString(2)
                        });
                    }
                    reader.Close();
                    break;

                case "grade":
                    while (reader.Read())
                    {
                        list.Add(new Grade
                        {
                            id = reader.GetString(0),
                            description = reader.GetString(1)
                        });
                    }
                    reader.Close();
                    break;

                case "holiday":
                    while (reader.Read())
                    {
                        list.Add(new Holiday
                        {
                            id = reader.GetString(0),
                            name = reader.GetString(1),
                            description = reader.GetString(2),
                            startDate = reader.GetString(3),
                            endDate = reader.GetString(4),
                            id_sale = reader.GetString(5)
                        });
                    }
                    reader.Close();
                    break;

                case "order":
                    while (reader.Read())
                    {
                        list.Add(new Order
                        {
                            id = reader.GetString(0),
                            FIO = reader.GetString(1) + " " + reader.GetString(2) + " " + reader.GetString(3),
                            Adress = reader.GetString(4),
                            Telephone = reader.GetString(5),
                            Mail = reader.GetString(6),
                            Obtain = reader.GetString(7),
                            Payment = reader.GetString(8),
                            id_busket = reader.GetString(9)
                        });
                    }
                    reader.Close();
                    break;

                case "orders":
                    while (reader.Read())
                    {
                        list.Add(new Order
                        {
                            id = reader.GetString(0),
                            FIO = reader.GetString(1) + " " + reader.GetString(2) + " " + reader.GetString(3),
                            Adress = reader.GetString(4),
                            Telephone = reader.GetString(5),
                            Mail = reader.GetString(6),
                            Obtain = reader.GetString(7),
                            Payment = reader.GetString(8),
                            id_busket = reader.GetString(9)
                        });
                    }
                    reader.Close();
                    break;

                case "product":
                    while (reader.Read())
                    {
                        list.Add(new Product
                        {
                            id = reader.GetString(0),
                            id_holiday = reader.GetString(1),
                            name = reader.GetString(2),
                            id_grade = reader.GetString(3),
                            price = reader.GetString(4),
                            image = reader.GetString(5),
                            description = reader.GetString(6),
                            id_busket = reader.GetString(7)
                        });
                    }
                    reader.Close();
                    break;

                case "sale":
                    while (reader.Read())
                    {
                        list.Add(new Sale
                        {
                            id = reader.GetString(0),
                            procent = reader.GetString(1)
                        });
                    }
                    reader.Close();
                    break;
            }
            
            conn.Close();

            return list;
        }

        public void deleteInfo(string database, List<string> names, List<string> values)
        {

            database = database.ToLower();
            conn.Open();

            string sql = "delete from " + database + "where ";

            for (int i = 0; i < names.Count; i++)
            {
                if (i == names.Count-1)
                    sql += names[i] + "= \'" + values[i] + "\';";
                else
                    sql += names[i] + "= \'" + values[i] + "\' and";
            }

            comand = new MySqlCommand(sql, conn);
            int res = comand.ExecuteNonQuery();

            conn.Close();
        }

        public void addInfo(string database, List<string> names, List<string> values)
        {
            conn.Open();

            /*string sql = "insert into turists (SecondName, FirstName, Patronymic) values(" +
                "\'" + secondName + "\', " +
                "\'" + firstName + "\', " +
                "\'" + Patronimic +
                "\')";*/

            database = database.ToLower();

            string sql = "insert into "+ database +"("; 

            for (int i = 0; i < names.Count; i++)
            {
                if (i != names.Count - 1)
                    sql += names[i] + ", ";
                else
                    sql += names[i] + ") ";
            }

            sql += "values (";

            for (int i = 0; i < values.Count; i++)
            {
                if (i != values.Count - 1)
                    sql += values + ",";
                else
                    sql += values + ");";
            }

            comand = new MySqlCommand(sql, conn);
            int res = comand.ExecuteNonQuery();

            conn.Close();
        }

    }
}
