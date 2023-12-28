import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { addRam, addRamSpeed, ram, ramSpeed } from "src/app/shared/models/ram.model";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: 'root'
})
export class RamService {
  constructor(private http: HttpClient) { }

  getRams(): Observable<ram[]> {
    return this.http.get<ram[]>(`${environment.apiUrl}Ram`);
  }

  getRam(id: number): Observable<ram> {
    return this.http.get<ram>(`${environment.apiUrl}Ram/` + id);
  }

  add(res: addRam): Observable<addRam> {
    return this.http.post<addRam>(`${environment.apiUrl}Ram/add`, res);
  }

  update(res: ram): Observable<ram> {
    return this.http.put<ram>(`${environment.apiUrl}Ram/update`, res);
  }

  delete(id: number): Observable<Object> {
    return this.http.delete(`${environment.apiUrl}Ram/delete/` + id);
  }

  getSpeeds(): Observable<ramSpeed[]> {
    return this.http.get<ramSpeed[]>(`${environment.apiUrl}Ram/speed`);
  }

  getSpeed(id: number): Observable<ramSpeed> {
    return this.http.get<ramSpeed>(`${environment.apiUrl}Ram/speed/` + id);
  }

  addSpeed(res: addRam): Observable<addRamSpeed> {
    return this.http.post<addRamSpeed>(`${environment.apiUrl}Ram/addspeed`, res);
  }

  updateSpeed(res: ram): Observable<ramSpeed> {
    return this.http.put<ramSpeed>(`${environment.apiUrl}Ram/updatespeed`, res);
  }

  deleteSpeed(id: number): Observable<Object> {
    return this.http.delete(`${environment.apiUrl}Ram/deletespeed/` + id);
  }
}
