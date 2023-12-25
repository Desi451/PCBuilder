import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { addSsd, ssd } from "src/app/shared/models/ssd.model";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: 'root'
})
export class SsdService {

  constructor(private http: HttpClient) { }

  getSsds(): Observable<ssd[]> {
    return this.http.get<ssd[]>(`${environment.apiUrl}Slot`);
  }

  getSsd(id: number): Observable<ssd> {
    return this.http.get<ssd>(`${environment.apiUrl}Slot/` + id);
  }

  add(res: addSsd): Observable<addSsd> {
    return this.http.post<addSsd>(`${environment.apiUrl}Slot/add`, res);
  }

  update(res: ssd): Observable<ssd> {
    return this.http.put<ssd>(`${environment.apiUrl}Slot/update`, res);
  }

  delete(id: number): Observable<Object> {
    return this.http.delete(`${environment.apiUrl}Slot/delete/` + id);
  }
}
