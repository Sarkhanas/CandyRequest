using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyRequest.Classes
{
    abstract class Person
    {
        public string id { get; set; }

        public abstract List<string> retValues();
    }
}
