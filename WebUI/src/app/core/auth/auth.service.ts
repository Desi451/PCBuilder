import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { addUser, login, user } from "src/app/shared/models/user.model";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  login(res: login): Observable<user> {
    return this.http.post<user>(`${environment.apiUrl}Auth/login`, res , { withCredentials: true });
  }

  getUserInfo(): Observable<any> {
    return this.http.get(`${environment.apiUrl}Auth/getUserInfo`, { withCredentials: true });
  }

  register(res: addUser): Observable<boolean> {
    return this.http.post<boolean>(`${environment.apiUrl}Auth/register`, res);
  }

  logout(): Observable<any> {
    return this.http.post(`${environment.apiUrl}Auth/logout`, {}, { responseType: 'text' });
  }

  update(res: addUser, id: number): Observable<boolean> {
    return this.http.patch<boolean>(`${environment.apiUrl}Auth/edit/` + id, res);
  }

  getUser(id: number): Observable<user> {
    return this.http.get<user>(`${environment.apiUrl}User/` + id);
  }

  confirmMail(res: number): Observable<boolean> {
    return this.http.post<boolean>(`${environment.apiUrl}Auth/edit`, res);
  }
}
