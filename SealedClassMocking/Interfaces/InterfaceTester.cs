using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using NUnit.Framework;

namespace SealedClassMocking.Interfaces
{
    public class TestINonsense
    {
        [Test]
        public void Method_Scenario_Result()
        {
            var orderRepository = new OrderRepository(new List<Order> {new Order(10), new Order(13), new Order(8)});

            orderRepository.FilterOrdersOnAmount().Each(x => Console.WriteLine(x.Id));
            Assert.Throws<NullReferenceException>(() => Console.WriteLine(orderRepository.FindById(11).Id));
            Assert.That(() => orderRepository.FindById(10).Id, Is.EqualTo(10));
        }
    }

    internal interface IEntity
    {
        int Id { get; }
    }

    internal class Repository<T> where T : IEntity
    {
        protected IEnumerable<T> Elements;

        public Repository(IEnumerable<T> elements)
        {
            Elements = elements;
        }

        public T FindById(int id)
        {
            return Elements.SingleOrDefault(e => e.Id == id);
        }
    }

    internal class Order : IEntity
    {

        public string S { get; protected internal set; }

        private readonly int _id;

        public Order(int id)
        {
            _id = id;
        }

        public int Id
        {
            get { return _id; }
        }
    }

    internal class OrderRepository : Repository<Order>
    {
        public OrderRepository(IEnumerable<Order> orders)
            : base(orders)
        {
        }

        public IEnumerable<Order> FilterOrdersOnAmount()
        {
            return Elements.OrderBy(x => x.Id);
        }
    }
}