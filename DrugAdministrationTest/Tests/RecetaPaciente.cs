using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;


namespace DrugAdministrationTest.Tests
{
    public class RecetaPaciente
    {

        DateTime dt = DateTime.Now;
        private DateTime dateTime;

        public RecetaPaciente(string namePatient){
            this.namePatient = namePatient;
        }

        public RecetaPaciente()
        {
            // TODO: Complete member initialization
        }

        public RecetaPaciente(string nameDoctor, DateTime dateTime)
        {
            // TODO: Complete member initialization
            this.nameDoctor = nameDoctor;
            this.dateTime = dateTime;
        }

        public string nameDoctor { get; set; }
        
        public string namePatient { get; set; }
        
        public List < Medicine > GetTestMedicine()
        {
            var TestMedicine = new List <Medicine>();
            TestMedicine.Add(new Medicine { Id = 1, Name = "Aspirina bayer", Price = 1 });
            TestMedicine.Add(new Medicine { Id = 2, Name = "Aspirina Forte", Price = 1 });
            TestMedicine.Add(new Medicine { Id = 3, Name = "Sedalmerck", Price = 1 });
            TestMedicine.Add(new Medicine { Id = 4, Name = "Aspirina bayer", Price = 1 });
            TestMedicine.Add(new Medicine { Id = 5, Name = "Sedalmerck plus", Price = 1 });

            return TestMedicine;
        }


        
    }
}
