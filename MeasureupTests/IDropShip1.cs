using System;
using NUnit.Framework;

namespace MeasureupTests
{
    [ServiceContract]
    public interface IDropShip1
    {
        StatusCode DropShip(DropShipInfo shipInfo, Weapon[] weapons);
    }

    public class DropShipInfo
    {
    }

    public class StatusCode
    {
    }

    public class Weapon
    {
    }

    public class ServiceContractAttribute : Attribute
    {
    }

    [ServiceContract]
    public interface IDropShip2
    {
        StatusCode DropShip(DropShipInfo shipInfo, Weapon[] weapons);
    }

    public class DropshipTester
    {
        public object GetShip()
        {
            return new SentinelShip();
        }

        [Test]
        public void TestChangeType_vs_AsOperator()
        {
            SentinelShip ship = GetShip() as SentinelShip;
            object ship2 = Convert.ChangeType(GetShip(), typeof(SentinelShip));
            var sentinelShip = ship2 as SentinelShip;
        }
    }


    public class SentinelShip : IDropShip1, IDropShip2
    {
        StatusCode IDropShip1.DropShip(DropShipInfo shipInfo, Weapon[] weapons)
        {
            switch (MyEmployee)
            { 
                case EmployeeEnum.Analyst:
                    Console.WriteLine("Analyst");
                    break;
                    case EmployeeEnum.Manager:
                    Console.WriteLine("Manager");
                    goto case EmployeeEnum.Director;
                    case EmployeeEnum.Director:
                    Console.WriteLine("Director");
                    break;
                default:
                    Console.WriteLine("Guest");
                    break;
            }

            return null;
        }

        public EmployeeEnum MyEmployee { get; set; }

        public StatusCode DropShip(DropShipInfo shipInfo, Weapon[] weapons)
        {
            throw new NotImplementedException();
        }
    }

    public enum EmployeeEnum
    {
        Analyst,
        Manager,
        Director
    }
}