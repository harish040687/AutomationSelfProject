using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicAutomationSteps.TestCases;
namespace BasicAutomationSteps
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sample Testing Project  --");
            TestRestfulApiServices t = new TestRestfulApiServices();
            t.GetPlayGround();

        }
    }
}
