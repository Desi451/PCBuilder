import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { brand } from "src/app/shared/models/brand.model";
import { casePc } from "src/app/shared/models/case.model";
import { addComputer, caseRequest, computer, computerForm, computerView } from "src/app/shared/models/computer.model";
import { cpu } from "src/app/shared/models/cpu.model";
import { mobo } from "src/app/shared/models/mobo.model";
import { psu } from "src/app/shared/models/psu.model";
import { ram } from "src/app/shared/models/ram.model";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: 'root'
})
export class ComputerService {
  constructor(private http: HttpClient) { }

  getComputers(): Observable<computer[]> {
    return this.http.get<computer[]>(`${environment.apiUrl}Computer`);
  }

  get(id: number): Observable<computer> {
    return this.http.get<computer>(`${environment.apiUrl}Computer/` + id);
  }

  getFullData(id: number): Observable<computerForm> {
    return this.http.get<computerForm>(`${environment.apiUrl}Computer/fulldata/` + id);
  }

  getViews(): Observable<computerView[]> {
    return this.http.get<computerView[]>(`${environment.apiUrl}Computer/views`);
  }

  getViewsByUser(id: number): Observable<computerView[]> {
    return this.http.get<computerView[]>(`${environment.apiUrl}Computer/views/` + id);
  }


  add(brand: addComputer): Observable<addComputer> {
    return this.http.post<addComputer>(`${environment.apiUrl}Computer/add`, brand);
  }

  update(brand: computer): Observable<computer> {
    return this.http.put<computer>(`${environment.apiUrl}Computer/update`, brand);
  }

  delete(id: number): Observable<Object> {
    return this.http.delete(`${environment.apiUrl}Computer/delete/` + id);
  }

  //building pc
  getCpuBrands(): Observable<brand[]> {
    return this.http.get<brand[]>(`${environment.apiUrl}Computer/cpubrands`);
  }

  getCpus(id: number): Observable<cpu[]> {
    return this.http.get<cpu[]>(`${environment.apiUrl}Computer/cpus/` + id);
  }

  getMotherboards(id: number): Observable<mobo[]> {
    return this.http.get<mobo[]>(`${environment.apiUrl}Computer/motherboards/` + id);
  }

  getRams(id: number): Observable<ram[]> {
    return this.http.get<ram[]>(`${environment.apiUrl}Computer/rams/` + id);
  }

  getPsus(cpuId: number, gpuId?: number | null): Observable<psu[]> {
    const query = gpuId ? `?gpuId=${gpuId}` : '';
    return this.http.get<psu[]>(`${environment.apiUrl}Computer/psus/` + cpuId + query);
  }

  getCases(req: caseRequest): Observable<casePc[]> {
    return this.http.post<casePc[]>(`${environment.apiUrl}Computer/cases`, req);
  }
}
