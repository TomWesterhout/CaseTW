import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/'
import { CursusInstantie } from '../models/cursus-instantie';
import { API } from '../constants/url.constants';

@Injectable({
  providedIn: 'root'
})
export class CursusInstantieService {
  public API = API;
  public CURSUSINSTANTIE_API = `${this.API}/cursusinstantie/index`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Array<CursusInstantie>> {
    return this.http.get<Array<CursusInstantie>>(this.CURSUSINSTANTIE_API);
  }

  get(id: string) {
    return this.http.get(`${this.CURSUSINSTANTIE_API}/${id}`);
  }

  save(cursus: CursusInstantie): Observable<CursusInstantie> {
    let result: Observable<CursusInstantie>;

    if (cursus.id) {
      result = this.http.put<CursusInstantie>(`${this.CURSUSINSTANTIE_API}/${cursus.id}`, cursus);
    }

    return result;
  }

  delete(id: number) {
    return this.http.delete(`${this.CURSUSINSTANTIE_API}/${id.toString}`);
  }
}