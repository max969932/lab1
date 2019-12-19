using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PageObject.Models;

namespace PageObject.Services
{
    class RouteCreator
    {
        public static Route WithAllProperties()
        {
            return new Route(TestDataReader.GetData("DepartureCity"), TestDataReader.GetData("ArrivalCity"), TestDataReader.GetData("DateDepart"));
        }

        public static Route WithEmptyArrivalCity()
        {
            return new Route(TestDataReader.GetData("DepartureCity"), "", "");
        }
    }
}
