using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyRequest.Classes
{
    class Sale : Person
    {
        public string id { get; set; }
        public string procent { get; set; }

        public Sale()
        {
        
        }

        public Sale(List<string> values)
        {
            id = values[0];
            procent = values[1];
        }

        public override List<string> retValues()
        {
            return new List<string>()
            {
                id,
                procent
            };
        }
    }
}
