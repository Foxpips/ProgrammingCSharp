using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace SealedClassMocking.DictionaryTests
{
    public class TryGetDictionaryTests
    {
        private readonly Dictionary<string, string> _dictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            {"Jobseeker", "http://www.welfare.ie/en/Pages/Income-Supports.aspx"},
            {"FarmAssist", "http://www.welfare.ie/en/Pages/1058_Farm-Assist.aspx"},
            {"FishAssist", "http://www.welfare.ie/en/Pages/Fish-Assist_holder.aspx"},
            {"PreRetirement", "http://www.welfare.ie/en/Pages/Pre-Retirement-Allowance-PRETA.aspx"},
            {"PartTimeJobIncentive", "http://www.welfare.ie/en/Pages/Part-Time-Job-Incentive.aspx"},
            {"EducationOrTraining", "http://www.welfare.ie/en/Pages/Courses-for-the-Unemployed.aspx"},
            {"Internship", "http://www.welfare.ie/en/Pages/youth-development-internship.aspx"},
            {"JobBridge", "http://www.welfare.ie/en/Pages/JobBridge-Index.aspx"},
            {"Work Placement", "http://www.welfare.ie/en/pages/work-placement-programme.aspx"},
            {"OFP", "http://www.welfare.ie/en/Pages/278_One-Parent-Family-Payment.aspx"},
            {"BASI", "http://www.welfare.ie/en/Pages/Supplementary-Welfare-Allowance.aspx"}
        };


        [Test]
        public void Method_Scenario_Result()
        {
            string result;
            _dictionary.TryGetValue("EducationorTraining", out result);
            Console.WriteLine(result);
        }
    }
}