using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Securiton.Base;
using OpenQA.Selenium.Support.UI;
using Securiton.HealthRecordAutomation.Utilities;
using Securiton.HealthRecordAutomation.Pages;
using HealthRecordAutomation.Pages;

namespace Securiton.HealthRecordAutomation
{
    public class LoginTest : AutomationWrapper
    {
        
        [Test,TestCaseSource(typeof(DataSource),nameof(DataSource.ValidLoginData))]
        //[TestCase("admin","pass","English (Indian)","OpenEMR")]
        //[TestCase("accountant", "accountant", "English (Indian)", "OpenEMR")]
        public void ValidLoginTest(string username,string password,string language,string expectedTitle)
        {
            LoginPage loginPage = new LoginPage(driver);

            loginPage.EnterUsername(username);
            loginPage.EnterPassword(password);
            loginPage.SelectLanaguageByText(language);
            loginPage.ClickOnLogin();

            //wait for page load to complete 
            MainPage mainPage=new MainPage(driver);
            Assert.That(mainPage.MainPageTitle, Is.EqualTo(expectedTitle));
        }

        [Test]
        public void InvalidLoginTest()
        {
            LoginPage loginPage = new LoginPage(driver);

            loginPage.EnterUsername("john");
            loginPage.EnterPassword("john123");
            loginPage.SelectLanaguageByText("English (Indian)");
            loginPage.ClickOnLogin();

            string actualError= loginPage.GetInvalidErrorMessage();

            //assert the error Invalid username or password
            Assert.True(actualError.Contains("Invalid username"),
                "Assertion on Error message - actual error: "+actualError);
        }

    }
}
