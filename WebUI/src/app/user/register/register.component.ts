import { HttpErrorResponse } from "@angular/common/http";
import { Component, ChangeDetectionStrategy } from "@angular/core";
import { AbstractControl, FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { AuthService } from "src/app/core/auth/auth.service";
import { addUser } from "src/app/shared/models/user.model";
import { getProblemMessage } from "src/app/shared/utils/problem-details";
import { passwordPolicyHint, passwordPolicyValidator } from "src/app/shared/validators/password.validator";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
  changeDetection: ChangeDetectionStrategy.Eager,
  standalone: false
})
export class RegisterComponent {

  readonly passwordHint = passwordPolicyHint;

  constructor(
    private _route: ActivatedRoute,
    private _router: Router,
    private formBuilder: FormBuilder,
    private toastr: ToastrService,
    private _authService: AuthService,
  ) {
    this.initForm();
  }

  registrationForm!: FormGroup;

  initForm() {
    this.registrationForm = this.formBuilder.group({
      login: ['', [Validators.required, Validators.maxLength(256), Validators.pattern(/^[A-Za-z0-9._-]+$/)]],
      email: ['', [Validators.required, Validators.email, Validators.maxLength(256)]],
      password: ['', [Validators.required, passwordPolicyValidator]],
      confirmPassword: ['', Validators.required],
    }, { validator: this.passwordMatchValidator });
  }

  executeRegistrationForm() {
    if(this.registrationForm.valid){
      const { login, email, password } = this.registrationForm.value;
      const res: addUser = { login, email, password };
      this._authService.register(res).subscribe({
        next: () => {
          this.toastr.success('Registred Successfully!', 'Registration');
          this._router.navigateByUrl(`login`);
        },
        error: (error: HttpErrorResponse) => {
          this.toastr.error(getProblemMessage(error, 'Registration failed.'), 'Registration');
        }
      });
    }else{
      this.toastr.error('Data not valid');
    }
  }

  passwordMatchValidator(control: AbstractControl): { [key: string]: boolean } | null {
    const password = control.get('password')?.value;
    const confirmPassword = control.get('confirmPassword')?.value;

    return password === confirmPassword ? null : { 'passwordMismatch': true };
  }

}
