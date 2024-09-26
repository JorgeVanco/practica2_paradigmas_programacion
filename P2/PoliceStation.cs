using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    internal class PoliceStation
    {
        public List<PoliceCar> PoliceCars { get; private set; }

        public PoliceStation() {
            PoliceCars = new List<PoliceCar>();
        }
        public void RegisterPolice(string plate) {
            PoliceCars.Add(new PoliceCar(plate, this));
        }
        
        public void Alert(string plate) {
            PoliceCars.ForEach(policeCar => policeCar.StartPersecution(plate, true));
        }
    }
}
