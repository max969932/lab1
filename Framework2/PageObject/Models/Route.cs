using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObject.Models
{
    class Route
    {
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public string DateDepart { get; set; }
        public string YesterdayDateDepart { get; set; }

        public Route(string departureCity, string arrivalCity, string dateDepart, string yesterdayDateDepart)
        {
            DepartureCity = departureCity;
            ArrivalCity = arrivalCity;
            DateDepart = dateDepart;
            YesterdayDateDepart = yesterdayDateDepart;
        }
    }
}
