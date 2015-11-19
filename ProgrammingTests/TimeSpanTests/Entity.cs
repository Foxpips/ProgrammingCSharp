namespace ProgrammingTests.TimeSpanTests
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