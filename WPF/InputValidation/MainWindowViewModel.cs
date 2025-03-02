using System;

namespace InputValidation
{
    public class MainWindowViewModel
    {
        private DateTime _myDate;

        public DateTime MyDate
        {
            get => _myDate;
            set => _myDate = value;
        }
    }
}
