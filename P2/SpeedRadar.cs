namespace Practice2
{
    class SpeedRadar : IMessageWritter
    {
        //Radar doesn't know about Vechicles, just speed and plates
        private string plate;
        private float speed;
        private float legalSpeed = 50.0f;
        public List<float> SpeedHistory { get; private set; }

        public SpeedRadar()
        {
            plate = "";
            speed = 0f;
            SpeedHistory = new List<float>();
        }

        public void TriggerRadar(Vehicle vehicle)
        {
            if (vehicle is VehicleWithPlate vehicleWithPlate) {
                plate = vehicleWithPlate.GetPlate();
            }else {
                plate = "";
            }
            speed = vehicle.GetSpeed();
            SpeedHistory.Add(speed);
        }
        
        public string GetLastReading()
        {
            if (speed > legalSpeed)
            {
                return WriteMessage("Catched above legal speed.");
            }
            else
            {
                return WriteMessage("Driving legally.");
            }
        }

        public virtual string WriteMessage(string radarReading)
        {
            string hasPlate = plate != string.Empty ? $"plate {plate}" : "no plate";
            return $"Vehicle with {hasPlate} at {speed.ToString()} km/h. {radarReading}";
        }
    }
}