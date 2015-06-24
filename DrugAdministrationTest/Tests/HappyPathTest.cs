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

            PatientPrescription rp; // objeto creado para sustituir el objeto

            var sut = new ValuesController();

            string expected = "luis";    
            rp = new PatientPrescription(expected); // sut.metodo debe regresar el nombre del paciente dentro del objeto

            Assert.AreEqual(expected, rp.namePatient);
        }
        
        //1.1
        [Test]
        public void ShouldReturnListName(){
            PatientPrescription rp = new PatientPrescription();
            var testListMedicine = rp.GetTestMedicine();
            
            var sut = new ValuesController();

            var result = testListMedicine;  //sut.metodo se espera que retorne una lista
            
            CollectionAssert.AreEqual(testListMedicine, result);
        }

        //1.2
        [Test]
        public void ShouldReturndetailsMedicine() {
            PatientPrescription rp = new PatientPrescription();
            var sut = new ValuesController();

            var result = rp.GetTestMedicine();
                //sut.metodo("Aspirine bayer",GetTestMedicine())  recibe por parametros una lista y se espera que retorne un solo elemento
            var expected = rp.GetTestMedicine();

            Assert.AreEqual(expected[0],result);   // hacer cambios
            
        }

        //1.3
        [Test]
        public void ShouldRemoveAMedicineFromTheRecipe() {
            PatientPrescription rp = new PatientPrescription();

            var sut = new ValuesController();
                //sut.metodo() recibe por parametros el nombre y retorna la lista con elemento borrado
            var result = rp.GetTestMedicine();  // modificar metodo 
            var expected = rp.GetTestMedicine();
            expected.RemoveAt(0);

            CollectionAssert.AreEqual(expected, result);
        }

        //1.4
        [Test]
        public void ShouldAddANewMedicineAtTheRecipe() {
            PatientPrescription rp = new PatientPrescription();

            var sut = new ValuesController();

                //sut.metodo() recibe por parametros { Id = 6, Name = "Aspirina Plus++", Price = 1 }  y la lista
                //y retorna la lista con el nuevo elemento agregado
            var result = rp.GetTestMedicine();  // modificar metodo 
            var expected = rp.GetTestMedicine();
            expected.Add(new Medicine { Id = 6, Name = "Aspirina Plus++", Price = 1 });

            CollectionAssert.AreEqual(expected, result);
        }

        //1.5
        [Test]
        public void ShouldNewObjectWithTheDoctorNameOfRecipeCreation()
        {
            DateTime date = new DateTime(2008, 5, 1, 8, 30, 52);
            PatientPrescription rp = new PatientPrescription("Dr.Jose",DateTime.Now);

            var sut = new ValuesController();
            var result = rp.nameDoctor;
            //sut.metodo(); recibe por parametros el nombre del doctor se espera que retorne el nombre 
            // dentro del objeto
            var expected = "Dr.Jose";

            Assert.AreEqual(expected,result);
        }

        //1.6 
        [Test]
        public void ShouldNewObjectWithDateOfRecipeCreation(){
            DateTime date = new DateTime(2008, 5, 1, 8, 30, 52);
            PatientPrescription rp = new PatientPrescription("Dr.Jose", date);

            var sut = new ValuesController();
            var result = rp.date;
            //sut.metodo(); recibe por parametros un datetime y retorna la fecha
            var expected = "2008/05/01";

            Assert.AreEqual(expected, result);
        } 

        //1.7
        [Test]
        public void ShouldNewObjectWithTimeOfRecipeCreation(){
            DateTime date = new DateTime(2008, 5, 1, 8, 30, 52);
            PatientPrescription rp = new PatientPrescription("Dr.Jose", date);

            var sut = new ValuesController();
            var result = rp.time;
            //sut.metodo(); recibe un dateTime y retorna la fecha
            var expected = "08:30:52";

            Assert.AreEqual(expected, result);
        }

        //1.8 
        [Test]
        public void ShouldReturnsMessageAdverseReaction() {
            var sut = new ValuesController();

            var result = "reaccion adversa";//sut.metod(name); recibe el nombre del medicamento y la lista
                //y se retorna un mensaje de reaccion adversa 
            var expected = "reaccion adversa";

            Assert.AreEqual(expected, result);
        }

        //2.0
        [Test]
        public void ShouldAddANewSupplementToList(){
            var sut = new ValuesController();
            PatientPrescription rp = new PatientPrescription();

            var result = rp.GetTestSupplements(); //sut.metodo(Id = 3, Name = "Suplemento C" ,List)
            //agrega un nuevo suplemento, se le envia el nombre y ID del suplemento
            var expected = rp.GetTestSupplements();
            expected.Add(new Supplements { Id = 3, Name = "Suplemento C" });
            
            CollectionAssert.AreEqual(expected,result);
        }

        //2.1
        [Test]
        public void ShouldRemoveAnItemFromTheList() {
            var sut = new ValuesController();
            PatientPrescription rp = new PatientPrescription();


            var result = rp.GetTestSupplements(); //sut.metodo eliminar un elemento de la lista recibe por 
            //parametros la lista y el nombre del suplemento
            var expected = rp.GetTestSupplements();
            expected.RemoveAt(2);

            CollectionAssert.AreEqual(expected,result);
        }

        //3.1
        [Test]
        public void ShouldAddNewNoneExistentMedicineToList() {

            var sut = new ValuesController();

            var result = GetTestNonexistentMedicines();
            //sut.metodo(name,List) "Aspirina plus" recibe por parametros el nombre del medicamento inexistente y la lista
            var expected = GetTestNonexistentMedicines();
            expected.Add(new NonexistentMedicines { Name = "Aspirina plus" });

            CollectionAssert.AreEqual(expected, result);
        }

        public List<NonexistentMedicines> GetTestNonexistentMedicines()
        {
            var testNonexistentMedicines = new List<NonexistentMedicines>();

            testNonexistentMedicines.Add(new NonexistentMedicines { Name = "Aspirina bayer" });
            testNonexistentMedicines.Add(new NonexistentMedicines { Name = "Proteinas" });

            return testNonexistentMedicines;
        }
    
        //4.1
        [Test]
        public void ShouldReturnsThePatientsMedicalRecord()
        {
            var sut = new ValuesController();

            var result = GetAllPatients();
            //sut.metodo("Luis") recibe por parametros el nombre del paciente y la lista de pacientes
            // retorna el elemento que pertenezca al nombre
            var expected = GetAllPatients();

            Assert.AreEqual(expected[0], result);
        }

        public List<Patient> GetAllPatients()
        {
            var testPatients = new List<Patient>();

            testPatients.Add(new Patient { Name = "Luis" });
            testPatients.Add(new Patient { Name = "Jorge" });

            return testPatients;
        }       
    
        //5.1
        [Test]
        public void ShouldReturnsAllPatientPrescriptions() {

            var sut = new ValuesController();

            var result = GetAllPatientPrescription();  //recibe por parametros "jorge" y la Lista
            //sut.metodo debe retornar una lista con todas las recetas del paciente
            var expected = GetAllPatientPrescriptionPatient();

            CollectionAssert.AreEqual(expected, result);
        }

        //5.2
        [Test]
        public void ShouldReturnsAllPrescriptionsTheDoctorOrdered()
        {

            var sut = new ValuesController();

            var result = GetAllPatientPrescription(); //recibe por parametros el nombre del doctor y la lista
            //sut.metodo debe retornar una lista con todas las recetas del paciente
            var expected = GetAllPatientPrescriptionDoctor();

            CollectionAssert.AreEqual(expected, result);
        }
        //5.3.1
        [Test]
        public void ShouldReturnsAllPrescriptionsFilteredByYear()
        {

            var sut = new ValuesController();

            var result = GetAllPatientPrescription();  //sut.metodo debe retornar una lista con todas las recetas del paciente
            var expected = GetAllPatientPrescriptionDateYear();

            CollectionAssert.AreEqual(expected, result);
        }
        
        //5.3.2
        [Test]
        public void ShouldReturnsAllPrescriptionsFilteredByMoth()
        {

            var sut = new ValuesController();

            var result = GetAllPatientPrescription();  //sut.metodo debe retornar una lista con todas las recetas del paciente
            var expected = GetAllPatientPrescriptionDateMoth();

            CollectionAssert.AreEqual(expected, result);
        }

        public List<PatientPrescription> GetAllPatientPrescription()
        {
            var testPatientPrescription = new List<PatientPrescription>();
            DateTime date;

            date = new DateTime(2015, 5, 1, 8, 30, 52);
            testPatientPrescription.Add(new PatientPrescription("Luis", "Dr.House", date));
            date = new DateTime(2015, 5, 1, 9, 30, 52);
            testPatientPrescription.Add(new PatientPrescription("Jorge", "Dr.Simi", date));
            date = new DateTime(2015, 5, 1, 10, 30, 52);
            testPatientPrescription.Add(new PatientPrescription("Jorge", "Dr.House", date));
            date = new DateTime(2016, 5, 1, 8, 30, 00);
            testPatientPrescription.Add(new PatientPrescription("Jorge", "Dr.Simi", date));
            date = new DateTime(2016, 5, 1, 9, 30, 00);
            testPatientPrescription.Add(new PatientPrescription("Luis", "Dr.House", date));
            date = new DateTime(2016, 5, 1, 10, 30, 00);
            testPatientPrescription.Add(new PatientPrescription("Luis", "Dr.House", date));

            return testPatientPrescription;
        }

        public List<PatientPrescription> GetAllPatientPrescriptionPatient()
        {
            var testPatientPrescription = new List<PatientPrescription>();
            DateTime date;

            date = new DateTime(2015, 5, 1, 9, 30, 52);
            testPatientPrescription.Add(new PatientPrescription("Jorge", "Dr.Simi", date));
            date = new DateTime(2015, 5, 1, 10, 30, 52);
            testPatientPrescription.Add(new PatientPrescription("Jorge", "Dr.House", date));
            date = new DateTime(2016, 5, 1, 8, 30, 00);
            testPatientPrescription.Add(new PatientPrescription("Jorge", "Dr.Simi", date));


            return testPatientPrescription;
        }

        public List<PatientPrescription> GetAllPatientPrescriptionDoctor()
        {
            var testPatientPrescription = new List<PatientPrescription>();
            DateTime date;

            date = new DateTime(2015, 5, 1, 8, 30, 52);
            testPatientPrescription.Add(new PatientPrescription("Luis", "Dr.House", date));
            date = new DateTime(2016, 5, 1, 9, 30, 00);
            testPatientPrescription.Add(new PatientPrescription("Luis", "Dr.House", date));
            date = new DateTime(2016, 5, 1, 10, 30, 00);
            testPatientPrescription.Add(new PatientPrescription("Luis", "Dr.House", date));

            return testPatientPrescription;
        }

        public List<PatientPrescription> GetAllPatientPrescriptionDateYear()
        {
            var testPatientPrescription = new List<PatientPrescription>();
            DateTime date;

            date = new DateTime(2015, 5, 1, 8, 30, 52);
            testPatientPrescription.Add(new PatientPrescription("Luis", "Dr.House", date));
            date = new DateTime(2015, 5, 1, 9, 30, 52);
            testPatientPrescription.Add(new PatientPrescription("Jorge", "Dr.Simi", date));
            date = new DateTime(2015, 5, 1, 10, 30, 52);
            testPatientPrescription.Add(new PatientPrescription("Jorge", "Dr.House", date));

            return testPatientPrescription;
        }

        public List<PatientPrescription> GetAllPatientPrescriptionDateMoth()
        {
            var testPatientPrescription = new List<PatientPrescription>();
            DateTime date;

            date = new DateTime(2015, 5, 1, 8, 30, 52);
            testPatientPrescription.Add(new PatientPrescription("Luis", "Dr.House", date));
            date = new DateTime(2015, 5, 1, 9, 30, 52);
            testPatientPrescription.Add(new PatientPrescription("Jorge", "Dr.Simi", date));
            date = new DateTime(2015, 5, 1, 10, 30, 52);
            testPatientPrescription.Add(new PatientPrescription("Jorge", "Dr.House", date));
            date = new DateTime(2016, 5, 1, 8, 30, 00);
            testPatientPrescription.Add(new PatientPrescription("Jorge", "Dr.Simi", date));
            date = new DateTime(2016, 5, 1, 9, 30, 00);
            testPatientPrescription.Add(new PatientPrescription("Luis", "Dr.House", date));
            date = new DateTime(2016, 5, 1, 10, 30, 00);
            testPatientPrescription.Add(new PatientPrescription("Luis", "Dr.House", date));

            return testPatientPrescription;
        }
    }
}





