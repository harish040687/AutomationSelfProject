using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicAutomationSteps.Enums;

using Nunit.Framework;
using System.Collections;

namespace BasicAutomationSteps.TestCases
{
    public static class TestDataSource
    {
        public static IEnumerable TestSources
        {
            get
            {
                yield return new TestCaseData(StatusDescription);
            }
        }
    }
}
