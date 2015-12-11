using System;
using NUnit.Framework;

namespace MeasureupTests
{
    public class CastingExceptions
    {
        /// <summary>
        /// Gets Food
        /// </summary>
        /// <exception cref="System.NullReferenceException"></exception>
        public void Method_Scenario_Result()
        {
            var pizzaAs = GetFood() as Spaghetti;
           if(pizzaAs == null)throw new NullReferenceException();


            var pizzaExplicitCast = (Spaghetti)GetFood();

            Assert.NotNull(pizzaAs);
            Assert.NotNull(pizzaExplicitCast);
        }

        public void Do()
        {
            try
            {
                Method_Scenario_Result();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public object GetFood()
        {
            return new Pizza();
        }
    }

    public class Pizza
    {
    }

    public class Spaghetti
    {
        
    }
}