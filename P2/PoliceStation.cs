using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2
{
    internal class PoliceStation : IMessageWritter
    {
        public List<PoliceCar> PoliceCars { get; private set; }

        public PoliceStation() {
            PoliceCars = new List<PoliceCar>();
        }
        public PoliceCar RegisterPolice(string plate, SpeedRadar speedRadar = null) {
            PoliceCar newPoliceCar = new PoliceCar(plate, this, speedRadar);
            PoliceCars.Add(newPoliceCar);
            Console.WriteLine(WriteMessage($"Registered Police Car with plate {plate}"));
            return newPoliceCar;
        }
        
        public void Alert(string plate) {
            Console.WriteLine(WriteMessage("Alerting every police car"));
            PoliceCars.ForEach(policeCar => policeCar.StartPersecution(plate));
        }

        public void EndAlert() {
            Console.WriteLine(WriteMessage("End of alert"));
            PoliceCars.ForEach(policeCar => policeCar.StopPersecution());
        }

        public override string ToString() {
            return "PoliceStation";
        }

        public string WriteMessage(string message) {
            return $"{this}: {message}";
        }
    }
}
