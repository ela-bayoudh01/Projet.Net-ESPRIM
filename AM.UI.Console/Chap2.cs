using System;  // ← très important pour Console
using AM.ApplicationCore;           // pour ShowLine
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;

namespace AM.UI.Console
{
    public static class Chap2
    {
        static ShowLine showLine = System.Console.WriteLine;
        public static void Test1()
        {
            var flightService = new BasicFlightService(InMemorySource.Flights, showLine);

            flightService.ShowFlights("Destination", "Paris");
            flightService.ShowFlights("Destination", "Madrid");
            flightService.ShowFlights("FlightId", "3");
        }

        public static void Test2()
        {
            var flightService = new BasicFlightService(InMemorySource.Flights, showLine);

            flightService.GetDurationsInMinutes().ShowList("== GetDurationsInMinutes ==", showLine);
            flightService.GetFlightsSortedByDuration().ShowList("== GetFlightsSortedByDuration ==", showLine);
            new[] { flightService.GetDurationsAverage() }.ShowList("== GetDurationsAverage ==", showLine);
            flightService.GetPassengerTypes(3).ShowList("== GetPassengerTypes ==", showLine);
            flightService.GetDurationsInMinutesLINQ().ShowList("== GetDurationsInMinutesLINQ ==", showLine);
        }
    }
}