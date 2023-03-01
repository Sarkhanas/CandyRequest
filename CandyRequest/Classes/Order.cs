using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyRequest.Classes
{
    class Order : Person
    {
        public string id { get; set; }
        public string FIO {get; set;}
        public string Adress { get; set; }
        public string Telephone { get; set; }
        public string Mail { get; set; }
        public string Obtain { get; set; }
        public string Payment { get; set; }
        public string id_busket { get; set; }

        public Order()
        {
            
        }

        public Order(List<string> values)
        {
            id = values[0];
            FIO = values[1];
            Adress = values[2];
            Telephone = values[3];
            Mail = values[4];
            Obtain = values[5];
            Payment = values[6];
            id_busket = values[7];
        }

        public override List<string> retValues()
        {
            return new List<string>()
            {
                id, FIO, Adress, Telephone, Mail, Obtain,
                Payment, id_busket
            };
        }
    }
}
