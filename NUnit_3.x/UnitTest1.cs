using System;
using NUnit.Framework;
using OpenQA.Selenium;



namespace NUnit_3.x
{
    [TestFixture]
    [Parallelizable]                            // atrybut który umozliwia prowadzenie etstu rownolegle z innymi. Sprawdza czy jest taka mozliwosc.

    public class FirefoxTesting : Hooks
    {


        public FirefoxTesting() : base (BrowserType.Firefox)
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



    [TestFixture]
    [Parallelizable]

    public class ChromeTesting : Hooks
    {


        public ChromeTesting() : base (BrowserType.Chrome)
        {

        }



        [Test]
        public void ChromeGoogleTest()
        {
            Driver.Navigate().GoToUrl("http://google.pl");
            Driver.FindElement(By.Name("q")).SendKeys("Execute Automation");
            Driver.FindElement(By.Name("btnG")).Click();
            Assert.That(Driver.PageSource.Contains("Execute Automation"), Is.EqualTo(true),
                                                "The text Execute Automation doest not exist");
        }
    }

}
