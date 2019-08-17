import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { HttpService} from '../shared/http.service';

@Injectable({
  providedIn: 'root'
})
export class CadAtivService {

  private baseUrl = 'http://localhost:5109/api/v1/Ativ/CadAtiv';

  constructor(private http: HttpClient, private httpData: HttpService) { }


  getCadAtiv(codigo: string): Observable<any> {
    return this.httpData.get(`${this.baseUrl}/${codigo}`);
  }

  createCadAtiv(cad: object): Observable<object> {
    return this.httpData.post(`${this.baseUrl}`, cad);
  }

  updateCadAtiv(codigo: string, value: any): Observable<object> {
    return this.httpData.put(`${this.baseUrl}/${codigo}`, value );
  }

  getCadAtivs(): Observable<any> {
    return this.httpData.get (`${this.baseUrl}`);
  }
}
