using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using Xunit.Sdk;

namespace ChallengeTests
{
    public class TestData : DataAttribute
    {
        private static Dictionary<string, string[]> _test = new Dictionary<string, string[]>();
        private const string _dir = @".\TestData\";
        private string _tests;

        public TestData(string tests, bool reload = false)
        {
            if (_tests == tests && !reload) return;

            if (!Directory.Exists(_dir))
            {
                throw new DirectoryNotFoundException(_dir);
            }

            _tests = tests;

            var names = _tests.Split(',', StringSplitOptions.TrimEntries);

            foreach (var name in names)
            {
                var isThere = _test.ContainsKey(name);

                if (reload && isThere)
                {
                    _test.Remove(name);
                    isThere = false;
                }

                if (!isThere)
                {
                    var file = $"{_dir}{name}.txt";
                    if (!File.Exists(file))
                    {
                        throw new FileNotFoundException(file);
                    }

                    using var stream = File.OpenText(file);
                    var text = stream.ReadToEnd();
                    var lines = text.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
                    var clean = lines.Select(l => l.Trim()).Where(w => !w.StartsWith('!')).ToArray();

                    _test.Add(name, clean);
                }
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
                    if (data.Length == 0) continue;

                    int start = 0, length = 0;
                    int index = 0;

                    while (index > -1 && start < data.Length)
                    {

                        index = Array.IndexOf(data, "~", start);
                        if (index == -1)
                        {
                            length = data.Length - start;
                        }
                        else
                        {
                            length = index - start;
                        }

                        string[] subArray = new string[length];
                        Array.Copy(data, start, subArray, 0, subArray.Length);
                        start = index + 1;

                        ret.Add(new object[] { subArray });
                    }
                }
            }

            return ret;
        }
    }
}
