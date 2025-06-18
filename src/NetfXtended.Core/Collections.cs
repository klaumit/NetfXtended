using System.Collections.Generic;

namespace NetfXtended.Core
{
    public static class Collections
    {
        public static void AddRange<T>(this ICollection<T> coll, IEnumerable<T> items)
        {
            foreach (var item in items)
                coll.Add(item);
        }
    }
}