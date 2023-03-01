using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyRequest.Classes
{
    class Grade : Person
    {
        public string id { get; set; }
        public string description { get; set; }

        public Grade()
        {
            
        }

        public Grade(List<string> values)
        {
            id = values[0];
            description = values[1];
        }

        public override List<string> retValues()
        {
            return new List<string>()
            {
                id, description
            };
        }
    }
}
