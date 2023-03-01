using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyRequest.Classes
{
    class Holiday : Person
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string id_sale { get; set; }

        public Holiday()
        {
            
        }

        public Holiday(List<string> values)
        {
            List<string> startDateList = values[3].ToString().Split('.').Reverse().ToList<string>();
            List<string> endDateList = values[4].ToString().Split('.').Reverse().ToList<string>();
            startDate = "";
            endDate = "";

            for (int i = 0; i < startDateList.Count; i++)
                if (i != startDateList.Count - 1)
                    startDate += startDateList[i] + "-";
                else startDate += startDateList[i];

            for (int i = 0; i < endDateList.Count; i++)
                if (i != endDateList.Count - 1)
                    endDate += endDateList[i] + "-";
                else endDate += endDateList[i];

            id = values[0];
            name = values[1];
            description = values[2];
           
            id_sale = values[5];
        }

        public override List<string> retValues()
        {
            return new List<string>()
            {
                id, name, description, startDate,
                endDate, id_sale
            };
        }
    }
}
