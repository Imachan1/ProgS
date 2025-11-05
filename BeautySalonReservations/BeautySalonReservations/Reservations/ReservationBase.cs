using System.Text;
using BeautySalonReservations.Builder;

namespace BeautySalonReservations.Reservations
{
    public abstract class ReservationBase : IReservation
    {
        protected readonly ReservationDetails Details;

        protected ReservationBase(ReservationDetails details)
        {
            Details = details;
        }

        public virtual string ShortInfo()
        {
            return string.Format("{0} for {1}  {2:yyyy-MM-dd HH:mm}",
                GetType().Name, Details.CustomerName, Details.DateTime);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Rodzaj usługi: " + GetType().Name);
            sb.AppendLine("Klient: " + Details.CustomerName);
            sb.AppendLine(string.Format("Data/czas: {0:yyyy-MM-dd HH:mm}", Details.DateTime));
            sb.AppendLine("Lokalizacja: " + Details.Location);
            sb.AppendLine("Czas trwania: " + Details.DurationMinutes);
            sb.AppendLine("Uwagi: " + Details.Notes);
            return sb.ToString();
        }
    }
}
