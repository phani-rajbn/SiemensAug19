using System;
using System.Threading;

namespace ConsoleApp
{
    using System.Data.SqlClient;
    using System.Runtime.Remoting.Messaging;

    class AsyncProgram
    {
        static void TestFunc(int duration)
        {
            for (int i = 0; i < duration; i++)
            {
                Console.WriteLine("Test is being conducted..");
                Thread.Sleep(2000);
            }
        }

        public static int getAllEmployees()
        {
            int rows = 0;
            using (var con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=SiemensDB;Integrated Security=True"))
            {
                var cmd = new SqlCommand("SELECT * FROM EMPTABLE", con);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("The Name:{0} from {1} with Salary {2:C}", reader[1], reader[2], reader[3]);
                    Thread.Sleep(1000);
                    rows += 1;
                }
            }
            return rows;
        }
        static void Main(string[] args)
        {
            //getAllEmployees();
            //voidFunctionDemo();
            //returnFunctionDemo();
            //returnFuncWithCallback();
        }

        private static void callMeAfterFinished(IAsyncResult rs)
        {
            AsyncResult obj = rs as AsyncResult;//Get the object associated with the IAsyncResult
            Func<int> delFunc = obj.AsyncDelegate as Func<int>;//Get the Delegate instance...
            int rows = delFunc.EndInvoke(rs);//Thro the del Instance, call its EndInvoke...
            Console.WriteLine("The Rows: " + rows);//Display the result...
            //PS: This function is invoked by CLR after the AsyncFunction has completed its job...
        }
        private static void returnFuncWithCallback()
        {
            
            Func<int> func = getAllEmployees;//Instance of the delegate created...
            Console.WriteLine("Main is doing some job");
            Console.WriteLine("Main Calls the Async Function");
            IAsyncResult res = func.BeginInvoke(callMeAfterFinished, null);
            Console.WriteLine("Main is back doing some job again");
            Console.WriteLine("Main ends its functionality, waiting to terminate the app");
            while(!res.IsCompleted)
            {
                Console.WriteLine("Please wait till we get the result");
                Thread.Sleep(1000);
            }
            //int rows = func.EndInvoke(res);//Makes the Main wait.....
            //In real time, EndInvoke is only used to get the return value of the Async Function..
            //Console.WriteLine("The No of Rows:" + rows);
        }

        private static void returnFunctionDemo()
        {
            Func<int> func = getAllEmployees;//Instance of the delegate created...
            Console.WriteLine("Main is doing some job");
            Console.WriteLine("Main Calls the Async Function");
            IAsyncResult res = func.BeginInvoke(null, null);
            Console.WriteLine("Main is back doing some job again");
            Console.WriteLine("Main ends its functionality, waiting to terminate the app");
            int rows = func.EndInvoke(res);//Makes the Main wait.....
            //In real time, EndInvoke is only used to get the return value of the Async Function..
            Console.WriteLine("The No of Rows:" + rows);
        }

        private static void voidFunctionDemo()
        {
            Console.WriteLine("Main program has started");
            //TestFunc(30);
            Action<int> action = TestFunc;
            IAsyncResult wait = action.BeginInvoke(3, null, null);//2nd parameter is the callback function that has to be called when the function is completed. 3rd parameter the object that invokes that function....
            Console.WriteLine("Main program is running");
            Console.WriteLine("Main has terminated");
            ///////////////////For IsCompleted///////////////////////////////
            //while (!wait.IsCompleted)
            //{
            //    Console.WriteLine("Please wait, our function is stilling working...");
            //    Thread.Sleep(1000);
            //}
            //////////////////////////WaitHandle object////////////////////////////////
            //var handler = wait.AsyncWaitHandle;
            //handler.WaitOne();
            ///////////////////////////EndInvoke method///////////////////
            //action.EndInvoke(wait);
        }
    }
}