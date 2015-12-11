namespace MeasureupTests
{
    public struct MyStruct
    {
        public int X { get; private set; }
        public int Y;
        public int Z;

        public MyStruct(int x, int y, int z) : this()
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}