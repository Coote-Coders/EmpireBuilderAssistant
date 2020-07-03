using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EmpireBuilderAssistant.ViewModel
{
    /// <summary>
    /// Provides a base class for all view model objects that wish to use INotifyPropertyChanged.
    /// </summary>
    public class ViewModelUpdate : INotifyPropertyChanged
    {
        public void OnPropertyChanged([CallerMemberName] string propName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public void InvalidateAllProperties()
        {
            foreach (var prop in GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.FlattenHierarchy))
            {
                OnPropertyChanged(prop.Name);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

