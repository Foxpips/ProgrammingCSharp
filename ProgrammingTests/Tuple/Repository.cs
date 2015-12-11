using System;
using System.Collections.Generic;
using System.Linq;
using ProgrammingTests.Interfaces;

namespace ProgrammingTests.Tuple
{
    internal interface IEntity
    {
        int Id { get; }
    }

    internal abstract class BaseRepository<T> where T : IEntity
    {
        protected IEnumerable<T> _elements;

        protected BaseRepository(IEnumerable<T> elements)
        {
            _elements = elements;
        }

        public virtual T FindById(int id)
        {
            return _elements.SingleOrDefault(e => e.Id == id);
        }
    }

    internal class OrderRepository : BaseRepository<Order>
    {
        private readonly List<Order> _orders;

        public OrderRepository(List<Order> orders) : base(orders)
        {
            _orders = orders;
        }

        public override Order FindById(int id)
        {
            Console.WriteLine("Id" + id);
            return base.FindById(id);
        }

        public IEnumerable<Order> FilterOrdersOnAmount(decimal amount)
        {
            return _orders;
        }
    }
}