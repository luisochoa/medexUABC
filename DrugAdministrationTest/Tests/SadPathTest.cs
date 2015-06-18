using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MedexTest.Controllers;

namespace DrugAdministrationTest
{
    class SadPathTest
    {

        [Test]
        public void ShouldReturnDateNull()
        {
            //Disponer
            var sut = new ValuesController();

            //Actuar
            var result = DateTime.Today;  // se espera que retorne un null metodo de obtener fecha
            DateTime? expected = null;

            //Declarar
            Assert.AreEqual(expected, result);

        }

        [Test]
        public void ShouldReturnDateYearFieldNull()
        {
            var sut = new ValuesController();

        }
      
        
    }
}
