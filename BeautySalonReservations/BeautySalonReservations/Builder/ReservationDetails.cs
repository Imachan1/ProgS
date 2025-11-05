using System;
using BeautySalonReservations.Factory;

namespace BeautySalonReservations.Builder
{
    public sealed class ReservationDetails
    {
        public string CustomerName { get; set; }
        public DateTime DateTime { get; set; }
        public string Location { get; set; }
        public int DurationMinutes { get; set; }
        public string Notes { get; set; }
        public ServiceType ServiceType { get; set; }

        public ReservationDetails()
        {
            CustomerName = "";
            Location = "";
            Notes = "";
            ServiceType = ServiceType.Unknown;
        }
    }
}
