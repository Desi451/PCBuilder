import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { catchError, map, Observable, of, throwError } from "rxjs";
import { addUser, login, sessionInfo, updateUser, userInfo } from "src/app/shared/models/user.model";
import { environment } from "src/environments/environment";

const anonymousSession: sessionInfo = {
  userId: 0,
  username: '',
  email: '',
  userRank: 0
};

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  login(res: login): Observable<userInfo> {
    return this.http.post<userInfo>(`${environment.apiUrl}Auth/login`, res, { withCredentials: true });
  }

  getUserInfo(): Observable<sessionInfo> {
    return this.http.get<userInfo>(`${environment.apiUrl}Auth/getUserInfo`, { withCredentials: true }).pipe(
      map((res: userInfo): sessionInfo => ({
        userId: res.id,
        username: res.login,
        email: res.email,
        userRank: res.userRank
      })),
      catchError((error: HttpErrorResponse) => error.status === 401 ? of(anonymousSession) : throwError(() => error))
    );
  }

  register(res: addUser): Observable<void> {
    return this.http.post<void>(`${environment.apiUrl}Auth/register`, res, { withCredentials: true });
  }

  logout(): Observable<string> {
    return this.http.post(`${environment.apiUrl}Auth/logout`, {}, { responseType: 'text', withCredentials: true });
  }

  update(res: updateUser): Observable<userInfo> {
    return this.http.patch<userInfo>(`${environment.apiUrl}Auth/edit`, res, { withCredentials: true });
  }
}
