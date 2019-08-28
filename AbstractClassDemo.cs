using System;
namespace ConApp
{
    //Abstract classes are classes that have atleast one Abstract method in them. Abstract methods are non implemented methods that are declared in the class to be implemented by its sub-classes. Abstract class however can have normal methods in them along with virtual methods.
    //As the Class contains unimplemented methods, the class is incomplete, so it cannot be instantiated. NOTE: Abstract classes cannot be instantiated. However U could create variables of the class but instantiate it to any of the derived classes that implement those abstract methods...
    //In this scenario, the derived class must implement all the abstract methods of the base class, else even the derived class becomes an abstract class. 

    abstract class Account
    {
        public int AccountNo { get; set; }
        public string CustomerName { get; set; }
        public double Balance { get; private set; }
        public void Credit(double amount)
        {
            Balance += amount;
        }
        public void Debit(double amount)
        {
            if (amount > Balance)
                throw new Exception("Insufficient Funds");
            Balance -= amount;
        }

        public abstract void CalculateInterest();
    }

    class SBAccount : Account
    {
        //override is now available for the base class methods that are virtual, override and abstract.
        public override void CalculateInterest()
        {
            var interest = this.Balance * 7 / 100 * 1 / 12;
            Credit(interest);
        }
    }
    //Create FD, RD and CC
    enum AccountType {  SB, RD, FD, CC };
    class AccountCreator
    {
        public static Account CreateAccount(AccountType acc)
        {
            switch (acc)
            {
                case AccountType.SB:
                    return new SBAccount();
                case AccountType.RD:
                case AccountType.FD:
                case AccountType.CC:
                default:
                    throw new Exception("Will come back to U");
            }
        }
    }
    class AbstractClassDemo
    {
        static void Main(string[] args)
        {
            Account acc = AccountCreator.CreateAccount(AccountType.SB);
            acc.CustomerName = "Phaniraj";
            acc.AccountNo = 12334;
            acc.Credit(5000);
            acc.Debit(3000);
            acc.CalculateInterest();
            Console.WriteLine("The Current balance: {0:C}", acc.Balance);
        }
    }
}