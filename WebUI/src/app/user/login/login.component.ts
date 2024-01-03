import { Component } from "@angular/core";
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { AuthService } from "src/app/core/auth/auth.service";
import { login } from "src/app/shared/models/user.model";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  standalone: true,
  imports: [ReactiveFormsModule, FormsModule]
})
export class LoginComponent {
  loginForm!: FormGroup;

  constructor(
    private _route: ActivatedRoute,
    private _router: Router,
    private formBuilder: FormBuilder,
    private toastr: ToastrService,
    private _authService: AuthService
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
      this._authService.login(log).subscribe(

        (res: boolean) => {
          this.toastr.success('Logged in Successfully!', 'Login');
        },
        (error) => {
          this.toastr.error('Error fetching user', 'Server Error');
        }
      );
    }
    else{
      this.toastr.error('Data not valid');
    }
  }


}
