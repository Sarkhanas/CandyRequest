using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyRequest.Classes
{
    class Admin
    {
        [Newtonsoft.Json.JsonProperty("Id")]
        public string Id { get; set; }

        [Newtonsoft.Json.JsonProperty("FIO")]
        public string FIO { get; set; }

        [Newtonsoft.Json.JsonProperty("Adress")]
        public string Adress { get; set; }

        [Newtonsoft.Json.JsonProperty("Telephone")]
        public string Telephone { get; set; }

        [Newtonsoft.Json.JsonProperty("Mail")]
        public string Mail { get; set; }

        [Newtonsoft.Json.JsonProperty("Obtain")]
        public string Obtain { get; set; }

        [Newtonsoft.Json.JsonProperty("Payment")]
        public string Payment { get; set; }
}
}
