using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using NUnit.Framework;
using AutomationLibrary;


namespace Automate_Webpage.Testcases
{
    
    

        [TestFixture]
        class Automatewebpage:BaseWebTest
        {
            [TestCase(TestName ="LoginToGmailAccount")]
            [Category ("login")]
            [Category("hitUrl")]
            public void LoginToGmail()
            {
            Login("http://www.gmail.com","","");

            //if (driver.FindElement(By.Id
            //  ("identifierId")).SendKeys("harry040687@gmail.com"));
            // {
            //     Console.WriteLine("test passed");
            // }
            driver.FindElement(By.Id("identifierId")).SendKeys("harry040687@gmail.com");
           // driver.FindElement(By.XPath(".//*[@id='identifierNext']/div[2]")).Click();
            driver.FindElement(By.Id("identifierNext")).Click();
           // driver.FindElement(By.ClassName("whsOnd zHQkBf")).SendKeys("Adsemail");

            //driver.FindElement(By.Id("identifierId")).Click();

            driver.FindElement(By.ClassName("whsOndzHQkBf")).SendKeys("Adsemail");

            // driver.FindElement(By.CssSelector("password > div.aCsJod.oJeWuf > div > div.Xb9hP > input")).SendKeys("Adsemail");
            Console.WriteLine("password paseed");
            

           // driver.FindElement(By.Id("passwordNext")).Click();
            //Console.WriteLine("Login passed");
           

            }

        [TestCase(TestName = "LoginToAmazonAccount")]
        [Category("personal")]
        public void LoginToAmazon()
        {
            Login("http://www.amazon.com", "", "");

            if (driver.FindElement(By.Id
                ("nav-link-accountList")).Displayed)
            {
                Console.WriteLine("test passed");
            }

            Console.WriteLine("");
            Console.WriteLine("");

        }
    }
    
}
