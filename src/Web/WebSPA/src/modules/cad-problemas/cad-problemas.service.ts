import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { HttpService} from '../shared/http.service';

@Injectable({
  providedIn: 'root'
})
export class CadProblemasService {

  private baseUrl = 'http://localhost:5109/api/v1/Problemas/CadProblema';

  constructor(private http: HttpClient, private httpData: HttpService) { }


  getCadProblema(codigo: string): Observable<any> {
    return this.httpData.get(`${this.baseUrl}/${codigo}`);
  }

  createCadProblema(cadProblema: object): Observable<object> {
    return this.httpData.post(`${this.baseUrl}`, cadProblema);
  }

  updateCadProblema(codigo: string, value: any): Observable<object> {
    return this.httpData.put(`${this.baseUrl}/${codigo}`, value );
  }

  getCadProblemas(): Observable<any> {
    return this.httpData.get (`${this.baseUrl}`); // 'https://localhost:5109');
  }
}
