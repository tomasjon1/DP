namespace AbstractFactoryPattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            IVehicleFactory factory;

            Console.WriteLine("=== Bike Factory ===");
            factory = new BikeFactory();
            IVehicle bike = factory.CreateVehicle();
            ITire bikeTire = factory.CreateTire();
            IEngine bikeEngine = factory.CreateEngine();

            bike.Drive();
            bikeTire.Inflate();
            bikeEngine.Start();
            bike.Refuel(); 

            Console.WriteLine("\n=== Car Factory ===");
            factory = new CarFactory();
            IVehicle car = factory.CreateVehicle();
            ITire carTire = factory.CreateTire();
            IEngine carEngine = factory.CreateEngine();

            car.Drive();
            carTire.Inflate();
            carEngine.Start();
            car.Refuel(); 
        }
    }

    public interface IVehicleFactory
    {
        IVehicle CreateVehicle();
        ITire CreateTire();
        IEngine CreateEngine();
    }

    public class BikeFactory : IVehicleFactory
    {
        public IVehicle CreateVehicle() => new ElectricBike();
        public ITire CreateTire() => new BikeTire();
        public IEngine CreateEngine() => new ElectricEngine();
    }

    public class CarFactory : IVehicleFactory
    {
        public IVehicle CreateVehicle() => new GasolineCar();
        public ITire CreateTire() => new CarTire();
        public IEngine CreateEngine() => new GasolineEngine();
    }

    public interface IVehicle
    {
        void Drive();
        void Refuel();
    }

    public class ElectricBike : IVehicle
    {
        public void Drive() => Console.WriteLine("Electric bike is driving silently.");
        public void Refuel() => Console.WriteLine("Electric bike is charging.");
    }

    public class GasolineCar : IVehicle
    {
        public void Drive() => Console.WriteLine("Gasoline car is driving with a roaring engine.");
        public void Refuel() => Console.WriteLine("Gasoline car is refueling at the gas station.");
    }

    public interface ITire { void Inflate(); }
    public class BikeTire : ITire { public void Inflate() => Console.WriteLine("Bike tire is inflating."); }
    public class CarTire : ITire { public void Inflate() => Console.WriteLine("Car tire is inflating."); }

    public interface IEngine { void Start(); }
    public class ElectricEngine : IEngine { public void Start() => Console.WriteLine("Electric engine is starting quietly."); }
    public class GasolineEngine : IEngine { public void Start() => Console.WriteLine("Gasoline engine is starting with a roar."); }
}
