using System;

/*
 * Patient info that stores patient details in a clinic(Outpatients).
 * ID, Name, Desease,  Doctor, Date, BillAmount. 
 */
namespace ConsoleApp
{
    namespace Entities
    {
        //Units of UR Program that make UR Application. They represent the real world objects that use UR Application. 
        //All classes are derived from System.Object...
        class Patient
        {
            public int PatientID { get; set; }
            public string Name { get; set; }
            public string Doctor { get; set; }
            public double BillAmount { get; set; }
            public DateTime BillDate { get; set; }
            public string Issue { get; set; }
            public override string ToString()
            {
                return string.Format($"The Name:{Name}\nThe Doctor:{Doctor}\nDate:{BillDate.ToLongDateString()}\n, BillAmount: {BillAmount:C}"); 
            }
        }
    }

    namespace DataLayer
    {
        using Entities;
        interface IPatientManager
        {
            void Modify(Patient patient);//Add the patient
            void Modify(int patientID, Patient patient);//Update the patient of that ID...
            void Modify(int patientID);//Delete the patient record....
            Patient[] FindPatient(string name);
            Patient FindPatient(int id);
        }

        class OutPatientManager : IPatientManager
        {
            Patient[] patients = null;
            readonly int size; 
            public OutPatientManager(int size)
            {
                patients = new Patient[size];
                this.size = size;
                //read only members are read only and can be assigned only in a constructor or at the variable declaration. Once set, It will not be modifiable....
            }
            public Patient[] FindPatient(string name)
            {
                var copy = new Patient[size];
                int index = 0;
                foreach (var patient in patients)
                {
                    if ((patient != null) && (patient.Name.Contains(name))){
                        copy[index] = patient;
                        index++;
                    }
                }
                return copy;
            }

            public Patient FindPatient(int id)
            {
                foreach(var patient in patients)
                {
                    if ((patient != null) && (patient.PatientID == id))
                        return patient;
                }
                throw new Exception($"No Patient by ID {id} found in our System");
            }

            public void Modify(Patient patient)
            {
                //When an array of refernce types is created, the array will hold null values inside it.....
                //We will iterate thro the array, find the first occurance of null in the array, and fill the data into it....
                for (int i = 0; i < size; i++)
                {
                    if(patients[i] == null)
                    {
                        patients[i] = new Patient();//create the object at that location...
                        //set the values of the patient into array's patient...
                        patients[i].BillAmount = patient.BillAmount;
                        patients[i].BillDate = patient.BillDate;
                        patients[i].Doctor = patient.Doctor;
                        patients[i].Issue = patient.Issue;
                        patients[i].Name = patient.Name;
                        patients[i].PatientID = patient.PatientID;
                        return;//Exit the Function after the insertion is done....
                    }
                }
                throw new Exception("New Patient cannot be added to the System");
            }

            public void Modify(int patientID, Patient patient)
            {
                throw new NotImplementedException();
            }

            public void Modify(int patientID)
            {
                for (int i = 0; i < size; i++)
                {
                    if((patients[i] != null) && (patients[i].PatientID == patientID))
                    {
                        patients[i] = null;
                        //U cannot delete an object in C#, only U could set the object to null, which is an informal way of removing all the data associated with that object including its memory....
                        return;
                    }
                }
                throw new Exception($"No Patient with the ID {patientID} found to remove");
            }
        }
    }

    namespace UILayer
    {
        using Entities;
        using DataLayer;
        using System.IO;
        
        class PatientInfoApp
        {
            
            static IPatientManager mgr = new OutPatientManager(10);
            static string getMenu(string filename)
            {
                StreamReader reader = new StreamReader(filename);
                string contents = reader.ReadToEnd();
                reader.Close();
                return contents;
            }
            static void Main(string[] args)
            {
                string menu = getMenu(args[0]);//Passing the 1st arg of the Command line args...
                bool processing = true;
                do
                {
                    string answer = Common.GetString(menu);
                    processing = processMenu(answer);
                    Console.WriteLine("Press any key to clear...!");
                    Console.ReadKey();
                    Console.Clear();
                } while (processing);
            }

            private static bool processMenu(string answer)
            {
                //create private helper functions to perform individual operations....
                switch (answer)
                {
                    case "1":
                        createNewPatient();
                        break;
                    case "2":
                        updatePatientDetails();
                        break;
                    case "3":
                        deletePatientDetails();
                        break;
                    case "4":
                        findAndDisplayPatient();
                        break;
                    case "5":
                        findAndDisplayAllPatients();
                        break;
                    default:
                        return false;
                }
                return true;
            }

            private static void findAndDisplayAllPatients()
            {
                var name = Common.GetString("Enter the name or part of Name to find");
                var patients = mgr.FindPatient(name);
                foreach(var patient in patients)
                {
                    if(patient != null)
                        Console.WriteLine(patient);
                }
            }

            private static void findAndDisplayPatient()
            {
                var id = Common.GetNumber("Enter the ID to find");
                var patient = mgr.FindPatient(id);
                if(patient == null)
                {
                    Console.WriteLine("Patient not found");
                }else
                    Console.WriteLine(patient);
            }

            private static void deletePatientDetails()
            {
                //Implicit typed variables in C#3.0 allows to create local variables in a convinient manner. They hold the datatype of what they are assigned. They are local variables, U cannot use var as a return type, parameters of a function or a field of a class. 
                var id = Common.GetNumber("Enter the Patient id to delete");
                mgr.Modify(id);//The overloaded function with only int is used for deleting...
            }

            private static void updatePatientDetails()
            {
                int id = Common.GetNumber("Enter the ID of the Patient to Update");
                string name = Common.GetString("Enter the Name to Update:");
                string doc = Common.GetString("Enter the Doctor Name to Update");
                string issue = Common.GetString("Enter the Issue to update");
                DateTime dt = Common.GetDate("Enter the Date to update in the format of dd/MM/yyyy"); ;//Get the System Date and Time...
                double amount = Common.GetDouble("Enter the Bill Amount to update");
                Patient patient = new Patient
                {
                    Name = name,
                    Doctor = doc,
                    BillAmount = amount,
                    BillDate = dt,
                    Issue = issue
                };
                mgr.Modify(id, patient);//pass the id as first arg and patient object as second to update...
            }

            private static void createNewPatient()
            {
                int id = Common.GetNumber("Enter the ID of the Patient");
                string name = Common.GetString("Enter the Name:");
                string doc = Common.GetString("Enter the Doctor Name");
                string issue = Common.GetString("Enter the Issue");
                DateTime dt = DateTime.Now;//Get the System Date and Time...
                double amount = Common.GetDouble("Enter the Bill Amount");
                Patient patient = new Patient
                {
                    PatientID = id,
                    Name = name,
                    Doctor = doc,
                    BillAmount = amount, 
                    BillDate = dt,
                    Issue = issue
                };
                try
                {
                    mgr.Modify(patient);
                    Console.WriteLine("Patient details added successfully");
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
