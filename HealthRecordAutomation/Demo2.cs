using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Securiton.HealthRecordAutomation.Pages;
using OpenQA.Selenium.Edge;

namespace HealthRecordAutomation
{
    [Parallelizable(scope:ParallelScope.Fixtures)]
    [TestFixture("ch")]
    [TestFixture("edge")]
    [Category("AA")]
    public class Demo2
    {
        protected IWebDriver driver;
        string browser = "";
        public Demo2(string browser)
        {
            this.browser = browser;
        }

        [SetUp]
        public void Setup()
        {
            if(browser.Equals("ch"))
            {
                //driver=new ChromeDriver();
                driver = new ChromeDriver(@"C:\Users\Balaji_Dinakaran\.cache\selenium\chromedriver\win64\116.0.5845.96");
            }
            else
            {
                //driver = new ChromeDriver();
                driver = new EdgeDriver(@"C:\Users\Balaji_Dinakaran\.cache\selenium\msedgedriver\win64\116.0.1938.54");
            }
            
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "https://demo.openemr.io/b/openemr";
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void T1()
        {
            LoginPage loginPage = new LoginPage(driver);

            loginPage.EnterUsername("john");
            loginPage.EnterPassword("john123");
            loginPage.SelectLanaguageByText("English (Indian)");
            loginPage.ClickOnLogin();
        }

        [Test]
        public void T2()
        {
            LoginPage loginPage = new LoginPage(driver);

            loginPage.EnterUsername("john");
            loginPage.EnterPassword("john123");
            loginPage.SelectLanaguageByText("English (Indian)");
            loginPage.ClickOnLogin();
        }
    }
}
