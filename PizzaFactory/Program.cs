using System;

namespace PizzaFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopOrder = false;

            do
            {
                Console.WriteLine("Where do you want to order? A or B?");
                var pizzeria = Console.ReadLine();
                Console.WriteLine("What's your pizza order?");
                var order = Console.ReadLine();

                var factory = new PizzaFactory(pizzeria).Order(order);

                Console.WriteLine(factory.Prepare());
                Console.WriteLine(factory.Bake());
                Console.WriteLine(factory.Box());
                Console.WriteLine(factory.Cut());                                
                Console.WriteLine("Order another one?");
                var orderReply = Console.ReadLine();
                stopOrder = orderReply.ToLower().Contains("y") ? true : false;
            }
            while (stopOrder);            

        }
    }

    public class PizzaFactory
    {
        private readonly string _pizzeria;

        public PizzaFactory(string pizzeria)
        {
            _pizzeria = pizzeria;
        }
        
        public IPizza Order(string pizzaType)
        {
            switch (pizzaType.ToLower())
            {
                case "cheese":
                    return new CheesePizza(_pizzeria);
                case  "clam":
                    return new ClamPizza(_pizzeria);
                case  "veggies":
                    return new VeggiePizza(_pizzeria);                
                default:
                    return new CheesePizza(_pizzeria); //default vanilla order

            }
        }
    }

    public interface IPizza
    {
        string Prepare();
        string Bake();
        string Cut();
        string Box();
    }

    public class Pizza : IPizza
    {
        public string Bake()
        {
            return "Baking at 135 degree Celsius for 25 minutes";

        }

        public virtual string Box()
        {
            return "Putting pizza in Red coloured box";
        }

        public string Cut()
        {
            return "Cutting into diagonal pieces";
        }

        public virtual string Prepare()
        {
            return "Preparing Pizzeria A Style Clam Using Dough: Thin Crust, Cheese: Mozzarella, Sauce: Cherry Tomato, Veggies: Olives, Onion, Pepper, Clam: Frozen Clam";
        }
    }
    public class CheesePizza : Pizza
    {
        private readonly string _pizzeria;

        public CheesePizza(string pizzeria)
        {
            _pizzeria = pizzeria;
        }

        public override string Box()
        {
            if (_pizzeria.ToLower() == "a")
            {
                return "Putting pizza in Red coloured box";
            }
            else
            {
                return "Putting pizza in Green coloured box";
            }
            
        }

        public override string Prepare()
        {
            if ( _pizzeria.ToLower() == "a")
            {
                return "Preparing Pizzeria A Style Cheese Using Dough: Thin Crust, Cheese: Mozzarella, Sauce: Cherry Tomato, Veggies: Olives, Onion, Pepper";
            }
            else
            {
                return "Preparing Pizzeria B Style Cheese Using Dough: Deep Dish, Cheese: Parmesan, Sauce: Plum Tomato, Veggies: Cucumber, Onion, Pepper";
            }
            
        }

    }

    public class ClamPizza : Pizza
    {
        private readonly string _pizzeria;

        public ClamPizza(string pizzeria)
        {
            _pizzeria = pizzeria;
        }

        public override string Box()
        {
            if (_pizzeria.ToLower() == "a")
            {
                return "Putting pizza in Red coloured box";
            }
            else
            {
                return "Putting pizza in Green coloured box";
            }

        }

        public override string Prepare()
        {
            if (_pizzeria.ToLower() == "a")
            {
                return "Preparing Pizzeria A Style Clam Using Dough: Thin Crust, Cheese: Mozzarella, Sauce: Cherry Tomato, Veggies: Olives, Onion, Pepper, Clam: Frozen Clam";
            }
            else
            {
                return "Preparing Pizzeria B Style Clam Using Dough: Deep Dish,  Cheese: Parmesan,   Sauce: Plum Tomato,   Veggies: Cucumber, Onion, Pepper, Clam: Fresh Clam";
            }
            
        }
    }

    public class VeggiePizza : Pizza
    {
        private readonly string _pizzeria;

        public VeggiePizza(string pizzeria)
        {
            _pizzeria = pizzeria;
        }

        public override string Box()
        {
            if (_pizzeria.ToLower() == "a")
            {
                return "Putting pizza in Red coloured box";
            }
            else
            {
                return "Putting pizza in Green coloured box";
            }

        }

        public override string Prepare()
        {
            if (_pizzeria.ToLower() == "a")
            {
                return "Preparing Pizzeria A Style Veggie Using Dough: Thin Crust,  Sauce: Cherry Tomato, Veggies: Olives, Onion, Pepper";
            }
            else
            {
                return "Preparing Pizzeria B Style Veggie Using Dough: Deep Dish,   Sauce: Plum Tomato,   Veggies: Cucumber, Onion, Pepper";
            }

            
        }
    }

}
