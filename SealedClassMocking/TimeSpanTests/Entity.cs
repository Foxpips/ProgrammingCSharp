using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealedClassMocking
{
    public interface IEntity
    {
        string GetCredentials();
    }

    public abstract class Entity : IEntity
    {
        public abstract string GetCredentials();
    }


    public sealed class Person : Entity
    {
        public override string GetCredentials()
        {
            return "Simon";
        }
    }
}