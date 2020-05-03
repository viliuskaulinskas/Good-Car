using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Good_Car.ViewModels
{
    public class NewItemViewModel : INotifyPropertyChanged
    {
        bool calculate = false;
        public bool Calculate
        {
            get => calculate;
            set
            {
                if (calculate == value) return;

                calculate = value;
                OnPropertyChanged(nameof(Calculate));
            }
        }

        string name = "0";
        public string Name
        {
            get => name;
            set
            {
                if (name == value) return;

                name = value;
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(DisplayName));
            }
        }

        public string DisplayName => $"£{Name}";

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
