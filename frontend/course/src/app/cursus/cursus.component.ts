import { Component, OnInit } from '@angular/core';
import { CursusService } from '../shared/api/cursus.service';
import { Cursus } from '../shared/models/cursus';

@Component({
  selector: 'app-cursus',
  templateUrl: './cursus.component.html',
  styleUrls: ['./cursus.component.scss']
})
export class CursusComponent implements OnInit {
  cursusCollection: Array<Cursus>;

  constructor(private cursusService: CursusService) { }

  ngOnInit(): void {
    this.cursusService.getAll().subscribe(cursusData => {
      this.cursusCollection = cursusData;
    });
  }

}