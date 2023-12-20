import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { mobo } from "src/app/shared/models/mobo.model";
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

  // addBrand(brand: addBrand): Observable<addBrand> {
  //   return this.http.post<brand>(`${environment.apiUrl}Brand/add`, brand);
  // }

  // updateBrand(brand: brand): Observable<brand> {
  //   return this.http.put<brand>(`${environment.apiUrl}Brand/update`, brand);
  // }

  // deleteBrand(id: number): Observable<Object> {
  //   return this.http.delete(`${environment.apiUrl}Brand/delete/` + id);
  //}
}
