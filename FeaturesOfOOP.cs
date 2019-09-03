using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;//use this namespace...For XML serialization, the class should be public, there should be public properties and there is no need for Serializable attribute..


//Classes are designed as per the SOLID Principles of OOP. So must divide the code into multiple classes, each designed to do similar or one task. The classes can be extendable thro inheritance and modifiable without changing the signature thro' Overriding. A Class object variable can be instantiated to any of its sub-classes. All the functions defined in the base class will be retained by the object and those methods that are modified thro overriding will be invoking the overridden methods, there by achieving runtime polymorphism...Its good to have methods return the base type of object instead of derived type object as all the subtypes behave polymorphically once U work with the object. 
namespace ConsoleApp
{
    //Class to represent each test....
    [Serializable]
    public class Test
    {
        public int TestID { get; set; }
        public string TestName { get; set; }
        public int MaxScore { get; set; }
        public int Marks { get; set; }
    }
    [Serializable]
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public long PhoneNo { get; set; }
        public List<Test> AllTests { get; set; }
        public int TotalScore {
            get
            {
                int score = 0;
                foreach (var test in AllTests)
                    score += test.Marks;
                return score;
            }
        }
    }


    class ExaminationPortal
    {
        private List<Student> students;
        const string filename = "Students.xml";
        public ExaminationPortal()
        {
            students = new List<Student>();
            if (!File.Exists(filename))
                saveData();
            else
                loadData();
        }

        private void saveData()
        {
            //What to serialize...
            if (students == null) return;
            //WHere to serialize
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
            //How to serialize...
            XmlSerializer format = new XmlSerializer(typeof(List<Student>));
            format.Serialize(fs, students);
            fs.Close();
        }

        private void loadData()
        {
            //Where
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Read);
            //How...
            XmlSerializer format = new XmlSerializer(typeof(List<Student>));
            //What...
            students = format.Deserialize(fs) as List<Student>;
            fs.Close();
        }
        public void AddStudent(Student s)
        {
            students.Add(s);
            saveData();
        }

        public void UpdateMarks(Student s)
        {
            loadData();
            var student = students.Find((st) => st.StudentID == s.StudentID);
            if (student == null) throw new Exception("Student not found to update");
            student.StudentName = s.StudentName;
            student.AllTests = s.AllTests;
            student.PhoneNo = s.PhoneNo;
            saveData();
        }

        public List<Student> GetStudents()
        {
            loadData();
            return students;
        }
    }
    class FeaturesOfOOP
    {
        static string createMenu()
        {
            string menu = "~~~~~~~~~~~~~~Student Database~~~~~~~~~~~~~~~~\n";
            menu += "TO ADD STUDENT DETAILS------------------->PRESS 1\n";
            menu += "TO UPDATE STUDENT DETAILS---------------->PRESS 2\n";
            menu += "TO DISPLAY STUDENTS AND MARKS------------>PRESS 3\n";
            return menu;
        }
        static void Main(string[] args)
        {
            string menu = createMenu();
            bool processing = true;
            do
            {
                string choice = Common.GetString(menu);
                processing = processMenu(choice);
                clearScreen(processing);
            } while (processing);
        }

        private static bool processMenu(string choice)
        {
            switch (choice)
            {
                case "1":
                    addingStudentDetails();
                    break;
                case "2":
                    break;
                case "3":
                    break;
                default:
                    return false;
            }
            return true;
        }

        private static void addingStudentDetails()
        {
            Student s = new Student();
            s.AllTests = new List<Test>();
            s.StudentID = Common.GetNumber("Enter the Student ID");
            s.StudentName = Common.GetString("Enter the Student Name");
            s.PhoneNo = (long)Common.GetDouble("Enter the phone no");//double is typecasted...
            fillTestScores(s);
            ExaminationPortal portal = new ExaminationPortal();
            portal.AddStudent(s);
        }

        private static void fillTestScores(Student s)
        {
            string option = "Y";
            do
            {
                if (s.AllTests.Count == 5)
                {
                    Console.WriteLine("All test scores have been filled");
                    break;
                }
                Test t = new Test();
                t.TestName = Common.GetString("Enter the Test Name");
                t.MaxScore = Common.GetNumber("Enter the Max Score");
                t.Marks = Common.GetNumber("Enter the Marks scored");
                s.AllTests.Add(t);
                option = Common.GetString("Enter Y to add New test else any other key");
            } while (option.ToUpper() == "Y");
        }

        private static void clearScreen(bool processing)
        {
            if (processing)
            {
                Console.WriteLine("Press any key to clear...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
