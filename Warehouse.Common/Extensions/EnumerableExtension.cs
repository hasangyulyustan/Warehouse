using Warehouse.Domain.Entities;

namespace Warehouse.Common.Extensions
{
	public static class EnumerableExtension
	{
        public static IEnumerable<Product> FilterByMinPrice(this IEnumerable<Product> source, decimal? value)
        {
            if (value is not null)
            {
                return source.Where(p => p.Price >= value);
            }

            return source;
        }

        public static IEnumerable<Product> FilterByMaxPrice(this IEnumerable<Product> source, decimal? value)
        {
            if (value is not null)
            {
                return source.Where(p => p.Price <= value);
            }

            return source;
        }
    }
}

