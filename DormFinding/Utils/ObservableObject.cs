using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DormFinding
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string newProperty)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(newProperty));
        }
        protected virtual bool OnPropertyChanged<T>(ref T backingField, T newValue,string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingField, newValue))
                return false;

            backingField = newValue;

            OnPropertyChanged(propertyName);

            return true;
        }
    }
}
