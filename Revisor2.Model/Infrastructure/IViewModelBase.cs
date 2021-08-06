using System.ComponentModel;

namespace Revisor2.Model.Infrastructure
{
    public interface IViewModelBase
    {
        bool IsChanged { get; }

        event PropertyChangedEventHandler PropertyChanged;
    }
}
