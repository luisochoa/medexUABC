using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Globalization;
using DrugAdministrationTest.Tests;

namespace MedexTest.Controllers.Tests
{
    [TestFixture]
    public class HappyPathTest
    {
        /// Debe generar un reporte "A"
        /// Hola zules


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
            DateTime result = DateTime.Now;  //sut.metodo retorna un tipo de dato datetime
            DateTime expected = DateTime.Now;
            
            //Declarar 
            Assert.IsTrue(typeof(DateTime).IsInstanceOfType(result));
            
        }

        [Test]
        public void ShouldReturnTimeWithinTheRange(){
            DateTime dt = DateTime.Today;

            //Disponer
            var sut = new ValuesController();

            //Actuar
            string result = "12:12:12"; //sut metodo debe retonar el tiempo en string
            string[] separationResult = result.Split(':');
            string reultHour = separationResult[0];
            string reultMin = separationResult[1];
            string reultSec = separationResult[2];
            
            //nota duda de como debe ser el metodo
        }

        /*A.3*/

        [Test]
        public void ShouldReturnNameNotNull() {
            var sut = new ValuesController();

            String result = "luis";  //sut.metodo el metodo debe retornar la captura debe retornar un nombre(string) 
            String expected = null;

            Assert.AreNotEqual(expected,result);
        }

        [Test]
        public void ShouldAddNewNamePerson() { 
           
            //Disponer
            var sut = new ValuesController();
            
            //Actuar 
            string[] result = new string[] {"luis"};// Se espera que envie un nombre y que regres un array con el nombre dentro 
            string expected = "luis";

            //Declarar
            Assert.AreEqual(expected,result[0]);
        }


        /*
            Pruebas de vistas
         */
        
        //Generar Receta 

        //1.0
        [Test]
        public void ShouldReturnNewObjectWithNamePatient() {

            RecetaPaciente rp; // objeto creado para sustituir el objeto

            var sut = new ValuesController();

            string expected = "luis";    
            rp = new RecetaPaciente(expected); // sut.metodo debe regresar el nombre del paciente dentro del objeto

            Assert.AreEqual(expected, rp.namePatient);
        }
        
        //1.1
        [Test]
        public void ShouldReturnListName(){
            RecetaPaciente rp = new RecetaPaciente();
            var testListMedicine = rp.GetTestMedicine();
            
            var sut = new ValuesController();

            var result = testListMedicine;  //sut.metodo se espera que retorne una lista
            
            CollectionAssert.AreEqual(testListMedicine, result);
        }


        [Test]
        public void ShouldReturndetailsMedicine() {
            RecetaPaciente rp = new RecetaPaciente();
            var sut = new ValuesController();

            var result = rp.GetTestMedicine();
                //sut.metodo("Aspirine bayer",GetTestMedicine())  recibe por parametros una lista y se espera que retorne un solo elemento
           
            
            
            
        }
        [Test]
        public void ShouldAddNewObjectWithTheDoctorNameOfRecipeCreation() {
            string namePatient = "luis";
            RecetaPaciente rp = new RecetaPaciente(namePatient);

            var sut = new ValuesController();

            //para obtener el nombre del doctor es necesario haberlo capturado antes.
            string expected = "Dr. Jose";

            Assert.AreEqual(expected, rp.getNameDoctor());
        }

        [Test]
        public void ShouldAddNewObjectWithDateOfRecipeCreation(){

        } 

        [Test]
        public void ShouldAddNewObjectWithTimeOfRecipeCreation(){

        }
    }
}



