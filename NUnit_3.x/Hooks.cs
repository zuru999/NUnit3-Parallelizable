using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NUnit_3.x
{

   public enum BrowserType
    {
        Chrome,
        Firefox,
        IE
    }


    [TestFixture]
    public class Hooks : Base
    {

        private BrowserType _browserType;

        public Hooks(BrowserType browser)
        {
            _browserType = browser;
            
            
            //Driver = new FirefoxDriver();
            //Driver = new ChromeDriver();
        }

        [SetUp]
        public void InitializeTest()
        {
            ChooseDriverInstance(_browserType);
        }

        private void ChooseDriverInstance(BrowserType browserType)
        {
            if (browserType == BrowserType.Chrome)
                Driver = new ChromeDriver();
            else if (browserType == BrowserType.Firefox)
                Driver = new FirefoxDriver();
        }


    }
}
