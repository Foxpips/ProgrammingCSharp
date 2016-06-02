using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace ProgrammingTests
{
    public class FileUpdater
    {
        [Test]
        public void Method_Scenario_Result()
        {
            const string path = @"C:\Users\SimonMarkey\Desktop\Finished.txt";
            const string path2 = @"C:\Users\SimonMarkey\Desktop\irish.txt";
            const string path3 = @"C:\Users\SimonMarkey\Desktop\countryDataNew.txt";

            string sqlInsert = "INSERT [dbo].[refdata] ([data_id], [code], [title], [culture], [reftype]) VALUES";
            string GO = "GO";

            var old = File.ReadAllLines(path3, Encoding.Default);
            var translated = File.ReadAllLines(path2, Encoding.Default);
            int count = 0;


            var stringBuilder = new StringBuilder();

            foreach (var s in old)
            {
                var startIndex = s.IndexOf(",N'", StringComparison.Ordinal);
                var endIndex = s.IndexOf(",N'g", StringComparison.Ordinal);

                var length = endIndex - startIndex;

                string output = s.Substring(startIndex, length);

                stringBuilder.AppendLine(sqlInsert + s.Replace(output, ",N'" + translated[count] + "'"));

                count++;
            }

            var format = stringBuilder.ToString();
            Console.WriteLine(format);

            File.WriteAllText(path, format);
        }

        [Test]
        public void MergeFiles_Scenario_Result()
        {
            const string pathIrish = @"C:\Users\SimonMarkey\Desktop\Finished.txt";
            const string pathEng = @"C:\Users\SimonMarkey\Desktop\English.txt";
            const string pathEngFinished = @"C:\Users\SimonMarkey\Desktop\FinishedEnglish.txt";

            var irish = File.ReadAllLines(pathIrish, Encoding.Default);
            var eng = File.ReadAllLines(pathEng, Encoding.Default);
            var list = new List<string>();

            var stringBuilder = new StringBuilder();

            foreach (var s in eng)
            {
                if (s.Contains("en-IE"))
                {
                    stringBuilder.AppendLine(s);
                }
            }

            File.WriteAllText(pathEngFinished, stringBuilder.ToString());
        }


        [Test]
        public void sdasdas()
        {
            var timeSpan = default(TimeSpan);
        }

        [Test]
        public void MergeFilesFully_Scenario_Result()
        {
            const string pathIrish = @"C:\Users\SimonMarkey\Desktop\Finished.txt";
            const string pathEng = @"C:\Users\SimonMarkey\Desktop\English.txt";
            const string pathEngFinished = @"C:\Users\SimonMarkey\Desktop\FinishedEnglish.txt";
            const string Complete = @"C:\Users\SimonMarkey\Desktop\Complete.txt";

            var irish = File.ReadAllLines(pathIrish, Encoding.Default);
            var eng = File.ReadAllLines(pathEngFinished, Encoding.Default);

            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("TRUNCATE TABLE [dbo].[refdata]");
            stringBuilder.AppendLine("GO");

            for (int i = 0; i < eng.Length; i++)
            {
                stringBuilder.AppendLine(eng[i]);
                stringBuilder.AppendLine("GO");
                stringBuilder.AppendLine(irish[i]);
                stringBuilder.AppendLine("GO");
            }

            File.WriteAllText(Complete,stringBuilder.ToString(),Encoding.Default);
        }
    }
}