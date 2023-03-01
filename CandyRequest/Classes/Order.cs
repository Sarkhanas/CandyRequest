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
    }
}
