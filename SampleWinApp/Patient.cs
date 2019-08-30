using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWinApp
{
    class Patient
    {
        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public string Doctor { get; set; }
        public string Severity { get; set; }
        public double  BillAmount { get; set; }
    }

    class PatientDatabase
    {
        private List<Patient> patients = new List<Patient>(0);
        public PatientDatabase()
        {
            patients.Add(new Patient { PatientID = 1, PatientName = "Rajesh", BillAmount = 600, Doctor = "Mahesh", Severity = "Fever" });
            patients.Add(new Patient { PatientID = 2, PatientName = "Gopal", BillAmount = 600, Doctor = "Mahesh", Severity = "Fever" });
            patients.Add(new Patient { PatientID = 3, PatientName = "Suresh", BillAmount = 600, Doctor = "Mahesh", Severity = "Cold" });
        }
        public void AddNewPatient(Patient p)
        {
            patients.Add(p);
        }

        public void UpdatePatient(Patient p)
        {
            var found = patients.Find((pt) => pt.PatientID == p.PatientID);
            if (found == null)
                throw new Exception("Patient not found to update");
            found.PatientName = p.PatientName;
            found.Doctor = p.Doctor;
            found.BillAmount = p.BillAmount;
            found.Severity = p.Severity;
        }

        public void DeletePatient(int id)
        {
            var found = patients.Find((p) => p.PatientID == id);
            if (found == null)
                throw new Exception("Patient not found to Delete");
            patients.Remove(found);
        }

        public List<Patient> GetAllPatients()
        {
            return patients;
        }

    }
}
