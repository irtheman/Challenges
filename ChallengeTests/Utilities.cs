using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTests
{
    public static class Utilities
    {
        public static int[] GetIntArray(string[] data, ref int index)
        {
            var count = Int32.Parse(data[index++]);
            var items = new int[count];

            for (int i = 0; i < count && index < data.Length; i++)
            {
                items[i] = Int32.Parse(data[index++]);
            }

            return items;
        }
    }
}
