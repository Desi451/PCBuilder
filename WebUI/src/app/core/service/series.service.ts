import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { addSeries, series } from "src/app/shared/models/series.model";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: 'root'
})
export class SeriesService {

  constructor(private http: HttpClient) { }

  getSeries(): Observable<series[]> {
    return this.http.get<series[]>(`${environment.apiUrl}Series`);
  }

  getSeriesById(id: number): Observable<series> {
    return this.http.get<series>(`${environment.apiUrl}Series/` + id);
  }

  getSeriesByBrand(id: number): Observable<series[]> {
    return this.http.get<series[]>(`${environment.apiUrl}Series/brandId/` + id);
  }

  addSeries(brand: addSeries): Observable<addSeries> {
    return this.http.post<series>(`${environment.apiUrl}Series/add`, brand);
  }

  updateBrand(brand: series): Observable<series> {
    return this.http.put<series>(`${environment.apiUrl}Series/update`, brand);
  }

  deleteBrand(id: number): Observable<Object> {
    return this.http.delete(`${environment.apiUrl}Series/delete/` + id);
  }
}
