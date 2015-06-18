using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Globalization;

namespace MedexTest.Controllers.Tests
{
    [TestFixture]
    public class HappyPathTest
    {
        /// Debe generar un reporte "A"

        /** a1 **/
        [Test]
        public void ShouldReturnDateNonNull()
        {
            //Disponer
            var sut = new ValuesController();

            // Actuar
            string result = "2015/06/17"; //del metodo de obtener fecha se espera que roterne un valor diferente de nulo
            string[] resultSeparation = result.Split('/');
            string notExpected = null;

            //declarar
            Assert.AreNotEqual(notExpected, resultSeparation[0]);
            Assert.AreNotEqual(notExpected, resultSeparation[1]);
            Assert.AreNotEqual(notExpected, resultSeparation[2]);
        }

        [Test]
        public void ShouldReturnDateOrderYearMonthDay()
        {
            DateTimeFormatInfo dtfi = CultureInfo.CreateSpecificCulture("en-US").DateTimeFormat;
            DateTime date = DateTime.Today;
            dtfi.DateSeparator = "/";
            dtfi.ShortDatePattern = @"yyyy/MM/dd";

            //Disponer
            var sut = new ValuesController();
            DateTime thisDay = DateTime.Today;

            // Actuar
            var result = "2015/06/12";  //sut.metodo(date) recibe como parametro un DateTime y retorna
            //en un string que tenga el orden de yyyy/MM/dd parte de la NOM
            var expected = date.ToString("d", dtfi);

            //Declarar
            StringAssert.Contains(expected, result);

        }

        //[Test]
        //public void ShouldReturnDateNull() { 
        //    //Disponer
        //     var sut = new ValuesController(); 

        //    //Actuar
        //     var result = DateTime.Today;  // se espera que retorne un null metodo de obtener fecha
        //     DateTime? expected = null;

        //    //Declarar
        //     Assert.AreEqual(expected, result);

        //}

        /*A.2*/
        [Test]
        public void ShouldReturnTimeNotNull()
        {
            DateTime dt = DateTime.Today;

            //Disponer
            var sut = new ValuesController();

            //Actuar
            //sut.metodo se espera que el metodo regrese un string con la hora
            //el string se debe separar con split('/')

            string resultHour = dt.Hour.ToString();
            string resultMin = dt.Minute.ToString();
            string resultSec = dt.Second.ToString();
            string notExpected = null;

            //Declarar
            Assert.AreNotEqual(notExpected, resultHour);
            Assert.AreNotEqual(notExpected, resultMin);
            Assert.AreNotEqual(notExpected, resultSec);
        }

        [Test]
        public void ShouldReturnStringOrderHourMinuteSecond()
        {
            DateTime dt = DateTime.Now;

            //Disponer
            var sut = new ValuesController();

            //Actuar
            string result = "12:12:12"; //sut.metodo debe retornar un string con la hora, por parametros recibe un datetime "dt"     
            string expected = dt.ToString("HH:mm:ss");

            //Declarar
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ShouldReturnTypeDataDatetime()
        { 
            //Disponer
            var sut = new ValuesController();

            //Actuar
            DateTime result = 
            //Declarar 
        }
    
    }
}
