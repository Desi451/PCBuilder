import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { addSlot, slot } from "src/app/shared/models/slot.model";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: 'root'
})
export class SlotService {

  constructor(private http: HttpClient) { }

  getSlots(): Observable<slot[]> {
    return this.http.get<slot[]>(`${environment.apiUrl}Slot`);
  }

  getSlot(id: number): Observable<slot> {
    return this.http.get<slot>(`${environment.apiUrl}Slot/` + id);
  }

  add(brand: addSlot): Observable<addSlot> {
    return this.http.post<slot>(`${environment.apiUrl}Slot/add`, brand);
  }

  update(brand: slot): Observable<slot> {
    return this.http.put<slot>(`${environment.apiUrl}Slot/update`, brand);
  }

  delete(id: number): Observable<Object> {
    return this.http.delete(`${environment.apiUrl}Slot/delete/` + id);
  }
}
