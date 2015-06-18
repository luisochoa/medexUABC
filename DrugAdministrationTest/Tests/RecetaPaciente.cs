using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DrugAdministrationTest.Tests
{
    public class RecetaPaciente
    {
        string doctorName = "Dr. Jose";
        DateTime dt = DateTime.Now;

        public RecetaPaciente(string namePatient){
            this.namePatient = namePatient;
        }
        
        public string getNameDoctor() {
            return doctorName;
        }
        
        public  string namePatient { get; set; }}
}
