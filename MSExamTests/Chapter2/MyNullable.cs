using System;
using System.Runtime.InteropServices;

namespace MSExamTests.Chapter2
{
    [Serializable, StructLayout(LayoutKind.Sequential)]
    public struct MyNullable<T> where T : struct
    {
        private readonly bool hasValue;
        internal readonly T value;

        public MyNullable(T value)
        {
//            this.value = default(T);
//            hasValue = false;

            this.value = value;
            hasValue = true;
        }

        public bool HasValue
        {
            get { return hasValue; }
        }

        public T Value
        {
            get
            {
                if (!hasValue)
                {
                    throw new InvalidOperationException(
                        "Nullable object must have a value.");
                }
                return value;
            }
        }

        public T GetValueOrDefault()
        {
            return value;
        }

        public T GetValueOrDefault(T defaultValue)
        {
            if (!HasValue) return defaultValue;
            return value;
        }

        public override bool Equals(object other)
        {
            if (!HasValue) return (other == null);
            if (other == null) return false;
            return value.Equals(other);
        }

        public override int GetHashCode()
        {
            if (!HasValue) return 0;
            return value.GetHashCode();
        }

        public override string ToString()
        {
            if (!HasValue) return "";
            return value.ToString();
        }

        public static implicit operator MyNullable<T>(T value)
        {
            return new MyNullable<T>(value);
        }

        public static explicit operator T(MyNullable<T> value)
        {
            return value.Value;
        }
    }
}