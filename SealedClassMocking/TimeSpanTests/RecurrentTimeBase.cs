using System.Collections.Generic;

namespace SealedClassMocking.TimeSpanTests
{
    public abstract class RecurrentTimeBase
    {
        protected Dictionary<TimeSpan, string> Descriptions { get; set; }
    }
}