using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MedexTest.Controllers;
using DrugAdministrationTest.Tests;

namespace DrugAdministrationTest
{
    [TestFixture]
    class SadPathTest
    {
        //a.1.1
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

        //a.1.1 de otra forma
        [Test]
        public void Should_Return_Null_Date()
        {
            var sut = new ValuesController();

            var date = DateTime.Today;
           // DateTime? expected = null;

            Assert.IsNull(date);
        }

        //a.1.2
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

        //a.1.4
        [Test]
        public void Should_Return_Date_Without_DateTime_Type()
        {
            var sut = new ValuesController();

            var date = DateTime.Today; //sut.method()
            Assert.IsNotInstanceOf<DateTime>(date);
        }

        //a.1.5.1
        [Test]
        public void Year_Not_In_Range()
        {
            var sut = new ValuesController();

            var year = DateTime.Today.Year; //sut.method();

            Assert.That(year, Is.Not.InRange(1880, DateTime.Today.Year));
        }

        //a.1.5.2
        [Test]
        public void Month_Not_In_Range()
        {
            var sut = new ValuesController();

            var month = DateTime.Today.Month; //sut.method();

            Assert.That(month, Is.Not.InRange(1, 12));
        }

        //a.1.5.3
        [Test]
        public void Day_Not_In_Range()
        {
            var sut = new ValuesController();

            var day = DateTime.Today.Day; //sut.method();

            Assert.That(day, Is.Not.InRange(1, 31));
        }

        //a.2.1
        [Test]
        public void Should_Return_Time_Fields_Null()
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

        //a.2.2
        [Test]
        public void Should_Return_Null_Time()
        {
            var sut = new ValuesController();

            var time = DateTime.Today.Hour; //sut.methoid();
            // DateTime? expected = null;

            Assert.IsNull(time);
        }

        //a.2.5
        [Test]
        public void Should_Return_Time_Without_DateTime_Type()
        {
            var sut = new ValuesController();

            var time = DateTime.Today.Hour; //sut.method();
            Assert.IsNotInstanceOf<DateTime>(time);
        }

        /**** Cambio al constraint model de aquí en adelante, es más completo ****/

        //a.2.6.1
        [Test]
        public void Hour_Not_In_Range() 
        {
            var sut = new ValuesController();

            var hour = DateTime.Today.Hour; //sut.method();
            
            Assert.That(hour, Is.Not.InRange(0, 23));
        }

        //a.2.6.2
        [Test]
        public void Minute_Not_In_Range()
        {
            var sut = new ValuesController();

            var minute = DateTime.Today.Hour; //sut.method();

            Assert.That(minute, Is.Not.InRange(0,59));
        }

        //a.2.6.3
        [Test]
        public void Second_Not_In_Range()
        {
            var sut = new ValuesController();

            var second = DateTime.Today.Hour; //sut.method();

            Assert.That(second, Is.Not.InRange(0, 59));
        }

        //a.3.1
        [Test]
        public void Should_Return_Null_Name_In_Supplier()
        {
            var sut = new ValuesController();
            string name = null; //sut.methodSupplier();

            Assert.That(name, Is.Null);
        }

        //a.3.2
        //[Test]


        //a.4.1
        [Test]
        public void Should_Return_Null_Name_In_Prescriber()
        {
            var sut = new ValuesController();
            string name = null; //sut.methodPrescriber();

            Assert.That(name, Is.Null);
        }

        //a.4.2
        [Test]
        public void Should_Return_Name_Without_String_Type()
        {
            var sut = new ValuesController();

            var name = "nombre"; //sut.method();
            //Assert.IsNotInstanceOf<String>(name);
            Assert.That(name, Is.Not.TypeOf(typeof(string)));
        }

        //c.1.1
        [Test]
        public void Should_Return_Null_String_Capture()
        {
            var sut = new ValuesController();
            string capture = "null";//sut.method();

            Assert.That(capture, Is.Null);
        }

        //c.1.2
        [Test]
        public void Should_Return_Non_Null_Medicine()
        {
            var sut = new ValuesController();
            /* */
            Medicine medicine = null; //sut.method(); Debería ser del tipo Medicine o equivalente, no string

            Assert.That(medicine, Is.Not.Null);
        }

        //d.1.1
        [Test]
        public void Should_Return_Drug_Without_Medicine_type()
        {
            var sut = new ValuesController();
            var medicine = new Medicine(); //sut.method();

            Assert.That(medicine, Is.Not.TypeOf(typeof(Medicine)));
        }

        //d.1.2
        [Test]
        public void Should_Display_Null_Medicines()
        {
            var sut = new ValuesController();
            List<Medicine> medicines = null; //Sut.method();

            Assert.That(medicines, Is.Null);
        }

        //d.1.3 
        [Test]
        public void Should_Return_Null_In_Captured_Complementaries()
        {
            var sut = new ValuesController();
            Medicine medicine = null; //sut.method();

            Assert.That(medicine, Is.Null);
        }

        //e.1.1
        [Test]
        public void Should_Return_Null_Medicines_While_Printing()
        {
            var sut = new ValuesController();
            List<Medicine> medicines = null; //sut.method(); devuelve la lista de medicamentos

            Assert.That(medicines, Is.Null);
        }

        //e.1.2
        [Test]
        public void Should_Return_Empty_Medicine_List_While_Printing()
        {
            var sut = new ValuesController();
            List<Medicine> medicines = null; //sut.method();

            Assert.That(medicines, Is.All.Null);
        }

        //e.1.3
        [Test]
        public void Should_Return_Some_Null_Medicine_In_List_While_Printing() 
        {
            var sut = new ValuesController();
            List<Medicine> medicines = null; //sut.method();

            Assert.That(medicines, Has.Some.Null);
        }

        //f.1.1
        [Test]
        public void Should_Return_Null_Medicines_While_Consulting()
        {
            var sut = new ValuesController();
            List<Medicine> medicines = null; //sut.method(); devuelve la lista de medicamentos

            Assert.That(medicines, Is.Null);
        }

        //f.1.2
        [Test]
        public void Should_Return_Empty_Medicine_List_While_Consulting()
        {
            var sut = new ValuesController();
            List<Medicine> medicines = null; //sut.method();

            Assert.That(medicines, Is.All.Null);
        }

        //f.1.3
        [Test]
        public void Should_Return_Some_Null_Medicine_In_List_While_Consulting()
        {
            var sut = new ValuesController();
            List<Medicine> medicines = null; //sut.method();
            
            Assert.That(medicines, Has.Some.Null);
        }

        //f.1.4
        //[Test]
        //public void 

        //g.1.1
        [Test]
        public void Should_Return_Null_Medicine_In_Adverse_Reactions()
        {
            var sut = new ValuesController();
            Medicine medicine = null; //sut.method();

            Assert.That(medicine, Is.Null);
        }

        //g.1.2
        [Test]
        public void Should()
        {
            var sut = new ValuesController();

        }

        //g.1.3
        [Test]
        public void Should_Return_Null_Notification()
        {
            var sut = new ValuesController();
            string notification = null; //sut.method();

            Assert.That(notification, Is.Null);
        }
    }
}
