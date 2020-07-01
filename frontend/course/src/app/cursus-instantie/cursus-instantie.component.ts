import { Component, OnInit } from '@angular/core';
import { CursusInstantieService } from '../shared/api/cursus-instantie.service';
import { CursusInstantie } from '../shared/models/cursus-instantie';

@Component({
  selector: 'app-cursus-instantie',
  templateUrl: './cursus-instantie.component.html',
  styleUrls: ['./cursus-instantie.component.scss']
})
export class CursusInstantieComponent implements OnInit {
  cursusInstantieCollection: Array<CursusInstantie>;
  cursusInstantieColumns: string[] = ['start', 'duur', 'titel'];

  constructor(private cursusInstantieService: CursusInstantieService) { }

  ngOnInit(): void {
    this.cursusInstantieService.getAll().subscribe(cursusInstantieData => {
      this.cursusInstantieCollection = cursusInstantieData;
    });
  }

}