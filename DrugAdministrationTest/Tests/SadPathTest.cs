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
        //a.1 1.1
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

        //a.1 1.1 de otra forma
        [Test]
        public void Should_Return_Null_Date()
        {
            var sut = new ValuesController();

            var date = DateTime.Today;
           // DateTime? expected = null;

            Assert.IsNull(date);
        }
        //a.1 1.2
        /* ¿Separar y checar cada campo en una prueba? */
        [Test]
        public void Should_Return_Date_Fields_Null()
        {
            var sut = new ValuesController();

            var year = DateTime.Today.Year; // El values controller retorna un null
            var month = DateTime.Today.Month;
            var day = DateTime.Today.Day;

           // DateTime? expected = null;

            Assert.IsNull(year);
            Assert.IsNull(month);
            Assert.IsNull(day);
        }

        //a.1 1.4
        [Test]
        public void Should_Return_Date_Without_DateTime_Type()
        {
            var sut = new ValuesController();

            var date = DateTime.Today; //sut.method()
            Assert.IsNotInstanceOf<DateTime>(date);
        }
        //a.2 2.1
        [Test]
        public void Should_Return_Hour_Fields_Null()
        {
            var sut = new ValuesController();

            var hour = DateTime.Today.Hour; // El values controller retorna un null
            var minute = DateTime.Today.Minute;
            var seconds = DateTime.Today.Second;

            // DateTime? expected = null;

            Assert.IsNull(hour);
            Assert.IsNull(minute);
            Assert.IsNull(seconds);
        }

        [Test]
        public void Should_Return_Null_Hour()
        {
            var sut = new ValuesController();

            var hour = DateTime.Today.Hour; //sut.methoid();
            // DateTime? expected = null;

            Assert.IsNull(hour);
        }

        [Test]
        public void Should_Return_Hour_Without_DateTime_Type()
        {
            var sut = new ValuesController();

            var hour = DateTime.Today.Hour; //sut.method();
            Assert.IsNotInstanceOf<DateTime>(hour);
        }
    }
}
