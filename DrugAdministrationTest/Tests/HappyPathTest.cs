using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MedexTest.Controllers.Tests
{
    [TestFixture]
    public class HappyPathTest
    {
        [Test]
        public void ShouldReturnDateNonNull()
        {
            //Disponer
            var sut = new ValuesController();
          
            // Actuar

            //declarar

        }

        [Test]
        public void ShouldReturnDateOrderYearMothDay()
        { 
            //Disponer
            var sut = new ValuesController();
            DateTime thisDay = DateTime.Today;

            // Actuar
            var result = "2015/06/16";
            var expected = thisDay.ToString();
            
            //Declarar
            Assert.That(result,expected);
        
        }
    }
}
