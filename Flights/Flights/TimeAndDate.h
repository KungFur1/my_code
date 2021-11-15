#pragma once

class Date
{
public:
	int year;
	int month;
	int day;
	int hour;
	int minute;
	int second;

	void addMinutes(int minutes);
	void print();
	void printMin();

	Date(int year, int month, int day, int hour, int minute, int second);
	Date(int year, int month, int day, int hour, int minute);
	Date(int year, int month, int day, int hour);
	Date();
	~Date();

	static bool firstDateLater(Date* date1, Date* date2);
	static bool firstDateLaterOrEqual(Date* date1, Date* date2);
	static int yearToMonths(int year);
	static int monthToDays(int month, int year);
	static int dayToHours(int day);
	static int hourToMinutes(int hour);
	static int minuteToSeconds(int minute);

private:
	void normalize();
};

class Time
{
public:
	int days;
	int hours;
	int minutes;
	int seconds;

	void print();

	Time(int days, int hours, int minutes, int seconds);
	Time();
	~Time();

private:
	void normalize();
};
