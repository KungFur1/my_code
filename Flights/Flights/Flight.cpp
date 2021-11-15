#define _CRT_SECURE_NO_WARNINGS
#define _CRT_SECURE_NO_DEPRECATE
#define _CRT_NONSTDC_NO_DEPRECATE
#include <stdlib.h>
#include <string.h>
#include <stdio.h>
#include "Flight.h"
#include "TimeAndDate.h"

Flight::Flight(char* departure_location, char* arrival_location, Date* departure_date, Date* arrival_date, Time* late_arrival, int cost, int flight_number)
{
	this->departure_location = departure_location;
	this->arrival_location = arrival_location;
	this->departure_date = departure_date;
	this->arrival_date = arrival_date;
	this->late_arrival = late_arrival;
	this->cost = cost;
	this->flight_number = flight_number;
}

Flight::Flight(char* departure_location, char* arrival_location, Date* departure_date, Date* arrival_date, int cost, int flight_number)
{
	this->departure_location = departure_location;
	this->arrival_location = arrival_location;
	this->departure_date = departure_date;
	this->arrival_date = arrival_date;
	this->late_arrival = new Time(0, 0, 15, 0); // Standard late time
	this->cost = cost;
	this->flight_number = flight_number;
}

Flight::~Flight()
{
	delete departure_location;
	delete arrival_location;
}

void Flight::printInfo() const
{
	printf("Flight NR.%d from %s to %s\n", flight_number, departure_location, arrival_location);
	printf("Leaves at: ");
	departure_date->printMin();
	printf("\n");
	printf("Arrives at: ");
	arrival_date->printMin();
	printf("\n");
	printf("Late arrival: ");
	late_arrival->print();
	printf("\n");
	printf("Cost %d EUR\n", cost);
}