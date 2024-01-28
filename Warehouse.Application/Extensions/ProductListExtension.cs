namespace Warehouse.Application.Extensions
{
	public static class ProductListExtension
	{
        public static List<string> GetMostCommon10SkippingFirst5Ordered(this List<string> source)
        {
            return source
                .GroupBy(x => x)
                .Select(x => new
                {
                    KeyField = x.Key,
                    Count = x.Count()
                })
                .OrderByDescending(x => x.Count)
                .Skip(5)
                .Take(10)
                .Select(x => x.KeyField).ToList();
        }
    }
}

