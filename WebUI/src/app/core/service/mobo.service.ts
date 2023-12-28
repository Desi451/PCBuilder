import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { addMobo, mobo } from "src/app/shared/models/mobo.model";
import { environment } from "src/environments/environment";


@Injectable({
  providedIn: 'root'
})
export class MoboService {

  constructor(private http: HttpClient) { }

  getMobos(): Observable<mobo[]> {
    return this.http.get<mobo[]>(`${environment.apiUrl}Motherboard`);
  }

  getMobo(id: number): Observable<mobo> {
    return this.http.get<mobo>(`${environment.apiUrl}Motherboard/` + id);
  }

  add(res: addMobo): Observable<addMobo> {
    console.log(res);
    return this.http.post<addMobo>(`${environment.apiUrl}Motherboard/add`, res);
  }

  update(res: mobo): Observable<mobo> {
    return this.http.put<mobo>(`${environment.apiUrl}Motherboard/update`, res);
  }

  delete(id: number): Observable<Object> {
    return this.http.delete(`${environment.apiUrl}Motherboard/delete/` + id);
  }
}
