import { inject } from "@angular/core";
import { CanActivateFn, CanMatchFn, Router, UrlTree } from "@angular/router";
import { ToastrService } from "ngx-toastr";

import { AuthStore } from "./auth.store";

export function createLoginUrlTree(router: Router): UrlTree {
  const navigation = router.currentNavigation();
  const target = navigation?.finalUrl ?? navigation?.extractedUrl;
  const returnUrl = target ? router.serializeUrl(target) : router.url;

  return router.createUrlTree(['/login'], { queryParams: { returnUrl } });
}

export const authGuard: CanActivateFn & CanMatchFn = () => {
  const router = inject(Router);

  return inject(AuthStore).isAuthenticated() || createLoginUrlTree(router);
};

export const adminGuard: CanActivateFn & CanMatchFn = () => {
  const authStore = inject(AuthStore);
  const router = inject(Router);

  if (!authStore.isAuthenticated()) {
    return createLoginUrlTree(router);
  }

  if (authStore.isAdmin()) {
    return true;
  }

  inject(ToastrService).error('No permission', 'Access denied');
  return router.parseUrl('/');
};

export const guestGuard: CanActivateFn = () => {
  const router = inject(Router);

  return !inject(AuthStore).isAuthenticated() || router.parseUrl('/');
};
