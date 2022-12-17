using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTests
{
    public class Results<T,R>
    {
        public Results(T items, R expected)
        {
            Items = items;
            Expected = expected;
        }

        public T Items { get; }
        public R Expected { get; }
    }

    public class Results2<T, P, R> : Results<T, R>
    {
        public Results2(T items, P parms, R expected) : base(items, expected)
        {
            Params = parms;
        }

        public P Params { get; }
    }
}
