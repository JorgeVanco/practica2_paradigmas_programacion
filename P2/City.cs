using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2
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
            Console.WriteLine(WriteMessage($"Registering license {license}"));
            licenses.Add(license);
        }

        public void RemoveLicense(string license) {
            Console.WriteLine(WriteMessage($"Removing license {license}"));
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
