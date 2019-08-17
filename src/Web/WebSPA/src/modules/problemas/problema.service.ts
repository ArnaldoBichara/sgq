import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { HttpService} from '../shared/http.service';

@Injectable({
  providedIn: 'root'
})
export class ProblemaService {

  private baseUrl = 'http://localhost:5109/api/v1/RegProblema';

  constructor(private http: HttpClient, private httpData: HttpService) { }


  getProblema(Id: number): Observable<any> {
    return this.httpData.get(`${this.baseUrl}/${Id}`);
  }

  createProblema(problema: Object): Observable<Object> {
    return this.httpData.post(`${this.baseUrl}`, problema);
  }

  updateProblema(id: number, value: any): Observable<Object> {
    return this.httpData.put(`${this.baseUrl}/${id}`, value );
  }

  getProblemas(): Observable<any> {
    return this.httpData.get (`${this.baseUrl}`); 
  }
}
