using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore
{
    public static class InMemorySource
    {
        public static Plane Boeing1 { get; private set; }
        public static readonly Plane Boeing2;
        public static readonly Plane Airbus;
        private static Plane CreateBoeing1()
        {
            Plane p = new Plane();
            p.PlaneId = 1;
            p.PlaneType = PlaneType.Boeing;
            p.Capacity = 200;
            p.ManufactureDate = new DateTime(2015, 12, 31);
            return p;
        }

        static InMemorySource()
        {
            // Initialisation Boeing1
            Boeing1 = CreateBoeing1();

            // Initialisation Boeing2 avec constructeur paramétré
            Boeing2 = new Plane(PlaneType.Boeing, 150, new DateTime(2016, 2, 5));
            Boeing2.PlaneId = 2;

            // Initialisation Airbus avec constructeur non paramétré
            Airbus = new Plane();
            Airbus.PlaneId = 3;
            Airbus.PlaneType = PlaneType.Airbus;
            Airbus.Capacity = 250;
            Airbus.ManufactureDate = new DateTime(2020, 11, 11);
        }

        public static readonly IList<Staff> Staffs = new List<Staff>
        {
            new Staff
            {
                FirstName = "captain",
                LastName = "Captain",
                EmailAddress = "captain@gmail.com",
                BirthDate = new DateTime(1965, 1, 1),
                EmploymentDate = new DateTime(1999, 1, 1),
                Salary = 10000
            },
            new Staff
            {
                FirstName = "hotesse1",
                LastName = "Hotesse1",
                EmailAddress = "hotesse1@gmail.com",
                BirthDate = new DateTime(1995, 1, 1),
                EmploymentDate = new DateTime(2020, 1, 1),
                Salary = 5000
            },
            new Staff
            {
                FirstName = "hotesse2",
                LastName = "Hotesse2",
                EmailAddress = "hotesse2@gmail.com",
                BirthDate = new DateTime(1996, 1, 1),
                EmploymentDate = new DateTime(2021, 1, 1),
                Salary = 6100
            }
        };

        public static readonly IList<Traveller> Travellers = new List<Traveller>
        {
            new Traveller
            {
                FirstName = "traveller1",
                LastName = "Traveller1",
                BirthDate = new DateTime(1980, 1, 1),
                HealthInformation = "No trouble",
                Nationality = "American"
            },
            new Traveller
            {
                FirstName = "traveller2",
                LastName = "Traveller2",
                BirthDate = new DateTime(1981, 1, 1),
                HealthInformation = "Some trouble",
                Nationality = "French"
            },
            new Traveller
            {
                FirstName = "traveller3",
                LastName = "Traveller3",
                BirthDate = new DateTime(1982, 1, 1),
                HealthInformation = "No trouble",
                Nationality = "Tunisian"
            },
            new Traveller
            {
                FirstName = "traveller4",
                LastName = "Traveller4",
                BirthDate = new DateTime(1983, 1, 1),
                HealthInformation = "Some trouble",
                Nationality = "American"
            },
            new Traveller
            {
                FirstName = "traveller5",
                LastName = "Traveller5",
                BirthDate = new DateTime(1984, 1, 1),
                HealthInformation = "Some trouble",
                Nationality = "Spanish"
            }
        };

        public static readonly IList<Flight> Flights = new List<Flight>
        {
            new Flight
            {
                FlightId = 1,
                FlightDate = new DateTime(2022, 1, 1, 15, 10, 0),
                Destination = "Paris",
                EffectiveArrival = new DateTime(2022, 1, 1, 17, 10, 0),
                EstimatedDuration = 2,
                Plane = Boeing1,
                Passengers = new List<Passenger>(Staffs)

            },
            new Flight
            {
                FlightId = 2,
                FlightDate = new DateTime(2022, 2, 1, 21, 10, 0),
                Destination = "Paris",
                EffectiveArrival = new DateTime(2022, 2, 1, 23, 10, 0),
                EstimatedDuration = 2,
                Plane = Boeing1,
                Passengers = new List<Passenger>(Travellers)

            },
            new Flight
            {
                FlightId = 3,
                FlightDate = new DateTime(2022, 3, 1, 5, 10, 0),
                Destination = "Paris",
                EffectiveArrival = new DateTime(2022, 3, 1, 7, 10, 0),
                EstimatedDuration = 2,
                Plane = Boeing2,
                Passengers = GetAllPassengers()

            },
            new Flight
            {
                FlightId = 4,
                FlightDate = new DateTime(2022, 4, 1, 6, 10, 0),
                Destination = "Madrid",
                EffectiveArrival = new DateTime(2022, 4, 1, 8, 45, 0),
                EstimatedDuration = 2,
                Plane = Boeing2

            },
            new Flight
            {
                FlightId = 5,
                FlightDate = new DateTime(2022, 5, 1, 17, 10, 0),
                Destination = "Madrid",
                EffectiveArrival = new DateTime(2022, 5, 1, 19, 45, 0),
                EstimatedDuration = 2,
                Plane = Airbus
            },
            new Flight
            {
                FlightId = 6,
                FlightDate = new DateTime(2022, 6, 1, 20, 10, 0),
                Destination = "Lisbonne",
                EffectiveArrival = new DateTime(2022, 6, 1, 23, 10, 0),
                EstimatedDuration = 3,
                Plane = Airbus
            }
        };
        private static IList<Passenger> GetAllPassengers()
        {
            return Staffs.Cast<Passenger>().Concat(Travellers).ToList();
        }


        public static List<Flight> Flights2 { get; } = new List<Flight>
        {
            new Flight { FlightId = 1, Destination = "Paris", FlightDate = new DateTime(2025, 2, 15, 11, 10, 0) },
            new Flight { FlightId = 2, Destination = "Paris", FlightDate = new DateTime(2025, 1, 1, 21, 10, 0) },
            new Flight { FlightId = 3, Destination = "Paris", FlightDate = new DateTime(2025, 1, 1, 5, 10, 0) },
            new Flight { FlightId = 4, Destination = "Madrid", FlightDate = new DateTime(2022, 1, 1, 6, 10, 0) },
            new Flight { FlightId = 5, Destination = "Madrid", FlightDate = new DateTime(2022, 1, 1, 17, 10, 0) }
        };








    }
}
