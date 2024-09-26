using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    internal class PoliceStation : IMessageWritter
    {
        public List<PoliceCar> PoliceCars { get; private set; }

        public PoliceStation() {
            PoliceCars = new List<PoliceCar>();
        }
        public void RegisterPolice(string plate) {
            PoliceCars.Add(new PoliceCar(plate, this));
            Console.WriteLine($"Registered Police Car with plate {plate}");
        }
        
        public void Alert(string plate) {
            PoliceCars.ForEach(policeCar => policeCar.StartPersecution(plate, true));
        }

        public string WriteMessage(string message) {
            return $"{this}: {message}";
        }
    }
}
