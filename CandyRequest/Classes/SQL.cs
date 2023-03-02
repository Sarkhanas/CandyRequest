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
        public static MySqlCommand comand;
        public static string connstr = "server=localhost;user=root;database=candys;password=9573541@.y;";

        public static MySqlConnection conn = new MySqlConnection(connstr);

        public static List<Person> searchInfo(string database)
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
                        list.Add(new Basket(new List<string>() 
                        {
                            reader.GetString(0),
                            reader.GetString(1),
                            reader.GetString(2)
                        }));
                    }
                    reader.Close();
                    break;

                case "grade":
                    while (reader.Read())
                    {
                        list.Add(new Grade(new List<string>() 
                        {
                            reader.GetString(0),
                            reader.GetString(1)
                        }));
                    }
                    reader.Close();
                    break;

                case "holiday":
                    while (reader.Read())
                    {
                        list.Add(new Holiday(new List<string>() 
                        {
                            reader.GetString(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetString(4),
                            reader.GetString(5)
                        }));
                    }
                    reader.Close();
                    break;

                case "order":
                    while (reader.Read())
                    {
                        list.Add(new Order(new List<string>() 
                        {
                            reader.GetString(0),
                            reader.GetString(1) + " " + reader.GetString(2) + " " + reader.GetString(3),
                            reader.GetString(4),
                            reader.GetString(5),
                            reader.GetString(6),
                            reader.GetString(7),
                            reader.GetString(8),
                            reader.GetString(9)

                        }));
                    }
                    reader.Close();
                    break;

                case "orders":
                    while (reader.Read())
                    {
                        list.Add(new Order(new List<string>()
                        {
                            reader.GetString(0),
                            reader.GetString(1) + " " + reader.GetString(2) + " " + reader.GetString(3),
                            reader.GetString(4),
                            reader.GetString(5),
                            reader.GetString(6),
                            reader.GetString(7),
                            reader.GetString(8),
                            reader.GetString(9)

                        }));
                    }
                    reader.Close();
                    break;

                case "product":
                    while (reader.Read())
                    {
                        list.Add(new Product(new List<string>() 
                        {
                            reader.GetString(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetString(4),
                            reader.GetString(5),
                            reader.GetString(6),
                            reader.GetString(7)
                        }));
                    }
                    reader.Close();
                    break;

                case "sale":
                    while (reader.Read())
 
                    {
                        list.Add(new Sale(new List<string>() 
                        {
                            reader.GetString(0),
                            reader.GetString(1)                        
                        }));
                    }
                    reader.Close();
                    break;
            }
            
            conn.Close();

            return list;
        }

        public static string searchCommand(string database)
        {
            database = database.ToLower();
            List<Person> list = new List<Person>();

            string sql = "SELECT * FROM " + database + ";";

            return sql;
        }

        public static void deleteInfo(string database, List<string> names, List<string> values)
        {

            database = database.ToLower();
            conn.Open();

            string sql = "DELETE FROM " + database + " WHERE ";

            for (int i = 0; i < names.Count; i++)
            {
                if (i == names.Count-1)
                    sql += database + "." + names[i] + " = \'" + values[i] + "\'";
                else
                    sql += database + "." + names[i] + " = \'" + values[i] + "\' AND ";
            }

            comand = new MySqlCommand(sql, conn);
            int res = comand.ExecuteNonQuery();

            conn.Close();
        }

        public static void addInfo(string database, List<string> names, List<string> values)
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
                    sql += "\'" + values[i] + "\',";
                else
                    sql += "\'" + values[i] + "\');";
            }

            comand = new MySqlCommand(sql, conn);
            int res = comand.ExecuteNonQuery();

            conn.Close();
        }

        public static void updateInfo(string database, string id ,List<string> names, List<string> values)
        {
            conn.Open();

            /*string sql = "insert into turists (SecondName, FirstName, Patronymic) values(" +
                "\'" + secondName + "\', " +
                "\'" + firstName + "\', " +
                "\'" + Patronimic +
                "\')";*/

            database = database.ToLower();

            string sql = "update " + database + " set ";

            for (int i = 0; i < names.Count; i++)
                if (i != names.Count - 1)
                    sql += names[i] + " = \'" + values[i] + "\',";
                else sql += names[i] + " = \'" + values[i] + "\' where ";

            sql += "_id = \'" + id +"\';";

            comand = new MySqlCommand(sql, conn);
            int res = comand.ExecuteNonQuery();

            conn.Close();
        }

    }
}
