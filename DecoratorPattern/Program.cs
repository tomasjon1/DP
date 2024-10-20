namespace DecoratorPattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            IPizza myPizza = new Pizza();
            Console.WriteLine($"{myPizza.GetDescription()} costs {myPizza.GetCost()}");

            myPizza = new CheeseDecorator(myPizza);
            Console.WriteLine($"{myPizza.GetDescription()} costs {myPizza.GetCost()}");

            myPizza = new PepperoniDecorator(myPizza);
            Console.WriteLine($"{myPizza.GetDescription()} costs {myPizza.GetCost()}");
        }
    }

    public interface IPizza
    {
        string GetDescription();
        double GetCost();
    }

    public class Pizza : IPizza
    {
        private string _description;
        private double _cost;

        public Pizza()
        {
            _description = "Basic pizza";
            _cost = 5.0;
        }

        public string GetDescription() => _description;
        public double GetCost() => _cost;
    }

    public abstract class PizzaDecorator : IPizza
    {
        private IPizza _pizza;

        public PizzaDecorator(IPizza pizza) => _pizza = pizza;

        public virtual string GetDescription() => _pizza.GetDescription();
        public virtual double GetCost() => _pizza.GetCost();
    }

    public class PepperoniDecorator : PizzaDecorator
    {
        private string _topping = "peperoni";
        private double _cost = 1.5;

        public PepperoniDecorator(IPizza pizza) : base(pizza) { }

        public override string GetDescription() => base.GetDescription() + ", with " + _topping;
        public override double GetCost() => base.GetCost() + _cost;
    }

    public class CheeseDecorator : PizzaDecorator
    {
        private string _topping = "cheese";
        private double _cost = 2.5;

        public CheeseDecorator(IPizza pizza) : base(pizza) { }

        public override string GetDescription() => base.GetDescription() + ", with " + _topping;
        public override double GetCost() => base.GetCost() + _cost;
    }
}
