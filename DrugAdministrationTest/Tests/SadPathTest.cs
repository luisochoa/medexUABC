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
        [ExpectedException(typeof(NullReferenceException))]
        public void Should_Throw_NullReferenceException_In_Date()
        {
            //Disponer
            var sut = new ValuesController();

            //Actuar
            var result = DateTime.Today;  // se espera que retorne un null metodo de obtener fecha
            //sut.PrintDate();

        }

        [Test]
        public void Should_Return_Null_Date()
        {
            var sut = new ValuesController();

            var result = DateTime.Today;
            DateTime? expected = null;

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Should_Return_Date_Fields_Null()
        {
            var sut = new ValuesController();

            var year = DateTime.Today.Year; // El values controller retorna un null
            var month = DateTime.Today.Month;
            var day = DateTime.Today.Day;

            DateTime? expected = null;

            Assert.AreEqual(expected, year);
            Assert.AreEqual(expected, month);
            Assert.AreEqual(expected, day);
            
        }

        [Test]
        public void Should_Return_Date_Without_DateTime_Type()
        {
            var sut = new ValuesController();


        }
      
        
    }
}
