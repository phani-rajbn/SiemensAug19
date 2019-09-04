using System;
using System.Threading;
//In C# all events are objects of delegates....
namespace ConsoleApp
{
    class AlarmClock
    {
        public DateTime AlarmTime { get; set; }
        public event Action AlarmSound;
        public AlarmClock()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;
        }
        public void DisplayClock()
        {
            do
            {
                if(DateTime.Now.ToShortTimeString() == AlarmTime.ToShortTimeString())
                {
                    if(AlarmSound != null)
                    AlarmSound();
                }
                Console.WriteLine(DateTime.Now.ToLongTimeString());
                Thread.Sleep(1000);
                Console.Clear();
            } while (true);
        }
    }
    class Events
    {
        static void Main(string[] args)
        {
            AlarmClock clock = new AlarmClock();
            //clock.AlarmSound += Clock_AlarmSound;
            clock.AlarmSound += () => Console.WriteLine("Time to really go for Lunch");
            clock.AlarmTime = DateTime.Now.AddMinutes(1);
            clock.DisplayClock();
        }

        private static void Clock_AlarmSound()
        {
            Console.WriteLine("Time for Lunch Break"); 
        }
    }
}
