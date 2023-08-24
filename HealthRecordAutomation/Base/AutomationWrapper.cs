using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Securiton.Base
{
    public class AutomationWrapper
    {
        protected IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            //driver = new ChromeDriver(@"C:\Users\Balaji_Dinakaran\.cache\selenium\chromedriver\win64\116.0.5845.96");
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "https://demo.openemr.io/b/openemr";
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

    }
}
