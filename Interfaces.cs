using System;
namespace SampleConApp
{
    //Interfaces are similar to abstract classes where the intention is to have only abstract methods which could behave like a contract to the developer who implements the interface. The Class that implements the methods of the interface gaurentees that the methods are implemented by the class. All interfaces are abstract classes, but all abstract classes are not interfaces, as abstract classes can have normal methods. 
    //Interfaces ensure that there is a clean seperation b/w the declaration(Planning) and implementation(Enforcing). Interface specifies the contract and the implementor class will define the contract. 
    //Interfaces are the foundations for many of the real time frameworks that are working efficiently and popularly in the software industry. This includes Collections Frameworks, Database Frameworks, MVC Frameworks and many more. For all these interfaces are base level components that will be implemented by the upper classes providing customizations to the components. 
    interface ISimple
    {
        void SimpleFunc();
        //interface methods are public(Only public). There will no access specifiers. U cannot have fields in the interfaces, but U can have properties. interface methods cannot have a body. 
        //PS: According to C#8.0, interface have a concept called Default methods which can be implemented by the interface. 
    }

    interface IExample
    {
        void ExampleFunc();
    }

    interface IParty
    {
        void InviteFrieds();
        void OrderCake();
        void ServeFood();
        void ReturnGifts();
    }

    class BirthdayParty : IParty
    {
        public void InviteFrieds()
        {
            Console.WriteLine("Send whatsApp message to all");
        }

        public void OrderCake()
        {
            Console.WriteLine("Order cake from Cakes and Slices Shop"); 
        }

        public void ReturnGifts()
        {
            Console.WriteLine("Thanks for coming"); 
        }

        public void ServeFood()
        {
            Console.WriteLine("Order Food from Pizza Hut") ;
        }
    }

    class PromotionParty : IParty
    {
        public void InviteFrieds()
        {
            Console.WriteLine("Send Emails to all");
        }

        public void OrderCake()
        {
            Console.WriteLine("Get Cake from the Cafeteria");
        }

        public void ReturnGifts()
        {
            throw new NotImplementedException("Sorry, No gifts");
        }

        public void ServeFood()
        {
            Console.WriteLine("Serve Cool Drinks and Chips along with Cake"); 
        }
    }

    class EventManager
    {
        public static IParty CreateParty(string arg)
        {
            if (arg == "Birthday")
                return new BirthdayParty();
            else
                return new PromotionParty();
        }
    }

    class SimpleExample : IExample, ISimple
    {
        //All methods of the interface must be implemented as public in the implementor class. The method signature must not be changed in the implementation. If any of the methods are not implemented, then the methods should be still declared with abstract keyword and the class is also made as abstract.....
        public void ExampleFunc()
        {
            Console.WriteLine("Example Func");
        }

        public void SimpleFunc()
        {
            Console.WriteLine("Simple Func");
        }
    }
    class InterfaceDemo
    {
        static void Main(string[] args)
        {
            //IExample ex = new SimpleExample();
            //ex.ExampleFunc();

            //ISimple sim = new SimpleExample();
            //sim.SimpleFunc();
            Console.WriteLine("What kind of party U want");
            string answer = Console.ReadLine();
            IParty party = EventManager.CreateParty(answer);
            party.InviteFrieds();
            party.OrderCake();
            party.ServeFood();
            party.ReturnGifts();
        }
    }
}