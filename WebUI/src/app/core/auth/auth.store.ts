import { HttpErrorResponse } from "@angular/common/http";
import { computed, Injectable, signal } from "@angular/core";
import { ToastrService } from "ngx-toastr";
import { catchError, map, Observable, of } from "rxjs";
import { sessionInfo, userInfo } from "src/app/shared/models/user.model";

import { AuthService } from "./auth.service";

const adminRoles: readonly string[] = ['Admin', 'HeadAdmin'];

@Injectable({
  providedIn: 'root'
})
export class AuthStore {

  private readonly _session = signal<sessionInfo | null>(null);

  readonly session = this._session.asReadonly();
  readonly isAuthenticated = computed(() => this._session() !== null);
  readonly isAdmin = computed(() => adminRoles.includes(this._session()?.role ?? ''));
  readonly userId = computed(() => this._session()?.userId ?? 0);
  readonly username = computed(() => this._session()?.username ?? '');

  constructor(
    private _authService: AuthService,
    private toastr: ToastrService
  ) { }

  init(): Observable<void> {
    return this._authService.getUserInfo().pipe(
      map((info: userInfo) => this.setSession(info)),
      catchError((error: HttpErrorResponse) => {
        this.clear();
        if (error.status !== 401 && error.status !== 0) {
          this.toastr.error('Could not load the session.', 'Server Error');
        }
        return of(undefined);
      })
    );
  }

  setSession(info: userInfo): void {
    this._session.set({
      userId: info.id,
      username: info.login,
      email: info.email,
      role: info.role
    });
  }

  clear(): void {
    this._session.set(null);
  }
}
