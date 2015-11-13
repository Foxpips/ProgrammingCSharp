using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using SealedClassMocking.StringConcatenationProfiling;

namespace SealedClassMocking.StringConcatenationTests
{
    public class TabDelimitedFormatter : IOutputFormatter<string>
    {
        private readonly Func<int, char> _suffix = col => col % 2 == 0 ? '\n' : '\t';

        public string GetOutputConcat(IEnumerator<string> iterator, int recordSize)
        {
            string output = null;
            for (int i = 0; iterator.MoveNext(); i++)
            {
                output = string.Concat(output, iterator.Current, _suffix(i));
            }
            return output;
        }

        public string GetOutputBuilder(IEnumerator<string> iterator, int recordSize)
        {
            var output = new StringBuilder();
            for (int i = 0; iterator.MoveNext(); i++)
            {
                output.Append(iterator.Current);
                output.Append(_suffix(i));
            }
            return output.ToString();
        }
    }

    public interface IOutputFormatter<in T>
    {
        string GetOutputConcat(IEnumerator<T> iterator, int recordSize);
        string GetOutputBuilder(IEnumerator<T> iterator, int recordSize);
    }

    public class BuilderVsConcat
    {
        [Test]
        public void builder_concat_speedtest()
        {
            var tabDelimitedFormatter = new TabDelimitedFormatter();
            Timer.Time(
                () =>
                {
                    tabDelimitedFormatter.GetOutputBuilder(
                        new List<string> { "one", "two", "three", "four", "five" }.GetEnumerator(), 10);
                }, "Concat");

            Timer.Time(
                () =>
                {
                    tabDelimitedFormatter.GetOutputConcat(
                        new List<string> { "one", "two", "three", "four", "five" }.GetEnumerator(), 10);
                }, "Builder");
        }
    }
}