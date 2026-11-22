import { HttpErrorResponse } from "@angular/common/http";
import { Component, ChangeDetectionStrategy } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { AuthService } from "src/app/core/auth/auth.service";
import { AuthStore } from "src/app/core/auth/auth.store";
import { login, userInfo } from "src/app/shared/models/user.model";
import { getProblemMessage } from "src/app/shared/utils/problem-details";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  changeDetection: ChangeDetectionStrategy.Eager,
  standalone: false
})
export class LoginComponent {
  loginForm!: FormGroup;

  constructor(
    private _route: ActivatedRoute,
    private _router: Router,
    private formBuilder: FormBuilder,
    private toastr: ToastrService,
    private _authService: AuthService,
    private _authStore: AuthStore,
  ) {
    this.initForm();
  }

  initForm() {
    this.loginForm = this.formBuilder.group({
      login: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  executeForm() {
    if(this.loginForm.valid){
      const log = this.loginForm.value as login;
      this._authService.login(log).subscribe({
        next: (res: userInfo) => {
          this._authStore.setSession(res);
          this.toastr.success('Logged in Successfully!', 'Login');
          this._router.navigateByUrl(this.getReturnUrl());
        },
        error: (error: HttpErrorResponse) => {
          this.toastr.error(getProblemMessage(error, 'Login failed.'), 'Login');
        }
      });
    }
    else{
      this.toastr.error('Data not valid');
    }
  }

  private getReturnUrl(): string {
    const returnUrl = this._route.snapshot.queryParamMap.get('returnUrl');

    return returnUrl && /^\/(?![\/\\])/.test(returnUrl) ? returnUrl : '/';
  }
}
