using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revisor2.Model.Filters
{
    public class PersonFilterDto
    {
    }
    public struct Filter<T>
    {
        public bool Setted { get; init; }
        public FilterType Type { get; init; }
        public T Value { get; init; }
    }
    public enum FilterType
    {
        Non, Equals, NotEquals, In, NotIn, Contains, NotContains
    }
}
