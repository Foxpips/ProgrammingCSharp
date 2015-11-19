using System.ComponentModel;

namespace ProgrammingTests.TimeSpanTests
{
    public enum TimeSpan
    {
        [Description("None")]
        Daily,
        [Description("Each Week")]
        Weekly,
        [Description("Every Month")]
        Monthly
    }
}