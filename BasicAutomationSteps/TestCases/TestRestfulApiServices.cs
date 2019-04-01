using AutomationSelfProject.Utilities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicAutomationSteps.TestCases
{
    class TestRestfulApiServices
    {
        RestServicesGetUtility RestServicesGetUtilityInstance = new RestServicesGetUtility();
        /// <summary>
        /// Refernce : https://restful-booker.herokuapp.com/apidoc/index.html
        /// https://restful-booker.herokuapp.com/
        /// https://www.ultimateqa.com/dummy-automation-websites/
        /// https://www.techbeamers.com/websites-to-practice-selenium-webdriver-online/
        /// </summary>
        public void GetPlayGround()
        {
            StringBuilder RestServiceUrl = new StringBuilder(@"https://restful-booker.herokuapp.com/booking");
            //[{"bookingid":1},{"bookingid":2},{"bookingid":7},{"bookingid":8},{"bookingid":10},{"bookingid":4},{"bookingid":5},{"bookingid":3},{"bookingid":9},{"bookingid":6}]
            JObject r = RestServicesGetUtilityInstance.GetRequest(RestServiceUrl.ToString());


        }
    }
}
