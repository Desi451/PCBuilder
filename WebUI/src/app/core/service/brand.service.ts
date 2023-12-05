import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { brand } from "src/app/shared/models/brand.model";
import { environment } from "src/environments/environment";


@Injectable({
    providedIn: 'root'
})
export class BrandService {

  constructor(private http: HttpClient) {}

  getBrands(): Observable<brand[]> {
    return this.http.get<brand[]>(`${environment.apiUrl}Brand`);
  }
}
