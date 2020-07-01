import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/'
import { Cursus } from '../models/cursus';
import { API } from '../constants/url.constants';

@Injectable({
  providedIn: 'root'
})
export class CursusService {
  public API = API;
  public CURSUS_API = `${this.API}/cursus`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Array<Cursus>> {
    return this.http.get<Array<Cursus>>(this.CURSUS_API);
  }

  get(id: string) {
    return this.http.get(`${this.CURSUS_API}/${id}`);
  }

  save(cursus: Cursus): Observable<Cursus> {
    let result: Observable<Cursus>;

    if (cursus.id) {
      result = this.http.put<Cursus>(`${this.CURSUS_API}/${cursus.id}`, cursus);
    }

    return result;
  }

  delete(id: number) {
    return this.http.delete(`${this.CURSUS_API}/${id.toString}`);
  }
}