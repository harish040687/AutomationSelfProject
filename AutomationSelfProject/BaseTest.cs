using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationLibrary
{
    public enum StatusEnum { Pass,Fail,Info,Warn,Debug,Error}
    public class BaseTest
    {
        public ExtentReports Report;
        public ExtentHtmlReporter HtmlReporter;
        public string ReportFilePath;
        public StringBuilder VerificationErrors;
        public ExtentTest Test;

        public ExtentTest CurrentTest;
        public static ExtentTest sCurrentTest;
        public static string TestCaseStepName;
        public static string TestEnvironment;

        // Get Project and ProjectEnvironment from Nunit console parameters
        public static string Project = TestContext.Parameters["Project"];
        public static string ProjectEnvironment = TestContext.Parameters["ProjectEnvironment"];
        public static string ReportName = TestContext.Parameters["ReportName"];

        public static string CurrentMachineName = Environment.MachineName; //System.Environment.GetEnvironmentVariable("COMPUTERNAME");

        public static readonly string KDriveArchiveShareFolderPath = @"\\corporate.administaff.com\ASFShares\share";  //Later provide servers path when its ready
        public static readonly string dirReports = @"reports";
        public static readonly string AutReportsSubDirectoryName = @"AUTREPORTS";
        public string archivepath = Path.Combine(KDriveArchiveShareFolderPath, AutReportsSubDirectoryName, "");

        public readonly List<string> AutomationServerNames = new List<string> { "cnu3109bmq", "CNU3109BMQ", "5CG725344X", "5cg725344x", "5CG5454YZH", "5cg5454yzh", "5cg8433y50", "5CG8433Y50", "5CG6393W4S" };  //"5CG6393W4S"
        //ConfigurationManager.AppSettings["AutomationServerNames"].Split(',').ToList();

        public string TcConfigID
        {
            get { return TcConfigID; }
            set { TcConfigID = value; }
        }

        //

        // Dates and create random 
        public static string todayMmddyyyy = String.Empty;
        public static string tomorrowMmddyyyy = String.Empty;
        public static string yesterdayMmddyyyy = String.Empty;
        public static string nowYyyymmddhhmmss = String.Empty;
        public static string nowMmddyyyhhmmss = String.Empty;
        public Random rnd = new Random();
        public static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        [OneTimeSetUp]
        public virtual void TestSetup()
        {
            // Set up reporting
            Report = new ExtentReports();

            if (AutomationServerNames.Any(CurrentMachineName.Substring(4).Contains))
            {

                ReportFilePath = String.IsNullOrEmpty(ReportName) ? archivepath + "\\" + TestContext.CurrentContext.Test.Name +
                                                                    "_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".html" : archivepath + "\\" + ReportName + ".html";
            }
            else
            {
                ReportFilePath = String.IsNullOrEmpty(ReportName) ? TestContext.CurrentContext.TestDirectory + "\\" + TestContext.CurrentContext.Test.Name +
                                                                    "_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".html" : TestContext.CurrentContext.TestDirectory + "\\" + ReportName + ".html";
            }

            HtmlReporter = new ExtentHtmlReporter(ReportFilePath);
            //TODO: AppendExisting property does not do anything... not implemented in C# version of ExtentReports. 
            //May become a problem if we want to execute all tests and not just a category because it will overwrite the same report
            HtmlReporter.AppendExisting = true;
            Report.AttachReporter(HtmlReporter);
            Report.AddSystemInfo("Project", Project ?? TestContext.CurrentContext.Test.ClassName);
            Report.AddSystemInfo("Environment", ProjectEnvironment);
            Report.AddSystemInfo("Autobot", CurrentMachineName);
            Report.AddSystemInfo("Report file path", ReportFilePath);

            // Set global variables
            Globals();
        }

        [SetUp]
        public virtual void BeforeTest()
        {
            // Set up reporting for current test
            sCurrentTest = CreateTest(TestContext.CurrentContext.Test.Name);
            CurrentTest = sCurrentTest;
        }

        [OneTimeTearDown]
        public void AfterTests()
        {
            // Flush the report
            Report.Flush();
        }

        [TearDown]
        public virtual void AfterEachTest()
        {
            // Reporting results
            GetResults();
        }

        /// <summary>
        /// Log status in report
        /// </summary>
        /// <param name="status">Status to be logged</param>
        /// <param name="message">Details about the status</param>
        public void Log(StatusEnum status, string message)
        {
            switch (status)
            {
                case StatusEnum.Pass:
                    CurrentTest.Pass(message);
                    break;
                case StatusEnum.Fail:
                    CurrentTest.Fail(message);
                    break;
                case StatusEnum.Info:
                    CurrentTest.Info(message);
                    break;
                case StatusEnum.Warn:
                    CurrentTest.Warning(message);
                    break;
                case StatusEnum.Debug:
                    CurrentTest.Debug(message);
                    break;
                case StatusEnum.Error:
                    CurrentTest.Error(message);
                    break;
                default:
                    throw new InvalidEnumArgumentException($"Unsupported enum value: {status}.");
            }
        }

        // Reporting results
        public void GetResults()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = String.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : $"{TestContext.CurrentContext.Result.StackTrace}";
            Status logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }

            Test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
        }

        // Create the test in reporting
        public ExtentTest CreateTest(string testName)
        {
            Test = Report.CreateTest(testName);
            return Test;
        }

        // Set global variables
        public static void Globals()
        {
            var today = DateTime.Now;
            var tomorrow = today.AddDays(1);
            var yesterday = today.AddDays(-1);
            todayMmddyyyy = today.ToString("MM/dd/yyyy");
            tomorrowMmddyyyy = tomorrow.ToString("MM/dd/yyyy");
            yesterdayMmddyyyy = yesterday.ToString("MM/dd/yyyy");
            nowYyyymmddhhmmss = today.ToString("yyyyMMddHHmmss");
            nowMmddyyyhhmmss = today.ToString("MM'/'dd'/'yyyy HH':'mm':'ss");
            Random rnd = new Random();
        }

    }
}
