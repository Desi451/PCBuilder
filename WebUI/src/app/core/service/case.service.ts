import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { addCase, casePc } from "src/app/shared/models/case.model";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: 'root'
})
export class CaseService {
  constructor(private http: HttpClient) { }

  getCases(): Observable<casePc[]> {
    return this.http.get<casePc[]>(`${environment.apiUrl}Case`);
  }

  getCase(id: number): Observable<casePc> {
    return this.http.get<casePc>(`${environment.apiUrl}Case/` + id);
  }

  addCase(brand: addCase): Observable<addCase> {
    return this.http.post<casePc>(`${environment.apiUrl}Case/add`, brand);
  }

  updateCase(brand: casePc): Observable<casePc> {
    return this.http.put<casePc>(`${environment.apiUrl}Case/update`, brand);
  }

  deleteCases(id: number): Observable<Object> {
    return this.http.delete(`${environment.apiUrl}Case/delete/` + id);
  }
}
