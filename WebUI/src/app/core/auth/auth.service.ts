import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { addUser, login, updateUser, userInfo } from "src/app/shared/models/user.model";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  login(res: login): Observable<userInfo> {
    return this.http.post<userInfo>(`${environment.apiUrl}Auth/login`, res);
  }

  getUserInfo(): Observable<userInfo> {
    return this.http.get<userInfo>(`${environment.apiUrl}Auth/getUserInfo`);
  }

  register(res: addUser): Observable<void> {
    return this.http.post<void>(`${environment.apiUrl}Auth/register`, res);
  }

  logout(): Observable<string> {
    return this.http.post(`${environment.apiUrl}Auth/logout`, {}, { responseType: 'text' });
  }

  update(res: updateUser): Observable<userInfo> {
    return this.http.patch<userInfo>(`${environment.apiUrl}Auth/edit`, res);
  }
}
