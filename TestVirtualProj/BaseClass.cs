namespace TestVirtualProj
{
    public class BaseClass
    {
        public void DoWork()
        {
        }

        public virtual void DoWorkVirtual()
        {
        }
    }

    public class DerivedClass : BaseClass
    {
        public new virtual void DoWorkVirtual()
        {
            base.DoWorkVirtual();
        }
    }
}