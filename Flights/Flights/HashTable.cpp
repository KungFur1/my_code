#include "HashTable.h"

HashTable::HashTable()
{

}

HashTable::~HashTable()
{

}

bool HashTable::isEmpty() const
{
	for (int i = 0; i < array_size; ++i)
	{
		if (table[i].size() > 0)
		{
			return false;
		}
	}
	return true;
}

/*A unique hash_code made from the first three letters*/
int HashTable::getHashCode(const char* key) const
{
	int ret_val;
	if (key[0] < 'A' || key[0] > 'Z' || key[1] < 'A' || key[1] > 'Z' || key[2] < 'A' || key[2] > 'Z')
	{
		ret_val = bad_element_index;
	}
	else
	{
		ret_val = (key[0] - 'A') + (key[1] - 'A') * 26 + (key[2] - 'A') * 26 * 26;
	}
	return ret_val;
}

/*Inserts element to the back of the group*/
void HashTable::insertElement(int hash_code, Flight* element)
{
	if (hashCodeInBounds(hash_code))
	{
		table[hash_code].push_back(element);
	}
	else
	{
		table[bad_element_index].push_back(element);
	}
}

void HashTable::insertElementByDeparture(Flight* element)
{
	int hash_code = this->getHashCode(element->departure_location);
	this->insertElement(hash_code, element);
}

void HashTable::insertElementByArrrival(Flight* element)
{
	int hash_code = this->getHashCode(element->arrival_location);
	this->insertElement(hash_code, element);
}

/*Destroys all elements in the group*/
void HashTable::removeGroup(int hash_code)
{
	if (hashCodeInBounds(hash_code))
	{
		table[hash_code].clear();
	}
}

const vector<Flight*>* HashTable::getElementsAt(int hash_code) const
{
	if (hashCodeInBounds(hash_code))
	{
		return &(table[hash_code]);
	}
	else
	{
		return NULL;
	}
}

const vector<Flight*>* HashTable::getElementsByDeparture(Flight* flight) const
{
	int hash_code = this->getHashCode(flight->departure_location);
	return this->getElementsAt(hash_code);
}

const vector<Flight*>* HashTable::getElementsByArrival(Flight* flight) const
{
	int hash_code = this->getHashCode(flight->arrival_location);
	return this->getElementsAt(hash_code);
}

bool HashTable::hashCodeInBounds(int hash_code) const
{
	if (hash_code >= 0 && hash_code < array_size)
	{
		return true;
	}
	else
	{
		return false;
	}
}

void HashTable::printTable() const
{
	for (int i = 0; i < array_size; ++i)
	{
		for (auto& element : table[i])
		{
			printf("Index %d\n", i);
			element->printInfo();
			printf("\n");
		}
	}
}