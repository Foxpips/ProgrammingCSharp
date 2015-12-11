using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace ProgrammingTests.Tuple
{


    interface IRepository<out T> where T : class
    {
        T FindById(int id);
        IEnumerable<string> All();
    }

    public class Repository : IRepository<string>{
        public string FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> All()
        {
            throw new NotImplementedException();
        }
    }


    public class Movement : ILeft, IRight
    {
        public string Name { get; protected set; }

        private string _name;

        protected void SetName(string value)
        {
            _name = value;
        }

        public string GetName()
        {
            return _name;
        }
        
        public void Move()
        {
            Console.WriteLine("Move Left");
        }

        void IRight.Move()
        {
            Console.WriteLine("Move Right");
        }

        void ILeft.Move()
        {
            Console.WriteLine("Move Left as Interface");
        }
    }

    public class TestMovement
    {
        [Test]
        public void Method_Scenario_Result()
        {
            Movement movement = new Movement();

            ((ILeft)movement).Move();
        }
    }


    internal interface ILeft
    {
        void Move();
    }

    internal interface IRight
    {
        void Move();
    }
}