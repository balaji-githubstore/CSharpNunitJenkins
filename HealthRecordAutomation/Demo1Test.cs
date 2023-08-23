using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.HealthRecordAutomation
{
    /// <summary>
    /// Will be deleted - not part of the framework
    /// 
    /// </summary>
    public class Demo1Test
    {

        public static object[] LoginData()
        {
            object[] data1 = new object[2];
            data1[0] = "saul";
            data1[1] = "saul123";

            object[] data2=new object[2];
            data2[0] = "peter";
            data2[1] = "peter123";

            object[] data3=new object[2];
            data3[0] = "kim";
            data3[1] = "kim122";

            object[] allData=new object[3]; //number of test case
            allData[0] = data1;
            allData[1] = data2;
            allData[2] = data3;

            return allData;
        }

        [Test,TestCaseSource(nameof(LoginData))]
        public void LoginTest(string user,string password)
        {
            Console.WriteLine(user+password);
        }

        [Test]
        public void ReadJson()
        {
            StreamReader reader = new StreamReader("C:\\Mine\\Company\\Securiton\\HealthRecordAutomationSln\\HealthRecordAutomation\\TestData\\data.json");
            dynamic? json = JsonConvert.DeserializeObject(reader.ReadToEnd());
            Console.WriteLine(json?["validData"]);
            Console.WriteLine(json?["validData"][0][0]);
            Console.WriteLine(json?["validData"].Count);

            object[] allData = new object[json?["validData"].Count];

            for (int i = 0; i < json?["validData"].Count; i++)
            {
                object[] data = new object[json?["validData"][i].Count];

                for (int j = 0; j < json?["validData"][i].Count; j++)
                {
                    data[j] = json["validData"][i][j];
                }
                allData[i] = data;
            }

            Console.WriteLine(allData);
        }

        [Test]
        public void ExRep()
        {
            var extent = new ExtentReports();
            var spark = new ExtentHtmlReporter("Spark.html");
            extent.AttachReporter(spark);
            ExtentTest test = extent.CreateTest("MyFirstTest");
            test.Log(Status.Pass, "This is a logging event for MyFirstTest, and it passed!");
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://google.com";
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            test.AddScreenCaptureFromBase64String(ts.GetScreenshot().AsBase64EncodedString);
            extent.Flush();

            
        }
    }
}






