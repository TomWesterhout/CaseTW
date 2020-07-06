import { Component, OnInit } from '@angular/core';
import { CursusInstantieService } from '../shared/api/cursus-instantie.service';
import { CursusInstantie } from '../shared/models/cursus-instantie';
import { ActivatedRoute, Router } from '@angular/router';
import { DateService } from '../shared/api/date.service';

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
    private dateService: DateService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      let cursusWeek = +params.get('cursusweek');
      let cursusYear = +params.get('cursusyear');

      if (cursusWeek !== null && cursusWeek === 0 || cursusYear !== null && cursusYear === 0) {
        this.cursusWeek = this.dateService.getCurrentWeekNumber();
        this.cursusYear = this.dateService.getCurrentYear();
      }

      if (cursusWeek !== null && cursusWeek > 0) {
        this.cursusWeek = cursusWeek;
      }

      if (cursusYear !== null && cursusYear > 0) {
        this.cursusYear = cursusYear;
      }

      this.getCursusInstanties();
    });
  }

  getCursusInstanties() {
    this.cursusInstantieService.getByWeekAndYear(this.cursusWeek, this.cursusYear).subscribe(cursusInstantieData => {
      this.cursusInstantieCollection = cursusInstantieData;
    });
    this.router.navigate(['/cursusinstantie-overzicht', this.cursusWeek, this.cursusYear]);
  }

  increaseCursusWeek() {
    let weeksInCurrentYear = this.dateService.getWeeksInYear(this.cursusYear);
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
    let weeksInPreviousYear = this.dateService.getWeeksInYear(this.cursusYear - 1);
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