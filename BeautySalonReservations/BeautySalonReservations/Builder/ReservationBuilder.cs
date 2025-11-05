using System;
using BeautySalonReservations.Factory;

namespace BeautySalonReservations.Builder
{
    public class ReservationBuilder
    {
        private string _customerName = "";
        private DateTime _dateTime = DateTime.Now;
        private string _location = "";
        private int _duration = 30;
        private string _notes = "";
        private ServiceType _serviceType = ServiceType.Unknown;

        public ReservationBuilder WithCustomerName(string name)
        {
            _customerName = name ?? "";
            return this;
        }

        public ReservationBuilder WithDateTime(DateTime dateTime)
        {
            _dateTime = dateTime;
            return this;
        }

        public ReservationBuilder WithLocation(string location)
        {
            _location = location ?? "";
            return this;
        }

        public ReservationBuilder WithDurationMinutes(int minutes)
        {
            _duration = minutes;
            return this;
        }

        public ReservationBuilder WithNotes(string notes)
        {
            _notes = notes ?? "";
            return this;
        }

        public ReservationBuilder WithServiceType(ServiceType type)
        {
            _serviceType = type;
            return this;
        }

        public ReservationDetails Build()
        {
            if (_serviceType == ServiceType.Unknown)
                throw new InvalidOperationException("Service type is required");

            if (string.IsNullOrWhiteSpace(_customerName))
                throw new InvalidOperationException("Customer name is required");

            if (string.IsNullOrWhiteSpace(_location))
                _location = "Gabinet 1";

            var result = new ReservationDetails();
            result.CustomerName = _customerName;
            result.DateTime = _dateTime;
            result.Location = _location;
            result.DurationMinutes = _duration;
            result.Notes = _notes;
            result.ServiceType = _serviceType;
            return result;
        }
    }
}
