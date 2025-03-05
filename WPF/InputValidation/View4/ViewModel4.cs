using System;
using System.ComponentModel;

namespace InputValidation.View4
{
    public class ViewModel4 : INotifyPropertyChanged, IDataErrorInfo
    {
        private DateTime? _startDate;
        private DateTime? _endDate;

        public DateTime? StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
                OnPropertyChanged(nameof(EndDate)); // Notify EndDate validation
            }
        }

        public DateTime? EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
                OnPropertyChanged(nameof(StartDate)); // Notify StartDate validation
            }
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == nameof(StartDate) || columnName == nameof(EndDate))
                {
                    if (StartDate != null && EndDate != null && StartDate > EndDate)
                    {
                        return "Start date must be earlier than End date.";
                    }
                }
                return null;
            }
        }

        public string Error => null;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
