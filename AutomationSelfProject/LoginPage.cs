using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationLibrary
{
    public class LoginPage:BaseWebTest
    {
        public static void GoTo(string Url)
        {
            driver.Navigate().GoToUrl(Url);
        }
    }
}
