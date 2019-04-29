using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BasicAutomationSteps.TestCases
{
    /// <summary>
    /// Enum Implementation
    /// Include System.ComponentModel
    /// </summary>
    public static enum StatusDescription
    {
        [Description("Active")]
        Active,
        [Description("Never Enrolled")]
        Empty
    }

    public static class hi
    {
        StatusDescription.active;

    }
}
