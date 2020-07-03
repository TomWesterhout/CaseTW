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
      if (cursusWeek !== null && cursusWeek > 0) {
        this.cursusWeek = cursusWeek;
      }
      if (this.cursusYear !== null && this.cursusYear > 0) {
        this.cursusYear = cursusYear;
      }
      this.getCursusInstanties();
    });
  }

  getCursusInstanties() {
    this.cursusInstantieService.getByWeekAndYear(this.cursusWeek, this.cursusYear).subscribe(cursusInstantieData => {
      this.cursusInstantieCollection = cursusInstantieData;
    })
  }

  increaseCursusWeek() {
    this.cursusWeek = this.cursusWeek++ > 53 ? this.cursusWeek : this.cursusWeek++;
    this.getCursusInstanties();
    this.router.navigate(['/cursusinstantie-overzicht', this.cursusWeek, this.cursusYear]);
  }

  decreaseCursusWeek() {
    this.cursusWeek = this.cursusWeek-- <= 0 ? this.cursusWeek : this.cursusWeek--;
    this.getCursusInstanties();
  }
}