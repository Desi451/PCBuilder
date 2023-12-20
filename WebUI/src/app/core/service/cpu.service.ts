import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { cpu } from "src/app/shared/models/cpu.model";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: 'root'
})
export class CpuService {
  constructor(private http: HttpClient) { }

  getCpus(): Observable<cpu[]> {
    return this.http.get<cpu[]>(`${environment.apiUrl}Cpu`);
  }

  getCpu(id: number): Observable<cpu> {
    return this.http.get<cpu>(`${environment.apiUrl}Cpu/` + id);
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
