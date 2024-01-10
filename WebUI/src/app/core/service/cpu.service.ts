import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { addCpu, addSocketCpu, cpu, socketCpu } from "src/app/shared/models/cpu.model";
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

  add(res: addCpu): Observable<addCpu> {
    return this.http.post<any>(`${environment.apiUrl}Cpu/add`, res);
  }

  update(res: cpu): Observable<cpu> {
    return this.http.put<cpu>(`${environment.apiUrl}Cpu/update`, res);
  }

  delete(id: number): Observable<Object> {
    return this.http.delete(`${environment.apiUrl}Cpu/delete/` + id);
  }

  getCpuSockets(): Observable<socketCpu[]> {
    return this.http.get<socketCpu[]>(`${environment.apiUrl}Cpu/sockets`);
  }

  getCpuSocketsByBrand(id: number): Observable<socketCpu[]> {
    return this.http.get<socketCpu[]>(`${environment.apiUrl}Cpu/socketsbrand/` + id);
  }

  getCpuSocket(id: number): Observable<socketCpu> {
    return this.http.get<socketCpu>(`${environment.apiUrl}Cpu/sockets/` + id);
  }

  addSocket(res: addSocketCpu): Observable<addSocketCpu> {
    return this.http.post<addSocketCpu>(`${environment.apiUrl}Cpu/addsocket`, res);
  }

  updateSocket(res: socketCpu): Observable<socketCpu> {
    return this.http.put<socketCpu>(`${environment.apiUrl}Cpu/updatesocket`, res);
  }

  deleteSocket(id: number): Observable<Object> {
    return this.http.delete(`${environment.apiUrl}Cpu/delete/sockets/` + id);
  }
}
