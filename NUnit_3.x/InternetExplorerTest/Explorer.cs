using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support;
using System.Collections;



namespace NUnit_3.x.InternetExplorerTest
{
   
    [TestFixture]
    [Parallelizable]

    public class IE_Testing : Hooks
    {

        
        public IE_Testing() : base(BrowserType.IE)
        {

        }



        [Test]
        public void IEGoogleTest()
        {
            Driver.Navigate().GoToUrl("http://google.pl");
            System.Threading.Thread.Sleep(2000);
            Driver.FindElement(By.Name("q")).SendKeys("Internet Explorer");
            Driver.FindElement(By.Name("btnG")).Click();
            Assert.That(Driver.PageSource.Contains("Internet Explorer"), Is.EqualTo(true),
                                                "The text Execute Automation doest not exist");
           
        }

    }

}
