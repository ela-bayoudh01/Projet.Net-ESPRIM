using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;

namespace AM.ApplicationCore.Services
{
    public class BasicFlightService : IBasicFlightService
    {
        private readonly IEnumerable<Flight> _source;
        private readonly ShowLine _showLine;  // ← le délégué stocké

        public BasicFlightService(IEnumerable<Flight> source, ShowLine showLine)
        {
            _source = source ?? throw new ArgumentNullException(nameof(source));
            _showLine = showLine ?? throw new ArgumentNullException(nameof(showLine));
        }

        public void ShowFlights(string filterType, string filterValue)
        {
            _showLine($"Filtre appliqué → Type: {filterType}, Valeur: {filterValue}");

            bool found = false;

            foreach (Flight flight in _source)
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
                    // question 4 : utiliser le délégué au lieu de Console.WriteLine
                    _showLine(flight.ToString());
                    found = true;
                }
            }

            if (!found)
            {
                _showLine("Aucun vol ne correspond au filtre.");
            }
        }

        public IEnumerable<object> GetDurationsInMinutes()
        {
            return _source.Select(e => new { e.FlightId, EstimatedDurationInMinutes = 60 * e.EstimatedDuration });
        }
        public IEnumerable<Flight> GetFlightsSortedByDuration()
        {
            return _source.OrderByDescending(e => e.EstimatedDuration);
        }
        public float GetDurationsAverage()
        {
            return _source.Average(e => e.EstimatedDuration);
        }
        public IEnumerable<string> GetPassengerTypes(int flightId)
        {
            return _source.Where(e => e.FlightId == flightId).First().Passengers.Select(e => e.PassengerType);
        }
        public IEnumerable<object> GetDurationsInMinutesLINQ()
        {
            return from e in _source select new { e.FlightId, EstimatedDurationInMinutes = 60 * e.EstimatedDuration };
        }
    }
}