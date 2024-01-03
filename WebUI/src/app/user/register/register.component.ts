import { Component } from "@angular/core";
import { AbstractControl, FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { AuthService } from "src/app/core/auth/auth.service";
import { addUser } from "src/app/shared/models/user.model";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
  standalone: true,
  imports: [ReactiveFormsModule, FormsModule]
})
export class RegisterComponent {

  constructor(
    private _route: ActivatedRoute,
    private _router: Router,
    private formBuilder: FormBuilder,
    private toastr: ToastrService,
    private _authService: AuthService
  ) {
    this.initForm();
  }

  registrationForm!: FormGroup;

  initForm() {
    this.registrationForm = this.formBuilder.group({
      login: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
      confirmPassword: ['', Validators.required],
    }, { validator: this.passwordMatchValidator });
  }


  executeRegistrationForm() {
    if(this.registrationForm.valid){
      const res = this.registrationForm.value as addUser;
      this._authService.register(res).subscribe(
        (res: boolean) => {
          this.toastr.success('Registred Successfully!', 'Registration');
        },
        (error) => {
          this.toastr.success('Error fetching user', 'Registration');
        }
      );
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
