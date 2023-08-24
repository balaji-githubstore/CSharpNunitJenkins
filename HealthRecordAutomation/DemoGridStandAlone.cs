using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoHealthRecordAutomation
{
    [Parallelizable(ParallelScope.All)]
    public class DemoGridStandAlone
    {
        [Test]
        public void Grid1Test()
        {
            ChromeOptions options = new ChromeOptions();    
            var driver=new RemoteWebDriver(new Uri("http://192.168.202.202:4444"), options);
            driver.Url = "http://google.com";
            Console.WriteLine(driver.Title);
            Thread.Sleep(5000);
            driver.Quit();
        }

        [Test]
        public void Grid2Test()
        {
            ChromeOptions options = new ChromeOptions();
            var driver = new RemoteWebDriver(new Uri("http://192.168.202.202:4444"), options);
            driver.Url = "http://google.com";
            Console.WriteLine(driver.Title);
            Thread.Sleep(5000);
            driver.Quit();
        }
    }
}
