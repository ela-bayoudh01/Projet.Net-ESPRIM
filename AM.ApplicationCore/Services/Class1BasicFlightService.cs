using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;

namespace AM.ApplicationCore.Services
{
    public class BasicFlightService : IBasicFlightService
    {
        private readonly ICollection<Flight> source;

        public BasicFlightService(ICollection<Flight> source)
        {
            this.source = source;
        }

        public void ShowFlights(string filterType, string filterValue)
        {
            foreach (Flight flight in source)
            {
                bool afficher = false;

                switch (filterType.ToLower())
                {
                    case "destination":
                        if (flight.Destination != null &&
                            flight.Destination.Equals(filterValue, StringComparison.OrdinalIgnoreCase))
                        {
                            afficher = true;
                        }
                        break;

                    /* Version non optimisée : 
                     case "flightdate":
                        DateTime dateFiltre = DateTime.Parse(filterValue);
                        if (flight.FlightDate.Date == dateFiltre.Date)
                            afficher = true;
                        break;

                    case "flightid":
                        int idFiltre = int.Parse(filterValue);
                        if (flight.FlightId == idFiltre)
                            afficher = true;
                        break;*/

                    case "flightdate":
                        if (DateTime.TryParse(filterValue, out DateTime dateFiltre))
                        {
                            if (flight.FlightDate.Date == dateFiltre.Date)
                                afficher = true;
                        }
                        break;

                    case "flightid":
                        if (int.TryParse(filterValue, out int idFiltre))
                        {
                            if (flight.FlightId == idFiltre)
                                afficher = true;
                        }
                        break;

                    default:
                        throw new ArgumentException("Unknown filter");
                }

                if (afficher)
                {
                    Console.WriteLine(flight);
                }
            }
        }
    }
}