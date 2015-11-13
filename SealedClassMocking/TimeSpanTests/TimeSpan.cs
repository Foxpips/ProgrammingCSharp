using System.ComponentModel;

namespace SealedClassMocking.TimeSpanTests
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