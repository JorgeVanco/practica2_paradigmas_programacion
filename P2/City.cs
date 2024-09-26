using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    internal class City
    {
        public PoliceStation CityPoliceStation { get; private set; }
        private List<string> licenses = new List<string>();
        public City() { 
            CityPoliceStation = new PoliceStation();
        }

        public void RegisterLicense(string license) {
            licenses.Add(license);
        }

        public void RemoveLicense(string license) {
            licenses.Remove(license);
        }
    }
}
