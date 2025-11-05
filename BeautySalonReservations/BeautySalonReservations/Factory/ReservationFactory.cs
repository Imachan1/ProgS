using System;
using BeautySalonReservations.Builder;
using BeautySalonReservations.Reservations;

namespace BeautySalonReservations.Factory
{
    public enum ServiceType { Unknown = 0, Manicure, Haircut, Massage }

    public static class ReservationFactory
    {
        public static IReservation Create(ReservationDetails details)
        {
            switch (details.ServiceType)
            {
                case ServiceType.Manicure: return new ManicureReservation(details);
                case ServiceType.Haircut: return new HaircutReservation(details);
                case ServiceType.Massage: return new MassageReservation(details);
                default:
                    throw new ArgumentException("Unknown service type");
            }
        }
    }
}
