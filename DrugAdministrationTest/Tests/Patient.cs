using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DrugAdministrationTest.Tests
{
    class Patient
    {
        public string Name { get; set; }

        public List<PrescriptionMedications> GetTestMedicine()
        {
            var TestMedicine = new List<PrescriptionMedications>();
            TestMedicine.Add(new PrescriptionMedications { Id = 1, Name = "Aspirina bayer", Price = 1, adverseReaction = false });
            TestMedicine.Add(new PrescriptionMedications { Id = 2, Name = "Aspirina Forte", Price = 1, adverseReaction = false });
            TestMedicine.Add(new PrescriptionMedications { Id = 3, Name = "Sedalmerck", Price = 1, adverseReaction = true });
            TestMedicine.Add(new PrescriptionMedications { Id = 4, Name = "Aspirina bayer", Price = 1, adverseReaction = false });
            TestMedicine.Add(new PrescriptionMedications { Id = 5, Name = "Sedalmerck plus", Price = 1, adverseReaction = false });

            return TestMedicine;
        }
    }
}
