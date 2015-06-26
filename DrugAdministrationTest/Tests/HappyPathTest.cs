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
        public void ShouldReturnStringOrderHourMinuteSecond()
        {
            DateTime dt = new DateTime(2015, 4, 1, 10, 30, 52);

            //Disponer
            var sut = new ValuesController();

            //Actuar
            string result = "10:30:52"; //sut.metodo debe retornar un string con la hora, por parametros recibe un datetime "dt"     
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
        public void ShouldReturnDetailsMedicine() {
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
            expected.Add(new Medicine { Name = "Aspirina Plus++", Price = 1 });

            CollectionAssert.AreEqual(expected, result);
        }

        //1.5
        [Test]
        public void ShouldAddNewObjectWithTheDoctorNameOfRecipeCreation()
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
        public void ShouldAddNewObjectWithDateOfRecipeCreation(){
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
        public void ShouldAddNewObjectWithTimeOfRecipeCreation(){
            DateTime date = new DateTime(2008, 5, 1, 8, 30, 52);
            PatientPrescription rp = new PatientPrescription("Dr.Jose", date);

            var sut = new ValuesController();
            var result = rp.time;
            //sut.metodo(); recibe un dateTime y retorna la fecha
            var expected = "08:30:52";

            Assert.AreEqual(expected, result);
        }


        //checar hacer cambios
        [Test]
        public void ShouldReturnMessageAdverseReaction() {
            var sut = new ValuesController();

            var result = "reaccion adversa";//sut.metod();  La lista de los medicamentos 
                                            //adversos del paciente y el nombre del nuevo medicamento
                                            // Que el paciente presento reaccion adversa 
                                            //y se retorna un mensaje de reaccion adversa 
            var expected = "reaccion adversa";
            
            Assert.AreEqual(expected, result);
        }

        //2.0
        [Test]
        public void ShouldAddANewSupplementToList(){
            var sut = new ValuesController();
            PatientPrescription rp = new PatientPrescription();

            var result = rp.GetTestSupplements();   //sut.metodo(Id = 3, Name = "Suplemento C" ,List)
                                                    //agrega un nuevo suplemento, se le envia el nombre y ID del suplemento
            var expected = rp.GetTestSupplements();
            expected.Add(new Supplements { Id = 3, Name = "Suplemento C" });
            
            CollectionAssert.AreEqual(expected,result);
        }

        //2.1
        [Test]
        public void ShouldRemoveSupplementFromTheList() {
            var sut = new ValuesController();
            PatientPrescription rp = new PatientPrescription();


            var result = rp.GetTestSupplements();   //sut.metodo eliminar un elemento de la lista recibe por 
                                                    //parametros la lista y el nombre del suplemento
            var expected = rp.GetTestSupplements();
            expected.RemoveAt(1);

            CollectionAssert.AreEqual(expected,result);
        }

        //3.1
        [Test]
        public void ShouldAddNewNoneExistentMedicineToList() 
        {

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
            List<Patient> testPatients = new List<Patient>();

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
            //prueba que sea equivalente
            Assert.That(expected, Is.EquivalentTo(result));
        }

        //5.2
        [Test]
        public void ShouldReturnsAllPrescriptionsTheDoctorOrdered()
        {

            var sut = new ValuesController();

            var result = GetAllPatientPrescription(); // sut.metodo("Dr.House","Luis")
            //recibe por parametros el nombre del nombre del paciente, nombre del doctor y la lista
            //sut.metodo debe retornar una lista con todas las recetas del paciente
            var expected = GetAllPatientPrescriptionDoctor();

            CollectionAssert.AreEqual(expected, result);
        }
        //5.3.1
        [Test]
        public void ShouldReturnsAllPrescriptionsFilteredByYear()
        {

            var sut = new ValuesController();

            var result = GetAllPatientPrescription();  //sut.metodo()
            //por parametros se envia nombre del paciente, una fecha. debe regresar una lista con coicidencia del año 2015
            //debe retornar una lista con todas las recetas del paciente
            var expected = GetAllPatientPrescriptionDateYear();

            CollectionAssert.AreEqual(expected, result);
        }
        
        //5.3.2
        [Test]
        public void ShouldReturnsAllPrescriptionsFilteredByMonth()
        {

            var sut = new ValuesController();

            var result = GetAllPatientPrescription();   //sut.metodo()
                                                        //recibe por parametros nombre del paciente, y una fecha
                                                        // luis, 2015/04/??
                                                        //debe retornar una lista con todas las recetas del paciente
            var expected = GetAllPatientPrescriptionDateMonth();

            CollectionAssert.AreEqual(expected, result);
        }

        //5.4
        [Test]
        public void ShouldReturnTheDetailsOfThePrescription()
        {
            var sut = new ValuesController();

            var result = GetAllPatientPrescription();   //sut.metodo
                                                    //se envia por parametros la lista y la especificacion de la receta
                                                    //simula que selecciono una receta
            var expect = GetAllPatientPrescription();

            Assert.AreEqual(expect[0],result);
        }

        public List<PatientPrescription> GetAllPatientPrescription()
        {
            var testPatientPrescription = new List<PatientPrescription>();
            DateTime date;

            date = new DateTime(2015, 4, 1, 8, 30, 52);
            testPatientPrescription.Add(new PatientPrescription("Luis", "Dr.House", date));
            date = new DateTime(2015, 5, 1, 9, 30, 52);
            testPatientPrescription.Add(new PatientPrescription("Jorge", "Dr.Simi", date));
            date = new DateTime(2015, 6, 1, 10, 30, 52);
            testPatientPrescription.Add(new PatientPrescription("Jorge", "Dr.House", date));
            date = new DateTime(2016, 4, 1, 8, 30, 00);
            testPatientPrescription.Add(new PatientPrescription("Jorge", "Dr.Simi", date));
            date = new DateTime(2016, 5, 1, 9, 30, 00);
            testPatientPrescription.Add(new PatientPrescription("Luis", "Dr.House", date));
            date = new DateTime(2016, 6, 1, 10, 30, 00);
            testPatientPrescription.Add(new PatientPrescription("Luis", "Dr.House", date));

            return testPatientPrescription;
        }

        public List<PatientPrescription> GetAllPatientPrescriptionPatient()
        {
            var testPatientPrescription = new List<PatientPrescription>();
            DateTime date;

            date = new DateTime(2015, 5, 1, 9, 30, 52);
            testPatientPrescription.Add(new PatientPrescription("Jorge", "Dr.Simi", date));
            date = new DateTime(2015, 6, 1, 10, 30, 52);
            testPatientPrescription.Add(new PatientPrescription("Jorge", "Dr.House", date));
            date = new DateTime(2016, 4, 1, 8, 30, 00);
            testPatientPrescription.Add(new PatientPrescription("Jorge", "Dr.Simi", date));

            return testPatientPrescription;
        }

        public List<PatientPrescription> GetAllPatientPrescriptionDoctor()
        {
            var testPatientPrescription = new List<PatientPrescription>();
            DateTime date;

            date = new DateTime(2015, 4, 1, 8, 30, 52);
            testPatientPrescription.Add(new PatientPrescription("Luis", "Dr.House", date));
            date = new DateTime(2016, 5, 1, 9, 30, 00);
            testPatientPrescription.Add(new PatientPrescription("Luis", "Dr.House", date));
            date = new DateTime(2016, 6, 1, 10, 30, 00);
            testPatientPrescription.Add(new PatientPrescription("Luis", "Dr.House", date));

            return testPatientPrescription;
        }

        public List<PatientPrescription> GetAllPatientPrescriptionDateYear()
        {
            var testPatientPrescription = new List<PatientPrescription>();
            DateTime date;

            date = new DateTime(2015, 5, 1, 9, 30, 52);
            testPatientPrescription.Add(new PatientPrescription("Jorge", "Dr.Simi", date));
            date = new DateTime(2015, 6, 1, 10, 30, 52);
            testPatientPrescription.Add(new PatientPrescription("Jorge", "Dr.House", date));

            return testPatientPrescription;
        }

        public List<PatientPrescription> GetAllPatientPrescriptionDateMonth()
        {
            var testPatientPrescription = new List<PatientPrescription>();
            DateTime date;

            date = new DateTime(2015, 4, 1, 8, 30, 52);
            testPatientPrescription.Add(new PatientPrescription("Luis", "Dr.House", date));

            return testPatientPrescription;
        }
        
        //5.5 ventana de empleo
        [Test]
        public void ShouldAddDetailsForUse()
        {
            var sut = new ValuesController();

            var result = true;  //sut.metodo se envia 4 parametros la lista de medicamento y 
                                //dosis, via de administracion y periodo
            var expected = true;

            Assert.AreEqual(expected, result);
        }
    }
}