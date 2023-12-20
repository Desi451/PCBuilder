import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ram } from "src/app/shared/models/ram.model";
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
