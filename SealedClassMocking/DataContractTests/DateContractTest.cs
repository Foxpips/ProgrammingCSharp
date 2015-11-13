using System.Runtime.Serialization;
using NUnit.Framework;

namespace SealedClassMocking.DataContractTests
{
    [DataContract(IsReference = true,Name = "tests",Namespace = "www.namespace.ie")]
    public class DateContractTest
    {
        [Test]
        public void ContractTests_Scenario_Result()
        {
            
        } 
    }
}