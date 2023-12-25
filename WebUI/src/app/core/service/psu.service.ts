import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { addPsu, psu } from "src/app/shared/models/psu.model";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: 'root'
})
export class PsuService {
  constructor(private http: HttpClient) { }

  getCpus(): Observable<psu[]> {
    return this.http.get<psu[]>(`${environment.apiUrl}PowerSupply`);
  }

  getCpu(id: number): Observable<psu> {
    return this.http.get<psu>(`${environment.apiUrl}PowerSupply/` + id);
  }

  add(res: addPsu): Observable<addPsu> {
    return this.http.post<addPsu>(`${environment.apiUrl}PowerSupply/add`, res);
  }

  update(res: psu): Observable<psu> {
    return this.http.put<psu>(`${environment.apiUrl}PowerSupply/update`, res);
  }

  delete(id: number): Observable<Object> {
    return this.http.delete(`${environment.apiUrl}PowerSupply/delete/` + id);
  }
}
