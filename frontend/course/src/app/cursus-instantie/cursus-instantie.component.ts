import { Component, OnInit } from '@angular/core';
import { CursusInstantieService } from '../shared/api/cursus-instantie.service';
import { CursusInstantie } from '../shared/models/cursus-instantie';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-cursus-instantie',
  templateUrl: './cursus-instantie.component.html',
  styleUrls: ['./cursus-instantie.component.scss']
})
export class CursusInstantieComponent implements OnInit {
  cursusInstantieCollection: Array<CursusInstantie>;
  cursusInstantieColumns: String[] = ['start', 'duur', 'titel'];
  cursusWeek: number = 28; // gebaseerd op de week waarin de opdracht wordt beoordeeld.
  cursusYear: number = 2020;

  constructor(
    private cursusInstantieService: CursusInstantieService, 
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      let cursusWeek = +params.get('cursusweek');
      let cursusYear = +params.get('cursusyear');

      if (cursusWeek === 0 || cursusYear === 0) {
        this.cursusWeek = this.getCurrentWeekNumber();
        this.cursusYear = this.getCurrentYear();
      }

      if (cursusWeek !== null && cursusWeek > 0) {
        this.cursusWeek = cursusWeek;
      }

      if (cursusYear !== null && cursusYear > 0) {
        this.cursusYear = cursusYear;
      }

      this.getCursusInstanties();
      console.log(this.getCurrentWeekNumber());
    });
  }

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
    console.log(date);
    return date;
  }

  getWeeksInYear(year) {
    let day = new Date(year, 0, 1);
    let isLeapYear = new Date(year, 1, 29).getMonth() === 1;

    // 53 weeks: In case January 1st falls on a Thursday or if the year is a leapyear and January 1st falls on a wednesday then. 
    // 52 weeks: all other scenarios.
    return day.getDay() === 4 || isLeapYear && day.getDay() === 3 ? 53 : 52
}

  getCursusInstanties() {
    this.cursusInstantieService.getByWeekAndYear(this.cursusWeek, this.cursusYear).subscribe(cursusInstantieData => {
      this.cursusInstantieCollection = cursusInstantieData;
    })
  }

  increaseCursusWeek() {
    let weeksInCurrentYear = this.getWeeksInYear(this.cursusYear);
    if (this.cursusWeek + 1 > weeksInCurrentYear) {
      this.cursusWeek = 1;
      this.cursusYear++
    }
    else{
      this.cursusWeek++;
    }

    this.getCursusInstanties();
    this.router.navigate(['/cursusinstantie-overzicht', this.cursusWeek, this.cursusYear]);
  }

  decreaseCursusWeek() {
    let weeksInPreviousYear = this.getWeeksInYear(this.cursusYear - 1);
    if (this.cursusWeek - 1 < 1) {
      this.cursusWeek = weeksInPreviousYear;
      this.cursusYear--;
    }
    else{
      this.cursusWeek--;
    }

    this.getCursusInstanties();
    this.router.navigate(['/cursusinstantie-overzicht', this.cursusWeek, this.cursusYear]);
  }
}