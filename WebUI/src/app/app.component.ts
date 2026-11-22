import { Component, ChangeDetectionStrategy } from "@angular/core";
import { Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";

import { AuthService } from "./core/auth/auth.service";
import { AuthStore } from "./core/auth/auth.store";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  changeDetection: ChangeDetectionStrategy.Eager,
  standalone: false
})
export class AppComponent {

  constructor(
    public authStore: AuthStore,
    private _authService: AuthService,
    private _router: Router,
    private toastr: ToastrService
  ) { }

  logout() {
    this._authService.logout().subscribe({
      next: response => {
        this.toastr.success(response);
        this.finishLogout();
      },
      error: () => this.finishLogout()
    });
  }

  isOffcanvasOpen = false;

  title = 'PCBuilder';

  closeOffcanvas() {
    this.isOffcanvasOpen = false;
  }

  private finishLogout() {
    this.authStore.clear();
    this._router.navigateByUrl('/login');
  }
}
