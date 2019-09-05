//No references should be added to the DLL.
using System;
using System.Reflection;
namespace ConsoleApp
{
    class ReflectionExample
    {
        static Assembly dll;
        static Type classInfo;
        static MethodInfo method;
        static ParameterInfo[] parameters;
        static object classInstance;
        static object[] parameterValues;
        const string filename = @"B:\Programs\Siemens2019\DotnetTraining\MathLibrary\bin\Debug\MathLibrary.dll";
        static void Main(string[] args)
        {
            try
            {
                loadTheDll();
                displayAndLoadTheClass();
                displayMethodsAndSelectIt();
                passParametersToit();
                invokeTheMethod();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void invokeTheMethod()
        {
            classInstance = Activator.CreateInstance(classInfo);//Creates the instance...
            object result = method.Invoke(classInstance, parameterValues);
            Console.WriteLine("The result of this operation is " + result);
        }

        private static void passParametersToit()
        {
            parameters = method.GetParameters();
            parameterValues = new object[parameters.Length];
            int index = 0;
            foreach(ParameterInfo pm in parameters)
            {
                Console.WriteLine("Enter the value for the parameter {0} of the type {1}", pm.Name, pm.ParameterType.Name);
                parameterValues[index] = Convert.ChangeType(Console.ReadLine(), pm.ParameterType);
                index++;
            }
            Console.WriteLine("All the parameters are set....");
        }

        //custom function created to resolve case sensitivity for the method name...
        private static MethodInfo getMethod(string methodName)
        {
            foreach(var method in classInfo.GetMethods())
            {
                if (method.Name.ToUpper() == methodName.ToUpper())
                    return method;
            }
            return null;
        }
        private static void displayMethodsAndSelectIt()
        {
            var methods = classInfo.GetMethods();
            foreach(var method in methods)
                Console.WriteLine(method.Name);
            Console.WriteLine("Enter the method from the list above\nPS: Its case sensitive");
            method = getMethod(Console.ReadLine());
            if (method == null)
                throw new Exception("Not a valid method of " + classInfo.Name);
        }

        private static void displayAndLoadTheClass()
        {
            //Displays all the UDTs of the DLL
            if(dll == null)
            {
                Console.WriteLine("No Dll was available");
                return;
            }
            var types = dll.GetTypes();//Gets all the UDTS of the Assembly...
            foreach (var type in types)
            {
                Console.WriteLine("Class: " + type.Name);
                Console.WriteLine("Namespace: " + type.Namespace);
                Console.WriteLine("FullName:" + type.FullName);
            }
            //Asks the user to select one type
            Console.WriteLine("Enter the Type in the form of FullName to get the Typeinfo");
            classInfo = dll.GetType(Console.ReadLine(),true, true);
            //Loads the class...
            
        }

        private static void loadTheDll()
        {
            dll = Assembly.LoadFile(filename);
            if (dll == null)
                throw new Exception("Dll could not be found to load it...");
        }
    }
}