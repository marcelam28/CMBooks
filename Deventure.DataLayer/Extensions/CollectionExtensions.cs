using System.Collections.Generic;

namespace Deventure.DataLayer.Extensions
{
    public static class CollectionExtensions
    {
        public static void AddWithRange<T>(this ICollection<T> collection, IList<T> items)
        {
            foreach (var item in items)
            {
                collection.Add(item);
            }
        }

        public static void RemoveWithRange<T>(this ICollection<T> collection, IList<T> items)
        {
            foreach (var item in items)
            {
                collection.Remove(item);
            }
        }

    }
}
