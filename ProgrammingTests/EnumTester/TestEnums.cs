using System;
using System.Linq;
using NUnit.Framework;

namespace ProgrammingTests.EnumTester
{
    public class TestEnums
    {
        [Flags]
        private enum MenuType
        {
            CloseClaim,
            Holiday,
            ApplyFor,
            ReviewDocuments
        }

        [Test]
        public void Method_Enum_ToString()
        {
            const MenuType k = MenuType.CloseClaim;
            if (k.ToString().Equals("CloseClaim"))
            {
                Console.WriteLine(k);
            }
        }

        [Test]
        public void Test_Enum_XorFlags()
        {
            MenuType menu = MenuType.CloseClaim;


            if (menu.IsIn(MenuType.CloseClaim, MenuType.Holiday))
            {
#if !DEBUG
                Console.WriteLine(menu.ToString());
#endif
            }
        }
    }

    public static class Extensions
    {
        public static bool IsIn(this object item, params Enum[] myEnum)
        {
            return myEnum.Any(item.Equals);
        }
    }
}