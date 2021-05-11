using System.Collections.Generic;

namespace SystemHelpers
{
    public static class MapperExctantions
    {
        public static Mapper<TSrc> CraeteMaper<TSrc>(this IEnumerable<TSrc> src) => new(src);
    }
}
