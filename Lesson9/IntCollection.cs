using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson9
{
    public class IntCollection : CustomCollection<int>
    {
        public IntCollection() {}

        public IntCollection(int capacity) : base(capacity) {}

        public IntCollection(int[] elements) : base(elements){}

        public IntCollection(IEnumerable<int> elements) : base(elements) {}


        public static IntCollection operator+(IntCollection a, IntCollection b)
        {
            var r = new IntCollection(Math.Max(a.Count, b.Count));
            var smaller = (a.Count < b.Count ? a : b);
            var bigger = (a.Count < b.Count ? b : a);
            r.Count = bigger.Count;
            for (int i = 0; i < smaller.Count; i++)
            {
                r._buffer[i] = a._buffer[i] + b._buffer[i];
            }
            Array.Copy(bigger._buffer, smaller.Count, r._buffer, smaller.Count, bigger.Count - smaller.Count);
            return r;
        }
    }
}
