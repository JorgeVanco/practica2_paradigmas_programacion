namespace Practice1
{
    internal class Program
    {

        static void Main()
        {
            Taxi taxi1 = new Taxi("0001 AAA");
            Taxi taxi2 = new Taxi("0002 BBB");
            Scooter scooter = new Scooter("Scooter");
            City city = new City("Madrid");
            city.RegisterLicense(taxi1.GetPlate());
            city.RegisterLicense(taxi2.GetPlate());

            PoliceStation cityStation = city.CityPoliceStation;
            
            SpeedRadar speedRadar1 = new SpeedRadar();
            PoliceCar policeCar1 = cityStation.RegisterPolice("0001 CNP", speedRadar1);

            // Police without a speedRadar
            PoliceCar policeCar2 = cityStation.RegisterPolice("0002 CNP");

            SpeedRadar speedRadar3 = new SpeedRadar();
            PoliceCar policeCar3 = cityStation.RegisterPolice("0003 CNP", speedRadar3);

            Console.WriteLine(taxi1.WriteMessage("Created"));
            Console.WriteLine(taxi2.WriteMessage("Created"));
            Console.WriteLine(policeCar1.WriteMessage("Created"));
            Console.WriteLine(policeCar2.WriteMessage("Created"));

            policeCar1.StartPatrolling();
            policeCar1.UseRadar(taxi1);

            taxi2.StartRide();
            policeCar2.UseRadar(taxi2);
            policeCar2.StartPatrolling();
            policeCar2.UseRadar(taxi2);
            taxi2.StopRide();
            policeCar2.EndPatrolling();

            taxi1.StartRide();
            taxi1.StartRide();
            policeCar1.StartPatrolling();
            policeCar1.UseRadar(taxi1);
            policeCar1.StartPersecution(taxi1.GetPlate());
            taxi1.StopRide();
            cityStation.EndAlert();
            taxi1.StopRide();
            policeCar1.EndPatrolling();

            policeCar1.PrintRadarHistory();
            policeCar2.PrintRadarHistory();



        }
    }
}
    

