import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { gpu } from "src/app/shared/models/gpu.model";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: 'root'
})
export class GpuService {
  constructor(private http: HttpClient) { }

  getGpus(): Observable<gpu[]> {
    return this.http.get<gpu[]>(`${environment.apiUrl}Gpu`);
  }

  getGpu(id: number): Observable<gpu> {
    return this.http.get<gpu>(`${environment.apiUrl}Gpu/` + id);
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
