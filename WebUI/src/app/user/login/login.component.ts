import { HttpErrorResponse } from "@angular/common/http";
import { Component, ChangeDetectionStrategy } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { AuthService } from "src/app/core/auth/auth.service";
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
          this.toastr.success('Logged in Successfully!', 'Login');
          this._router.navigateByUrl(``);
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
}
