using System;

namespace InputValidation.View1
{
    public class ViewModel1
    {
        private DateTime? _myDate;

        public DateTime? MyDate
        {
            get => _myDate;
            set => _myDate = value;
        }
    }
}
