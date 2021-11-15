#include "TimeAndDate.h"
#include <stdio.h>
#include <stdlib.h>

#define MONTH_01_LENGHT 31
#define MONTH_02_LENGHT 28 // +1 on leap years
#define MONTH_03_LENGHT 31
#define MONTH_04_LENGHT 30
#define MONTH_05_LENGHT 31
#define MONTH_06_LENGHT 30
#define MONTH_07_LENGHT 31
#define MONTH_08_LENGHT 31
#define MONTH_09_LENGHT 30
#define MONTH_10_LENGHT 31
#define MONTH_11_LENGHT 30
#define MONTH_12_LENGHT 31

#define EXITING_PROGRAM "EXITING PROGRAM, FATAL ERROR!\n"
#define DATE_ERROR "Date error! \n"

void Date::addMinutes(int minutes) // Accepts only positive int
{
	if (minutes < 0)
	{
		fprintf(stderr, EXITING_PROGRAM);
		exit(__LINE__);
	}
	this->minute += minutes;
	normalize();
}

void Date::print()
{
	printf("%d/%d/%d %d:%d:%d", year, month, day, hour, minute, second);
}

void Date::printMin()
{
	printf("%d/%d/%d  %d:%d", year, month, day, hour, minute);
}

Date::Date(int year, int month, int day, int hour, int minute, int second)
{
	this->year = year;
	this->month = month;
	this->day = day;
	this->hour = hour;
	this->minute = minute;
	this->second = second;
}

Date::Date(int year, int month, int day, int hour, int minute)
{
	this->year = year;
	this->month = month;
	this->day = day;
	this->hour = hour;
	this->minute = minute;
	this->second = 0;
}

Date::Date(int year, int month, int day, int hour)
{
	this->year = year;
	this->month = month;
	this->day = day;
	this->hour = hour;
	this->minute = 0;
	this->second = 0;
}

Date::Date()
{
	this->year = 0;
	this->month = 0;
	this->day = 0;
	this->hour = 0;
	this->minute = 0;
	this->second = 0;
}

Date::~Date()
{

}

bool Date::firstDateLater(Date* date1, Date* date2)
{
	if (date1->year > date2->year)
	{
		return true;
	}
	else if (date1->year == date2->year)
	{
		if (date1->month > date2->month)
		{
			return true;
		}
		else if (date1->month == date2->month)
		{
			if (date1->day > date2->day)
			{
				return true;
			}
			else if (date1->day == date2->day)
			{
				if (date1->hour > date2->hour)
				{
					return true;
				}
				else if (date1->hour == date2->hour)
				{
					if (date1->minute > date2->minute)
					{
						return true;
					}
					else if (date1->minute == date2->minute)
					{
						if (date1->second > date2->second)
						{
							return true;
						}
					}
				}
			}
		}
	}
	return false;
}

bool Date::firstDateLaterOrEqual(Date* date1, Date* date2)
{
	if (date1->year > date2->year)
	{
		return true;
	}
	else if (date1->year == date2->year)
	{
		if (date1->month > date2->month)
		{
			return true;
		}
		else if (date1->month == date2->month)
		{
			if (date1->day > date2->day)
			{
				return true;
			}
			else if (date1->day == date2->day)
			{
				if (date1->hour > date2->hour)
				{
					return true;
				}
				else if (date1->hour == date2->hour)
				{
					if (date1->minute > date2->minute)
					{
						return true;
					}
					else if (date1->minute == date2->minute)
					{
						if (date1->second > date2->second)
						{
							return true;
						}
					}
				}
			}
		}
	}
	if (date1->year == date2->year && date1->month == date2->month && date1->day == date2->day && date1->hour == date2->hour && date1->minute == date2->minute && date1->second == date2->second)
	{
		return true;
	}

	return false;
}

int Date::yearToMonths(int year)
{
	return year * 12;
}

int Date::monthToDays(int month, int year)
{
	int days = 0;
	while (month > 0)
	{
		if (month >= 1)
		{
			days += 31;
		}
		if (month >= 2)
		{
			days += 28;
			if (year % 4 == 0)
			{
				days += 1;
			}
		}
		if (month >= 3)
		{
			days += 31;
		}
		if (month >= 4)
		{
			days += 30;
		}
		if (month >= 5)
		{
			days += 31;
		}
		if (month >= 6)
		{
			days += 30;
		}
		if (month >= 7)
		{
			days += 31;
		}
		if (month >= 8)
		{
			days += 31;
		}
		if (month >= 9)
		{
			days += 30;
		}
		if (month >= 10)
		{
			days += 31;
		}
		if (month >= 11)
		{
			days += 30;
		}
		if (month >= 12)
		{
			days += 31;
		}
		month -= 12;
		year += 1;
	}
	return days;
}

int Date::dayToHours(int day)
{
	return day * 24;
}

int Date::hourToMinutes(int hour)
{
	return hour * 60;
}

int Date::minuteToSeconds(int minute)
{
	return minute * 60;
}

void Date::normalize()
{
	minute += (int)(second / 60);
	second -= (int)(second / 60) * 60;
	hour += (int)(minute / 60);
	minute -= (int)(minute / 60) * 60;
	day += (int)(hour / 24);
	hour -= (int)(hour / 24) * 24;

day_normalize:
	switch (month)
	{
	case 1:
		if (day > MONTH_01_LENGHT)
		{
			++month;
			day -= MONTH_01_LENGHT;
			goto day_normalize;
		}
		break;
	case 2:
		if ((day > MONTH_02_LENGHT && year % 4 != 0) || (day > MONTH_02_LENGHT + 1 && year % 4 == 0)) // Leap day
		{
			++month;
			day -= MONTH_02_LENGHT;
			if (year % 4 == 0)
			{
				--day;
			}
			goto day_normalize;
		}
		break;
	case 3:
		if (day > MONTH_03_LENGHT)
		{
			++month;
			day -= MONTH_03_LENGHT;
			goto day_normalize;
		}
		break;
	case 4:
		if (day > MONTH_04_LENGHT)
		{
			++month;
			day -= MONTH_04_LENGHT;
			goto day_normalize;
		}
		break;
	case 5:
		if (day > MONTH_05_LENGHT)
		{
			++month;
			day -= MONTH_05_LENGHT;
			goto day_normalize;
		}
		break;
	case 6:
		if (day > MONTH_06_LENGHT)
		{
			++month;
			day -= MONTH_06_LENGHT;
			goto day_normalize;
		}
		break;
	case 7:
		if (day > MONTH_07_LENGHT)
		{
			++month;
			day -= MONTH_07_LENGHT;
			goto day_normalize;
		}
		break;
	case 8:
		if (day > MONTH_08_LENGHT)
		{
			++month;
			day -= MONTH_08_LENGHT;
			goto day_normalize;
		}
		break;
	case 9:
		if (day > MONTH_09_LENGHT)
		{
			++month;
			day -= MONTH_09_LENGHT;
			goto day_normalize;
		}
		break;
	case 10:
		if (day > MONTH_10_LENGHT)
		{
			++month;
			day -= MONTH_10_LENGHT;
			goto day_normalize;
		}
		break;
	case 11:
		if (day > MONTH_11_LENGHT)
		{
			++month;
			day -= MONTH_11_LENGHT;
			goto day_normalize;
		}
		break;
	case 12:
		if (day > MONTH_12_LENGHT)
		{
			++year;
			month = 1;
			day -= MONTH_12_LENGHT;
			goto day_normalize;
		}
		break;
	default:
		fprintf(stderr, DATE_ERROR);
		fprintf(stderr, EXITING_PROGRAM);
		exit(__LINE__);
		break;
	}
}

void Time::print()
{
	printf("%dd %dh %dmin %dsec", days, hours, minutes, seconds);
}

Time::Time(int days, int hours, int minutes, int seconds)
{
	this->days = days;
	this->hours = hours;
	this->minutes = minutes;
	this->seconds = seconds;
	normalize();
}

Time::Time()
{
	this->days = 0;
	this->hours = 0;
	this->minutes = 0;
	this->seconds = 0;
}

Time::~Time()
{

}

void Time::normalize()
{
	minutes += (int)(seconds / 60);
	seconds -= (int)(seconds / 60) * 60;
	hours += (int)(minutes / 60);
	minutes -= (int)(minutes / 60) * 60;
	days += (int)(hours / 24);
	hours -= (int)(hours / 24) * 24;

	bool negative;
	if (days == 0)
	{
		if (hours == 0)
		{
			if (minutes == 0)
			{
				if (seconds == 0)
				{
					return;
				}
				else
				{
					negative = (seconds < 0) ? true : false;
				}
			}
			else
			{
				negative = (minutes < 0) ? true : false;
			}
		}
		else
		{
			negative = (hours < 0) ? true : false;
		}
	}
	else
	{
		negative = (days < 0) ? true : false;
	}
	if (negative)
	{
		if (hours > 0)
		{
			++days;
			hours -= 24;
		}
		if (minutes > 0)
		{
			++hours;
			minutes -= 60;
		}
		if (seconds > 0)
		{
			++minutes;
			seconds -= 60;
		}
	}
	else
	{
		if (hours < 0)
		{
			--days;
			hours += 24;
		}
		if (minutes < 0)
		{
			--hours;
			minutes += 60;
		}
		if (seconds < 0)
		{
			--minutes;
			seconds += 60;
		}
	}
}