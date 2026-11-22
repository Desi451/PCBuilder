import { HttpErrorResponse, HttpInterceptorFn } from "@angular/common/http";
import { inject } from "@angular/core";
import { Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { catchError, EMPTY, throwError } from "rxjs";

import { createLoginUrlTree } from "./auth.guards";
import { AuthStore } from "./auth.store";

const sessionEndpoints: readonly string[] = ['Auth/login', 'Auth/logout', 'Auth/getUserInfo'];

export const errorInterceptor: HttpInterceptorFn = (req, next) => {
  const authStore = inject(AuthStore);
  const router = inject(Router);
  const toastr = inject(ToastrService);
  const isSessionRequest = sessionEndpoints.some(endpoint => req.url.endsWith(endpoint));

  return next(req).pipe(
    catchError((error: HttpErrorResponse) => {
      if (error.status === 401 && !isSessionRequest) {
        if (authStore.isAuthenticated()) {
          authStore.clear();
          toastr.warning('Session expired', 'Authentication');
          router.navigateByUrl(createLoginUrlTree(router));
        }
        return EMPTY;
      }

      if (error.status === 403) {
        toastr.error('No permission to perform this action', 'Access denied');
      } else if (error.status === 0) {
        toastr.error('Server unreachable', 'Connection');
      }

      return throwError(() => error);
    })
  );
};
