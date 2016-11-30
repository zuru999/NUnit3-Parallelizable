using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace NUnit_3.x.GoogleChromeTest
{
    [TestFixture]
    [Parallelizable]

    public class ChromeTesting : Hooks
    {


        public ChromeTesting() : base(BrowserType.Chrome)
        {

        }



        [Test]
        public void GoogleChromeSearchTest()
        {
            Driver.Navigate().GoToUrl("http://google.pl");
            Driver.FindElement(By.Name("q")).SendKeys("Execute Automation");
            Driver.FindElement(By.Name("btnG")).Click();
            Assert.That(Driver.PageSource.Contains("Execute Automation"), Is.EqualTo(true),
                                                "The text Execute Automation doest not exist");
        }


        [Test]
        public void GoogleChromeDragItemTest()
        {
            Driver.Navigate().GoToUrl("http://demoqa.com/droppable/");

            string xp1 = ".//*[@id='draggableview']";
            IWebElement source = Driver.FindElement(By.XPath(xp1));

            string xp2 = ".//*[@id='droppableview']";
            IWebElement target = Driver.FindElement(By.XPath(xp2));

            Actions action = new Actions(Driver);
            action.DragAndDrop(source, target).Perform();

        }


        [Test]
        public void GoogleChromeResizableElement()
        {
            Driver.Navigate().GoToUrl("http://demoqa.com/resizable/");
            System.Threading.Thread.Sleep(2000);
            string table = ".//*[@id='resizable']/div[3]";
            IWebElement tableResize = Driver.FindElement(By.XPath(table));

            Actions resize = new Actions(Driver);

            //resize.ClickAndHold(tableResize).MoveByOffset(400, 200).Perform();                // tak też będzie dobrze
            //tableResize.Click();

            IAction dragToResize = resize.ClickAndHold(tableResize)
                .MoveToElement(tableResize, 300, 200)
                .Release()
                .Build();
            dragToResize.Perform();


        }


        [Test]
        public void GoogleChromeDragElementAround()
        {
            Driver.Navigate().GoToUrl("http://demoqa.com/draggable/");
            System.Threading.Thread.Sleep(2000);


            IWebElement button = Driver.FindElement(By.Id("draggable"));

            Actions dragAround = new Actions(Driver);

            IAction dragbutton = dragAround.ClickAndHold(button)
                .MoveToElement(button, 300, 500)
                .Release()
                .Build();
            dragbutton.Perform();
        }


        [Test]
        public void GoogleChromeDragItemTestSolution2()
        {
            Driver.Navigate().GoToUrl("http://demoqa.com/droppable/");

            var target = Driver.FindElements(By.XPath(".//*[@id='droppableview']"));   // cel, gdzie ma zostac przeciagniety przycisk 
            var source = Driver.FindElement(By.XPath(".//*[@id='draggableview']"));    //źródło (pryzcisk do przeciagniecia)

            Actions builder = new Actions(Driver);

            IAction dragAndDrop = builder.ClickAndHold(source)
               .MoveToElement(target[0])
               .Release(target[0])
               .Build();

            dragAndDrop.Perform();
        }


        [Test]
        public void GoogleChromeDropToShoppingCard()
        {
            Driver.Navigate().GoToUrl("http://demoqa.com/droppable/");
            Driver.Manage().Window.Maximize();
            Driver.FindElement(By.Id("ui-id-5")).Click();
            System.Threading.Thread.Sleep(1000);

            IWebElement product1 = Driver.FindElement(By.XPath(".//*[@id='ui-id-7']/ul/li[1]"));
            IWebElement product2 = Driver.FindElement(By.XPath(".//*[@id='ui-id-9']/ul/li[2]"));        //Produkty
            IWebElement product3 = Driver.FindElement(By.XPath(".//*[@id='ui-id-11']/ul/li[3]"));


            IWebElement shoppingCard = Driver.FindElement(By.XPath(".//*[@id='cart']/div/ol"));        //Koszyk

            Actions addFirstProductToShoppingCard = new Actions(Driver);
            addFirstProductToShoppingCard.DragAndDrop(product1, shoppingCard).Perform();

            Driver.FindElement(By.Id("ui-id-8")).Click();
            System.Threading.Thread.Sleep(1000);

            Actions addSecondProductToShoppingCard = new Actions(Driver);
            addSecondProductToShoppingCard.DragAndDrop(product2, shoppingCard).Perform();

            Driver.FindElement(By.Id("ui-id-10")).Click();
            System.Threading.Thread.Sleep(1000);

            Actions addThirdProductToShoppingCard = new Actions(Driver);
            addThirdProductToShoppingCard.DragAndDrop(product3, shoppingCard).Perform();


        }


    }
}
