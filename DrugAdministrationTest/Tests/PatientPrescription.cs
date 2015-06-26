using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;


namespace DrugAdministrationTest.Tests
{
    public class PatientPrescription
    {

        DateTime dt = DateTime.Now;
        private DateTime dateTime;
        private string p1;
        private string p2;
        private DateTime date1;
        

        public PatientPrescription(string namePatient){
            this.namePatient = namePatient;
        }

        public PatientPrescription()
        {
            // TODO: Complete member initialization
        }

        public PatientPrescription(string nameDoctor, DateTime dateTime)
        {
            // TODO: Complete member initialization
            DateTimeFormatInfo dtfi = CultureInfo.CreateSpecificCulture("en-US").DateTimeFormat;
            dtfi.DateSeparator = "/";
            dtfi.ShortDatePattern = @"yyyy/MM/dd";

            this.nameDoctor = nameDoctor;
            this.dateTime = dateTime;
            
            date = dateTime.ToString("d", dtfi);
            time = dateTime.ToString("HH:mm:ss");
        }

        public PatientPrescription(string namePatient, string p2, DateTime date)
        {
            // TODO: Complete member initialization
            DateTimeFormatInfo dtfi = CultureInfo.CreateSpecificCulture("en-US").DateTimeFormat;
            dtfi.DateSeparator = "/";
            dtfi.ShortDatePattern = @"yyyy/MM/dd";

            this.namePatient = namePatient;
            this.nameDoctor = nameDoctor;
            dateTime = date;
            this.date = date.ToString("d", dtfi);
            time = dateTime.ToString("HH:mm:ss");

            //this.date = date;
        }

        public string nameDoctor { get; set; }
        
        public string namePatient { get; set; }

        public string date { get; set; }

        public string time { get; set; }
        
        public List < Medicine > GetTestMedicine()
        {
            var TestMedicine = new List <Medicine>();
            TestMedicine.Add(new Medicine { Name = "Aspirina bayer", Price = 1, modoEmpleo = new HowToUse() });
            TestMedicine.Add(new Medicine { Name = "Aspirina Forte", Price = 1, modoEmpleo = new HowToUse() });
            TestMedicine.Add(new Medicine { Name = "Sedalmerck", Price = 1, modoEmpleo = new HowToUse() });
            TestMedicine.Add(new Medicine { Name = "Aspirina bayer", Price = 1, modoEmpleo = new HowToUse() });
            TestMedicine.Add(new Medicine { Name = "Sedalmerck plus", Price = 1, modoEmpleo = new HowToUse() });

            return TestMedicine;
        }

        public List< Supplements > GetTestSupplements()
        {
            var testSupplements = new List<Supplements>();

            testSupplements.Add(new Supplements { Id = 1, Name = "Hiervas" });
            testSupplements.Add(new Supplements { Id = 2, Name = "Proteinas" });

            return testSupplements;
        }
    }
}
