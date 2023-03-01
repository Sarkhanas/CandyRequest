using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyRequest.Classes
{
    class Basket : Person
    {
        public string id { get; set; }
        public string numOfProd { get; set; }
        public string price { get; set; }

        public Basket()
        {
            
        }

        public Basket(List<string> values)
        {
            id = values[0];
            numOfProd = values[1];
            price = values[2];
        }

        public override List<string> retValues()
        {
            return new List<string>()
            {
                id, numOfProd, price
            };
        }
    }
}
