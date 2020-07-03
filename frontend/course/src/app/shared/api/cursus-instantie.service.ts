import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/'
import { CursusInstantie } from '../models/cursus-instantie';
import { API } from '../constants/url.constants';
import { Cursus } from '../models/cursus';

@Injectable({
  providedIn: 'root'
})
export class CursusInstantieService {
  public API = API;
  public CURSUSINSTANTIE_API = `${this.API}/cursusinstantie/index`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Array<CursusInstantie>> {
    return this.http.get<Array<CursusInstantie>>(`${this.CURSUSINSTANTIE_API}`);
  }

  getByWeekAndYear(cursusWeek: Number, cursusYear: Number) {
    return this.http.get<Array<CursusInstantie>>(`${this.CURSUSINSTANTIE_API}?cursusweek=${cursusWeek}&cursusyear=${cursusYear}`)
  }
}