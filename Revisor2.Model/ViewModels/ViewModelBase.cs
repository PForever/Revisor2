using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Revisor2.Model.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        protected void Set<T>(ref T oldValue, T newValue, [CallerMemberName] string propertyName = "")
        {
            if (oldValue.Equals(newValue)) return;
            OnPropertyChange(propertyName);
        }
        protected void OnPropertyChange([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
