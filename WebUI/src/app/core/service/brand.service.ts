import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { addBrand, brand } from "src/app/shared/models/brand.model";
import { environment } from "src/environments/environment";


@Injectable({
    providedIn: 'root'
})
export class BrandService {

    constructor(private http: HttpClient) {}

    getBrands(): Observable<brand[]> {
      return this.http.get<brand[]>(`${environment.apiUrl}Brand`);
    }

    getBrand(id: number): Observable<brand> {
      return this.http.get<brand>(`${environment.apiUrl}Brand/` + id);
    }

    addBrand(brand: addBrand): Observable<addBrand> {
      return this.http.post<brand>(`${environment.apiUrl}Brand/add`, brand);
    }

    updateBrand(brand: brand): Observable<brand> {
      return this.http.put<brand>(`${environment.apiUrl}Brand/update`, brand);
    }

    deleteBrand(id: number): Observable<Object> {
      console.log("work");
      return this.http.delete(`${environment.apiUrl}Brand/delete/` + id);
    }
}
