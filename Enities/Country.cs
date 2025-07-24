using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRegistrationApp.Enities
{
    // Domain/Entities/Country.cs
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }

        // Navigation property for related States
        public List<State> States { get; set; }
    }

}
