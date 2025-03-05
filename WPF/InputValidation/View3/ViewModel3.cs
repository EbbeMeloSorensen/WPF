using System;
using System.ComponentModel;

namespace InputValidation.View3
{
    public class ViewModel3 : INotifyPropertyChanged
    {
        private DateTime _myDate;

        public DateTime MyDate
        {
            get => _myDate;
            set
            {
                if (value < DateTime.Today)
                {
                    throw new ArgumentException("Date cannot be in the past");
                }

                _myDate = value;
                OnPropertyChanged(nameof(MyDate));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
