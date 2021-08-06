using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Revisor2.Model.Infrastructure
{
    public static class InfrastructureHelper
    {
        public static ViewModelCollection<T, TParent> 
            ToViewModelCollection<T, TParent>(this IEnumerable<T> collection, TParent parent, Action<T, TParent> parentSetter)
            where T : class, IViewModelBase => new(collection, parent, parentSetter);

    }
}
