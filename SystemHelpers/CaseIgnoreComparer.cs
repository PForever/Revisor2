using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace SystemHelpers
{
    public class CaseIgnoreComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y) => string.Equals(x, y, StringComparison.CurrentCultureIgnoreCase);

        public int GetHashCode([DisallowNull] string obj) => obj.GetHashCode(StringComparison.CurrentCultureIgnoreCase);
    }
}
