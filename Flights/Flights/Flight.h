#pragma once
#include "TimeAndDate.h"

class Flight
{
public:
	char* departure_location; // 3 symbols only! ends with \0
	char* arrival_location; // 3 symbols only! ends with \0
	Date* departure_date;
	Date* arrival_date;
	Time* late_arrival; // Extra time in case of late arrival
	int cost; // One way trip cost (Eur)
	int flight_number; // Flight number, unique

	Flight(char* departure_location, char* arrival_location, Date* departure_date, Date* arrival_date, Time* late_arrival, int cost, int flight_number);
	Flight(char* departure_location, char* arrival_location, Date* departure_date, Date* arrival_date, int cost, int flight_number);
	~Flight();
	void printInfo() const;
};

