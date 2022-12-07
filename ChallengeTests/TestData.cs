using System;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using Xunit.Sdk;

namespace ChallengeTests
{
    public class TestData : DataAttribute
    {
        private static Dictionary<string, string[]> _test = new Dictionary<string, string[]>();
        private string _tests;

        public TestData(string tests)
        {
            _tests = tests;
            if (_test.Count > 0) return;

            var dir = new DirectoryInfo(@".\TestData");
            foreach (var f in dir.EnumerateFiles(@"*.txt", SearchOption.TopDirectoryOnly))
            {
                var name = f.Name.Replace(@".txt", "");
                using var stream = f.OpenText();
                var text = stream.ReadToEnd();
                var lines = text.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
                var clean = lines.Select(l => l.Trim()).ToArray();
                _test.Add(name, lines);
            }
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            if (testMethod == null) { throw new ArgumentNullException(nameof(testMethod)); }

            var ret = new List<object[]>();
            var tests = _tests.Split(',', StringSplitOptions.TrimEntries);

            foreach (var test in tests)
            {
                if (string.IsNullOrWhiteSpace(test)) continue;

                if (_test.TryGetValue(test, out var data))
                {
                    ret.Add(new object[] { data });
                }
            }

            return ret;
        }
    }
}
