import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DateService {

  constructor() { }

  getCurrentWeekNumber(): number {
    let date = new Date();
    let utcDate = new Date(Date.UTC(Number(date.getFullYear()), Number(date.getMonth()), Number(date.getDate())));
    let dayNum = utcDate.getUTCDay() || 7;

    utcDate.setUTCDate(utcDate.getUTCDate() + 4 - dayNum);

    let yearStart = new Date(Date.UTC(utcDate.getUTCFullYear(),0,1));

    return Math.ceil((((utcDate.getTime() - yearStart.getTime()) / 86400000) + 1)/7);
  };

  getCurrentYear(): number {
    let date = new Date().getFullYear();
    return date;
  }

  getWeeksInYear(year) {
    let day = new Date(year, 0, 1);
    let isLeapYear = new Date(year, 1, 29).getMonth() === 1;

    // 53 weeks: In case January 1st falls on a Thursday or if the year is a leapyear and January 1st falls on a wednesday then. 
    // 52 weeks: all other scenarios.
    return day.getDay() === 4 || isLeapYear && day.getDay() === 3 ? 53 : 52
  }
}
