using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    internal class City : IMessageWritter {
        public PoliceStation CityPoliceStation { get; private set; }
        private List<string> licenses = new List<string>();
        public string CityName {get; private set;}
        public City(string cityName) { 
            CityPoliceStation = new PoliceStation();
            CityName = cityName;
            Console.WriteLine(WriteMessage("Created."));
        }

        public void RegisterLicense(string license) {
            licenses.Add(license);
        }

        public void RemoveLicense(string license) {
            licenses.Remove(license);
        }

        public override string ToString() {
            return $"City {CityName}";
        }
        public string WriteMessage(string message) {
            return $"{this}: {message}";
        }
    }
}
