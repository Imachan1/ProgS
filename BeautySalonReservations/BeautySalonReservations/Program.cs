using System;
using BeautySalonReservations.Builder;
using BeautySalonReservations.Factory;
using BeautySalonReservations.Logging;
using BeautySalonReservations.Reservations;

namespace BeautySalonReservations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var logger = Logger.Instance;

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Wybierz rodzaj usługi:");
                Console.WriteLine("1) Manicure");
                Console.WriteLine("2) Fryzjer");
                Console.WriteLine("3) Masaż");
                Console.WriteLine("0) Wyjście");
                Console.Write("Twój wybór: ");

                var choice = Console.ReadLine();
                if (choice == "0") break;

                ServiceType serviceType = ServiceType.Unknown;
                switch (choice)
                {
                    case "1": serviceType = ServiceType.Manicure; break;
                    case "2": serviceType = ServiceType.Haircut; break;
                    case "3": serviceType = ServiceType.Massage; break;
                    default: serviceType = ServiceType.Unknown; break;
                }

                if (serviceType == ServiceType.Unknown)
                {
                    Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                    continue;
                }

                var builder = new ReservationBuilder();

                Console.Write("Imię klienta: ");
                string name = (Console.ReadLine() ?? "").Trim();
                if (name.Length == 0) name = "Gość";

                Console.Write("Data i godzina (np. 2025-11-01 15:30): ");
                DateTime dateTime;
                if (!DateTime.TryParse(Console.ReadLine(), out dateTime))
                {
                    Console.WriteLine("Nieprawidłowy format daty/czasu. Przykład: 2025-11-01 15:30");
                    continue;
                }

                Console.Write("Gabinet: ");
                string location = (Console.ReadLine() ?? "").Trim();
                if (location.Length == 0) location = "Gabinet 1";

                Console.Write("Czas trwania (minuty): ");
                int duration;
                if (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
                {
                    Console.WriteLine("Nieprawidłowe dane");
                    continue;
                }

                Console.Write("Dodatkowe życzenia: ");
                string notes = Console.ReadLine() ?? "";

                var details = builder
                    .WithCustomerName(name)
                    .WithDateTime(dateTime)
                    .WithLocation(location)
                    .WithDurationMinutes(duration)
                    .WithNotes(notes)
                    .WithServiceType(serviceType)
                    .Build();

                IReservation reservation = ReservationFactory.Create(details);

                Console.WriteLine();
                Console.WriteLine("Rezerwacja utworzona: ");
                Console.WriteLine(reservation);

                Console.WriteLine("Rezerwacja utworzona: " + reservation.ShortInfo());
            }

        }
    }
}