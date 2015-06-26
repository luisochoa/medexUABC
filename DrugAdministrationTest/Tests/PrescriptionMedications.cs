using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DrugAdministrationTest.Tests
{
    public class PrescriptionMedications
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool adverseReaction { get; set; }
    }
}
