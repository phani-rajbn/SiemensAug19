//MultiThreadingPart2.cs: Using Thread Class....
using System;
using System.Threading;

namespace ConsoleApp
{
    class ThreadClassDemo
    {
        static void Main(string[] args)
        {
            //creatingAndCallingThreads();
            //parameterizedThreadExample();
            //backgroundThreads();
            threadPoolExample();
        }

        private static void threadPoolExample()
        {
            ThreadPool.QueueUserWorkItem((arg) =>
            {
                //arg is of the type object which is the parameter of the function that U want to invoke asynchronously...
                int value = Convert.ToInt32(arg);
                for (int i = 0; i < value; i++)
                {
                    Console.WriteLine("THread Function beep %{0}" ,i);
                    Thread.Sleep(1000);
                }
            }, 3);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("[Main] Thread is continuing its operations");
                Thread.Sleep(2000);
            }//Ensure that Main thread is longer than the Thread pool function as they are background threads and will terminate if the Main exits...
        }

        private static void backgroundThreads()
        {
            Console.WriteLine("[Main] Function started");
            Thread th = new Thread(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    Console.WriteLine("Worker Thread running");
                    Thread.Sleep(100);
                }
            });
            th.IsBackground = true;//Makes it the background thread....
            th.Start();
            Console.WriteLine("[Main] Function is back and doing some job");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("[Main] Function's operation");
                Thread.Sleep(100);
            }
            Console.WriteLine("[Main] function has terminating");
        }

        private static void parameterizedThreadExample()
        {
            //Thread functions can take only object as its argument and only one arg....
            //ParameterizedThreadStart..
            //ParameterizedThreadStart delobj = new ParameterizedThreadStart()
            Thread t2 = new Thread((obj) =>
            {
                //obj is of the type object.....
                if (obj is int[])
                {
                    int[] temp = obj as int[];
                    int max = 0;
                    int min = temp[0];//First Value....
                    for (int i = 0; i < temp.Length; i++)
                    {
                        if (temp[i] > max)
                            max = temp[i];
                        if (temp[i] < min)
                            min = temp[i];
                        Thread.Sleep(1000);//For delaying the func.....
                    }
                    Console.WriteLine("The Max Value in the Array is " + max);
                    Console.WriteLine("The Min Value in the Array is " + min);
                }else
                    Console.WriteLine("Invalid parameter for this thread");
            });
            t2.Start(new int[] { 345, 345, 345, 345, 345, 353, 434, 34, 53453, 453, 4345 });
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main is doing some job parallelly");
                Thread.Sleep(1000);
            }
        }

        private static void creatingAndCallingThreads()
        {
            //The Thread Class is used to create new Threads. All Threads in C# are objects of the Thread Class...
            ThreadStart delObj = new ThreadStart(() =>
            {
                int no = AsyncProgram.getAllEmployees();
                Console.WriteLine("The total Employees:" + no);
            });
            Thread t1 = new Thread(delObj);
            t1.Start();//Starts the Thread Execution....
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main is doing some job parallelly");
                Thread.Sleep(1000);
                if (i == 5)
                    t1.Suspend();//Pauses the thread from execution untill U explicitly call Resume Method....
            }
            if (t1.ThreadState == ThreadState.Suspended)
                t1.Resume();//Resumes the suspended thread...
        }
    }
}