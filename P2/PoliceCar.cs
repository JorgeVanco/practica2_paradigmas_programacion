namespace Practice2
{
    class PoliceCar : VehicleWithPlate
    {
        //constant string as TypeOfVehicle wont change allong PoliceCar instances
        private const string typeOfVehicle = "Police Car"; 
        private bool isPatrolling;
        private SpeedRadar speedRadar;
        private bool isInPersecution= false;
        private string persecutionPlate = "";
        private PoliceStation policeStation;

        public PoliceCar(string plate, PoliceStation policeStation, SpeedRadar radar = null) : base(typeOfVehicle, plate)
        {
            isPatrolling = false;
            speedRadar = radar;
            this.policeStation = policeStation;

        }

        public void UseRadar(Vehicle vehicle)
        {

            if (isPatrolling && speedRadar != null)
            {
                speedRadar.TriggerRadar(vehicle);
                string meassurement = speedRadar.GetLastReading();
                Console.WriteLine(WriteMessage($"Triggered radar. Result: {meassurement}"));
            }
            else
            {
                Console.WriteLine(WriteMessage($"has no active radar."));
            }
        }

        public bool IsPatrolling()
        {
            return isPatrolling;
        }

        public void StartPatrolling()
        {
            if (!isPatrolling)
            {
                isPatrolling = true;
                Console.WriteLine(WriteMessage("started patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("is already patrolling."));
            }
        }

        public void EndPatrolling()
        {
            if (isPatrolling)
            {
                isPatrolling = false;
                Console.WriteLine(WriteMessage("stopped patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("was not patrolling."));
            }
        }

        public void PrintRadarHistory()
        {
            if (speedRadar != null) {
                Console.WriteLine(WriteMessage("Report radar speed history:"));
                foreach (float speed in speedRadar.SpeedHistory) {
                    Console.WriteLine(speed);
                }
            }
            else {
                Console.WriteLine(WriteMessage("Has no radar."));
            }
            
        }

        public void StartPersecution(string plate, bool wasAlerted = false) {
            if (!isInPersecution || persecutionPlate != plate) {
                isInPersecution = true;
                persecutionPlate = plate;
                if (!wasAlerted) {
                    Console.WriteLine(WriteMessage($"Sending alert for vehicle with plate: {persecutionPlate}"));
                    policeStation.Alert(plate);
                }
                else {
                    Console.WriteLine(WriteMessage($"Was alerted"));
                }
            }
        }

        public void StopPersecution() {
            isInPersecution = false;
            persecutionPlate = "";
            Console.WriteLine(WriteMessage($"Persecution stopped"));
        }

    }
}