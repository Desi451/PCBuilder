import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { addGpu, gpu } from "src/app/shared/models/gpu.model";
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

  add(res: addGpu): Observable<addGpu> {
    return this.http.post<addGpu>(`${environment.apiUrl}Gpu/add`, res);
  }

  update(res: gpu): Observable<gpu> {
    return this.http.put<gpu>(`${environment.apiUrl}Gpu/update`, res);
  }

  delete(id: number): Observable<Object> {
    return this.http.delete(`${environment.apiUrl}Gpu/delete/` + id);
  }
}
