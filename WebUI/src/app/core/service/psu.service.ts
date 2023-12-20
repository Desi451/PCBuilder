import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { psu } from "src/app/shared/models/psu.model";
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

  // addBrand(brand: addBrand): Observable<addBrand> {
  //   return this.http.post<brand>(`${environment.apiUrl}Cpu/add`, brand);
  // }

  // updateBrand(brand: brand): Observable<brand> {
  //   return this.http.put<brand>(`${environment.apiUrl}Cpu/update`, brand);
  // }

  // deleteBrand(id: number): Observable<Object> {
  //   return this.http.delete(`${environment.apiUrl}Cpu/delete/` + id);
  //}
}
