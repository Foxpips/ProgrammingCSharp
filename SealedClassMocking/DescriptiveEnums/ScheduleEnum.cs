using System.ComponentModel;

namespace SealedClassMocking.DescriptiveEnums
{
    public enum ScheduleEnum
    {
        [Description("Occurs every day")] Daily,
        [Description("Occurs every week")] Weekly,
        [Description("Occurs every month")] Monthly
    }
}