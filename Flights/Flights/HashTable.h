#pragma once
#include "Flight.h"
#include <list>
#include <vector>
using namespace std;

class HashTable
{
private:
	static const int array_size = 17577; // 26x26x26 + 1
	static const int bad_element_index = 17576; // Last
	vector<Flight*> table[array_size]; // table[17576] Bad elements go here

public:
	HashTable();
	~HashTable();

	bool isEmpty() const;
	int getHashCode(const char* key) const;
	void insertElement(int hash_code, Flight* element);
	void insertElementByDeparture(Flight* element);
	void insertElementByArrrival(Flight* element);
	void removeGroup(int hash_code);
	const vector<Flight*>* getElementsAt(int hash_code) const;
	const vector<Flight*>* getElementsByDeparture(Flight* flight) const;
	const vector<Flight*>* getElementsByArrival(Flight* flight) const;
	void printTable() const;

private:
	bool hashCodeInBounds(int hash_code) const;
};