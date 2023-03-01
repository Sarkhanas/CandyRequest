using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyRequest.Classes
{
    class Product : Person
    {
        public string id { get; set; }
        public string id_holiday { get; set; }
        public string name { get; set; }
        public string id_grade { get; set; }
        public string price { get; set; }
        public string image { get; set; }
        public string description { get; set; }
        public string id_busket { get; set; }

        public Product()
        {
            
        }

        public Product(List<string> values)
        {
            id = values[0];
            id_holiday = values[1];
            name = values[2];
            id_grade = values[3];
            price = values[4];
            description = values[5];
            id_busket = values[6];
        }

        public override List<string> retValues()
        {
            return new List<string>()
            {
                id, id_holiday, name, id_grade, price,
                image, description, id_busket
            };
        }
    }
}
