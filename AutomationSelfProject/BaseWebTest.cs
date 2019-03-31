using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace AutomationLibrary
{
    
    public class BaseWebTest
    {

        public static string browserType { get; set; }

        public static IWebDriver driver { get; set;  }

        string Username = "";
        string Password = "";
       

        public void Login(string Url,string Username,string Password)
        {
            driver.Navigate().GoToUrl(Url);
        }

       
        public new void TestSetup()
        {

        }
        [SetUp]
        public void BeforeTest()
        {
            StartBrowser("chrome");
        }
        [TearDown]
        public void AfterEachTest()
        {
            driver.Quit();
        }

        public void StartBrowser (string browserType, bool maximize = true)
        {
            switch(browserType.ToLower())
            {
                case "chrome":
                    driver = new ChromeDriver();
                    break;


                default:
                    driver = new ChromeDriver();
                    break;
            }
        }


    }
}
