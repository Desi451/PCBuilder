import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { addUser, login } from "src/app/shared/models/user.model";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  login(res: login): Observable<boolean> {
    return this.http.post<boolean>(`${environment.apiUrl}Auth/login`, res);
  }

  register(res: addUser): Observable<boolean> {
    return this.http.post<boolean>(`${environment.apiUrl}Auth/register`, res);
  }

  confirmMail(res: number): Observable<boolean> {
    return this.http.post<boolean>(`${environment.apiUrl}Auth/confirmMail`, res);
  }
}
