using System.Collections.Generic;
using System.Linq;

namespace SystemHelpers
{
    public class Mapper<TSrc>
    {
        public IEnumerable<TDst> Map<TDst>() where TDst : new() => Source.Select(i => i.Map<TSrc, TDst>());
        public IEnumerable<TSrc> Source { get; }
        public Mapper(IEnumerable<TSrc> source) => Source = source;
    }
}
