import { Injectable } from '@angular/core';
import { API } from '../constants/url.constants';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UploadFileService {
  public API = API;
  public UPLOAD_API = `${this.API}/cursusinstantie/upload`;

  constructor(private http: HttpClient) { }

  upload(formData: FormData): Observable<any> {
    return this.http.post(this.UPLOAD_API, formData);
  }
}