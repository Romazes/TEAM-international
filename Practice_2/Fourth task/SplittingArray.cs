using System.Linq;
using System.Collections.Generic;

namespace Practice_2
{
    class SplittingArray
    {
        public static ILookup<bool, int> Split(List<int> input)
        {
            return input
                .ToList()
                .Select((item, index) => new { isEven = item % 2 == 0, item })
                .ToLookup(i => i.isEven, i => i.item);
        }
    }
}
