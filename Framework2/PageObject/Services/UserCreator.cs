using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PageObject.Models;

namespace PageObject.Services
{
    class UserCreator
    {
        public static User WithAllProperties()
        {
            return new User(TestDataReader.GetData("FirstName"),
                TestDataReader.GetData("LastName"),
                TestDataReader.GetData("DateOfBirth"));
        }

        public static User WithEmptyArrivalCity()
        {
            return new User("", "", "");
        }
    }
}
