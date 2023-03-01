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
    }
}
