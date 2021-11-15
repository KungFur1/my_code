#pragma once
#include <list>
#include <string.h>
#include "HashTable.h"
#include "TimeAndDate.h"

enum FlightFinderErrorCode { NO_ERROR, FILE_OPENING_FAILURE, MEMORY_ALLOCATION_FAILURE, FILE_READ_FAILURE };

class FlightFinder
{
public:
	HashTable flights;
	int flights_amount = 0;

	FlightFinder();
	~FlightFinder();

	FlightFinderErrorCode readFile(const char* file_location);
	void findRoute(char* departure, char* arrival, Date* earliest_departure_date, Date* latest_arrival_date);
	void printAllFlights();

private:
	bool flightIsSuitable(Flight* flight, Date* home_town_departure_date, Date* next_flight_departure_date);
};