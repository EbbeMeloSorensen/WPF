using System;
using System.ComponentModel;

namespace InputValidation.View2
{
    public class ViewModel2 : INotifyPropertyChanged, IDataErrorInfo
    {
        private string _myString;
        private DateTime? _myDate;

        public string MyString
        {
            get => _myString;
            set
            {
                _myString = value;
                OnPropertyChanged(nameof(MyString));
            }
        }

        public DateTime? MyDate
        {
            get => _myDate;
            set
            {
                _myDate = value;
                OnPropertyChanged(nameof(MyDate));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == nameof(MyString))
                {
                    if (string.IsNullOrEmpty(MyString))
                    {
                        return "Strign is required.";
                    }
                }
                else if (columnName == nameof(MyDate))
                {
                    if (MyDate == null)
                    {
                        return "Date is required.";
                    }
                    if (MyDate < DateTime.Today)
                    {
                        return "Date cannot be in the past.";
                    }
                }

                return null;
            }
        }

        public string Error => null;
    }
}
