using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DrugAdministrationTest.Tests
{
    class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ModoEmpleo modoEmpleo { get; set; }
    }
}
