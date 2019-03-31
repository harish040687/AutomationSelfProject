using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Diagnostics;
using AventStack.ExtentReports.Utils;

namespace AutomationSelfProject.Utilities
{
    class HelperForApiThirdPartyExe
    {

        public static string RanorexAutomationRootPath = ""; // ConfigurationManager.AppSettings["RanorexAutomationRootPath"];
        public static List<string> AutomationServerNames = new List<string>() {"server1",
        "server2"};// ConfigurationManager.AppSettings["AutomationServerNames"].Split(',').ToList();

        public static string ExecutablePath = @"bin\Debug\";
        /// <summary>
        /// This class is to Help the Integration piece between Selenium & Ranorex. i.e if you like to start Ranorex script
        /// from Selenium and capture the output in to
        /// your Selenium report, then you can call this Method.
        /// </summary>
        /// <param name="ReportInstance"></param>
        /// <param name="DataPathWithName"></param>
        /// <param name="RanorexExecutableName">"C:\\Automation\\AimsApi.exe"</param>
        /// <param name="SuiteName">"AimsApi.rxtst"</param>
        /// <param name="RunConfig"></param>
        /// <param name="Arguments">"/runconfig:EmpGeneratorAPI /pa:CmdLineArgsDataFilePath= /rf:AimsApi15_14_49_PM.rxlog /pa:CmdLineArgsEnvironment=test /tcpa:AimsEmployeeAddByRecordsApi /ts:C:\\Automation\\AimsApi.rxtst"</param>
        /// <returns></returns>
        public static string LaunchAnRanorexScript(Object ReportInstance, string DataPathWithName, string RanorexExecutableName, string SuiteName, string RunConfig = "0", string Arguments = "")
        {

            if (RanorexExecutableName.IsNullOrEmpty() || DataPathWithName.IsNullOrEmpty() || SuiteName.IsNullOrEmpty())
            {

                //RanorexExecutableName = "AimsCompanyEmployeeSetupTest.exe";
                //RanorexAutomationRootPath + ExecutablePath + RanorexExecutableName
                throw new Exception("LaunchAnRanorexScript  : Null argument name passed in 'RanorexExecutableName' :" + RanorexExecutableName +
                                    "'DataPathWithName'->" + DataPathWithName + "'SuiteName'->" + SuiteName);
            }

            if (AutomationServerNames.Any(Environment.MachineName.Substring(4).Contains))
            {

            }

            Process process = new Process();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.FileName = RanorexExecutableName;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.Arguments = Arguments;

            process.Start();
            process.WaitForExit();

            var testResult = process;
            string returnStr = process.StandardOutput.ReadToEnd() + " %% " + process.ExitCode.ToString();
            //myProcess1.HasExited
            //myProcess1.ExitCode
            Console.WriteLine(returnStr);


            return returnStr;
        }
    }

}
