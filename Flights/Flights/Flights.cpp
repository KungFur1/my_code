#include "TimeAndDate.h"
#include "FlightFinder.h"


int main()
{
	FlightFinder* flight_finder = new FlightFinder();
	flight_finder->readFile("Flights.txt");
	flight_finder->printAllFlights();
	char departure[] = "VNO";
	char arrival[] = "RYG";
	flight_finder->findRoute(departure, arrival, new Date(2019, 0, 0, 0), new Date(2021, 2, 0, 0));
	return 0;
}
