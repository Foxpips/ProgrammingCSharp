using System;

namespace SealedClassMocking.Generics
{
    public interface IPerson<out TType> where TType : Adult, new()
    {
        TType Vote();
    }

    public interface ITransport
    {
        void TravelToVotingStation<TTransportType>(TTransportType type)
            where TTransportType : ITransport;
    }

    public class SouthSider : IPerson<Dubliner>
    {
        public Dubliner Vote()
        {
            return new Dubliner(true, typeof (Bus));
        }
    }

    public class Bus : ITransport
    {
        public void TravelToVotingStation<TTransportType>(TTransportType type) where TTransportType : ITransport
        {
            Console.WriteLine("Hop on 46a");
        }
    }


    public class Dubliner : Adult
    {
        protected internal ITransport Transport { get; set; }
        protected internal bool WillVote { get; set; }

        public Dubliner(bool willVote, Type transport)
        {
            Transport = Activator.CreateInstance(transport) as ITransport;
            WillVote = willVote;
        }

        public Dubliner()
        {
            throw new NotImplementedException();
        }
    }

    public abstract class Adult
    {
    }

    public class TestGenerics<T> where T : new()
    {
    }
}