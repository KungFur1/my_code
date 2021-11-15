#define _CRT_SECURE_NO_WARNINGS
#define _CRT_SECURE_NO_DEPRECATE
#define _CRT_NONSTDC_NO_DEPRECATE
#include "FlightFinder.h"
#include <stdlib.h>

using namespace std;

class City
{
public:
	char* city;
	Date* date;

	/*Copies data into newly allocated memory*/
	City(const char* city, Date *date)
	{
		this->city = new char[4];
		memccpy(this->city, city, 4, sizeof(char));
		this->date = new Date();
		*(this->date) = *date;
	}
};

class FlightsRoute
{
private:
	char* arrival_location;
	char* departure_location;
	Date* departure_date;
	Date* arrival_date;
	vector<vector<Flight*>*> routes;
public:
	vector<Flight*>* current_route;
	
	FlightsRoute(char* departure_location, char* arrival_location, Date* departure_date, Date* arrival_date)
	{
		routes = vector<vector<Flight*>*>();
		current_route = new vector<Flight*>();
		this->departure_location = departure_location;
		this->arrival_location = arrival_location;
		this->departure_date = departure_date;
		this->arrival_date = arrival_date;
	}
	bool searchDeeper()
	{
		if (routes.size() >= 2)
		{
			return false;
		}
		else
		{
			return true;
		}
	}
	void routeFound() // Decides wether to put this route into routes or not and goes back to normal state
	{
		routes.push_back(new vector<Flight*>());
		for (int i = 1; i < current_route->size(); i++) // Copying from index 1 because first element is fake flight
		{
			routes.back()->push_back((*current_route)[i]);
		}
	}
	void printRoutes()
	{
		for (vector<Flight*>* route_ptr : routes)
		{
			printf("Route: %s ---> %s\n", departure_location, arrival_location);
			printf("Departure: ");
			route_ptr->back()->departure_date->print();
			printf("  ");
			printf("Arrival: ");
			route_ptr->front()->arrival_date->print();
			printf("\n");
			printf("Your flights:\n");
			for (Flight* flight_ptr : *route_ptr)
			{
				flight_ptr->printInfo();
			}
		}
	}
};

FlightFinderErrorCode FlightFinder::readFile(const char* file_location)
{
	FILE* file = fopen(file_location, "r+");
	if (file == NULL)
	{
		return FILE_OPENING_FAILURE;
	}

	while (!feof(file))
	{
		char* departure_location = new char[4];
		if (departure_location == NULL)
		{
			fclose(file);
			return MEMORY_ALLOCATION_FAILURE;
		}

		char* arrival_location = new char[4];
		if (arrival_location == NULL)
		{
			delete[] departure_location;
			fclose(file);
			return MEMORY_ALLOCATION_FAILURE;
		}

		int year, month, day, hour, minute, gap, cost;
		if (fscanf(file, "%s %s %d %d %d %d %d %d %d", departure_location, arrival_location, &year, &month, &day, &hour, &minute, &gap, &cost) < 9)
		{
			delete[] departure_location;
			delete[] arrival_location;
			fclose(file);
			return FILE_READ_FAILURE;
		}

		Date* arrival_date = new Date(year, month, day, hour, minute);
		if (departure_location == NULL)
		{
			delete[] departure_location;
			delete[] arrival_location;
			fclose(file);
			return MEMORY_ALLOCATION_FAILURE;
		}
		Date* departure_date = new Date(year, month, day, hour, minute);
		if (departure_date == NULL)
		{
			delete[] departure_location;
			delete[] arrival_location;
			delete arrival_date;
			fclose(file);
			return MEMORY_ALLOCATION_FAILURE;
		}
		departure_date->addMinutes(gap);

		Flight* flight = new Flight(departure_location, arrival_location, arrival_date, departure_date, cost, flights_amount);
		if (flight == NULL)
		{
			delete[] departure_location;
			delete[] arrival_location;
			delete arrival_date;
			delete departure_date;
			fclose(file);
			return MEMORY_ALLOCATION_FAILURE;
		}

		flights.insertElement(flights.getHashCode(arrival_location), flight);
		++flights_amount;
	}

	fclose(file);
	return NO_ERROR;
}

// SORT FLIGHTS BY TIME! AND FIX THE DEPARTURE CITY BEING UNREACHABLE!
void FlightFinder::findRoute(char* departure_location, char* arrival_location, Date* earliest_departure_date, Date* latest_arrival_date)
{
	FlightsRoute route = FlightsRoute(departure_location, arrival_location, earliest_departure_date, latest_arrival_date);
	HashTable* unreachable_flights = new HashTable();

	bool all_flights_checked = false;
	for (int route_length = 1; route.searchDeeper() && !all_flights_checked; ++route_length)
	{
		unsigned int* layers_positions = new unsigned int[route_length]();
		int current_layer = 0;
		layers_positions[current_layer] = 0;

		route.current_route->push_back(new Flight(arrival_location, arrival_location, latest_arrival_date, latest_arrival_date, -1, -1));

		bool no_available_flights_in_new_layer = true;
		bool all_layer_flights_checked = false;
		while (!all_layer_flights_checked)
		{
			const vector<Flight*>* current_layer_flights = flights.getElementsAt(flights.getHashCode(route.current_route->back()->departure_location));
			if (current_layer_flights->size() >= layers_positions[current_layer] + 1) // If there are more flights to be checked in this layer, then check them
			{
				Flight* current_flight = (*current_layer_flights)[layers_positions[current_layer]];
				const vector<Flight*>* current_flight_unreachable_flights = unreachable_flights->getElementsByDeparture(current_flight);
				if (Date::firstDateLater(earliest_departure_date, current_flight->departure_date)) // Flight is earlier than earliest departure date - unreachable
				{
					if (current_flight_unreachable_flights->size() == 0) // If no added flights to unreachable, then add
					{
						unreachable_flights->insertElementByDeparture(current_flight);
					}
					else if (Date::firstDateLater(current_flight->departure_date, current_flight_unreachable_flights->back()->departure_date)) // If added, but current_flight is later, then add
					{
						unreachable_flights->insertElementByDeparture(current_flight);
					}
				}
				if (!(current_flight_unreachable_flights->size() != 0 && Date::firstDateLaterOrEqual(current_flight_unreachable_flights->back()->departure_date, current_flight->departure_date))) // If this flight is unreachable - skip
				{
					if (current_layer + 1 == route_length) // If final layer
					{
						route.current_route->push_back(current_flight); // Pushin in flight to check
						no_available_flights_in_new_layer = false;
					}
					else
					{
						++current_layer;
						layers_positions[current_layer] = 0;
						route.current_route->push_back(current_flight); // Pushin in flight to check
						no_available_flights_in_new_layer = true; // Reseting
					}
				}
				else
				{
					++layers_positions[current_layer]; // Skipping
				}
			}
			else
			{
				if (no_available_flights_in_new_layer) // If there are no flights that reach this flight, add this flight to unreachable
				{
					unreachable_flights->insertElementByDeparture(route.current_route->back());
					if (route.current_route->size() == 1)
					{
						all_flights_checked = true;
					}
				}
				no_available_flights_in_new_layer = false; // There was an available flight
				--current_layer;
				route.current_route->pop_back();
				if (current_layer == -1)
				{
					break;
				}
				else
				{
					++layers_positions[current_layer];
				}
			}

			if (route.current_route->size() == route_length + 1) // Check last flight
			{
				if (!strcmp(route.current_route->back()->departure_location, departure_location)) // Checking if current layer flight departure location matches with desired departure location
				{
					if (Date::firstDateLater((*(route.current_route))[route.current_route->size()-2]->departure_date, route.current_route->back()->arrival_date)) // Checking if dates are correct
					{
						route.routeFound();
					}
				}
				route.current_route->pop_back(); // Flight checked
				++layers_positions[current_layer];
			}

			if (route.current_route->size() == 0)
			{
				all_layer_flights_checked = true;
			}
		}
		delete[] layers_positions;
	}

	route.printRoutes();

	delete unreachable_flights;
}

void FlightFinder::printAllFlights()
{
	flights.printTable();
}

FlightFinder::FlightFinder()
{

}

FlightFinder::~FlightFinder()
{

}