using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
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
        IE,
        Opera
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
            //Driver.Manage().Window.Maximize();
        }

        private void ChooseDriverInstance(BrowserType browserType)
        {
            if (browserType == BrowserType.Chrome)
                Driver = new ChromeDriver();
            else if (browserType == BrowserType.Firefox)
                Driver = new FirefoxDriver();
            else if (browserType == BrowserType.IE)
                Driver = new InternetExplorerDriver();
            else if (browserType == BrowserType.Opera)
                Driver = new OperaDriver();
        }


    }
}
