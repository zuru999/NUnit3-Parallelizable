using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace NUnit_3.x.MozillaFirefoxTest
{
    [TestFixture]
    [Parallelizable]                            // atrybut który umozliwia prowadzenie etstu rownolegle z innymi. Sprawdza czy jest taka mozliwosc.

    public class FirefoxTesting : Hooks
    {


        public FirefoxTesting() : base(BrowserType.Firefox)
        {

        }




        [Test]
        public void FiredoxGoogleTest()
        {

            Driver.Navigate().GoToUrl("http://google.pl");
            Driver.FindElement(By.Name("q")).SendKeys("Selenium");
            System.Threading.Thread.Sleep(1500);
            Driver.FindElement(By.Name("btnG")).Click();
            Assert.That(Driver.PageSource.Contains("Selenium"), Is.EqualTo(true),
                                                "The text selenium doest not exist");

        }
    }
}
