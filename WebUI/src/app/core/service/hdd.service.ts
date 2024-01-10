import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { addHdd, hdd } from "src/app/shared/models/hdd.model";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: 'root'
})
export class HddService {

  constructor(private http: HttpClient) { }

  getHdds(): Observable<hdd[]> {
    return this.http.get<hdd[]>(`${environment.apiUrl}Hdd`);
  }

  getHdd(id: number): Observable<hdd> {
    return this.http.get<hdd>(`${environment.apiUrl}Hdd/` + id);
  }

  add(res: addHdd): Observable<addHdd> {
    return this.http.post<addHdd>(`${environment.apiUrl}Hdd/add`, res);
  }

  update(res: hdd): Observable<hdd> {
    return this.http.put<hdd>(`${environment.apiUrl}Hdd/update`, res);
  }

  delete(id: number): Observable<Object> {
    return this.http.delete(`${environment.apiUrl}Hdd/delete/` + id);
  }
}
