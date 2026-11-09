import { Component, OnInit, ChangeDetectionStrategy } from "@angular/core";
import { ToastrService } from "ngx-toastr";

import { AuthService } from "./core/auth/auth.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  changeDetection: ChangeDetectionStrategy.Eager,
  standalone: false
})
export class AppComponent implements OnInit {

  userId: number = 0;
  username: string = '';
  userRank: number = 0;

  constructor(
    private _authService: AuthService,
    private toastr: ToastrService
  ) { }

  ngOnInit() {
    this.refreshUserInfo();
  }

  logout() {
    this._authService.logout().subscribe(response => {
      this.toastr.success(response);

      this.userId = 0;
      this.username = '';
      this.userRank = 0;
    });
  }

  refreshUserInfo() {
    this._authService.getUserInfo().subscribe(response => {
      console.log(response);
      if (response.userId) {
        this.userId = response.userId;
        this.username = response.username;
        this.userRank = response.userRank;
      }
    });
  }

  isOffcanvasOpen = false;

  title = 'PCBuilder';

  closeOffcanvas() {
    this.isOffcanvasOpen = false;
  }

  deleteCookie(name: string) {
    document.cookie = name + '=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;';
  }
}
