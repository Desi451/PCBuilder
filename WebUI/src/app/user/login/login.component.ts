import { Component } from "@angular/core";
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
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
    console.log(this.loginForm.value.login);
    console.log(this.loginForm.value.password);
    if(this.loginForm.valid){
      const log = this.loginForm.value as login;
      this._authService.login(log).subscribe(

        (res: boolean) => {
          console.log(res);
        },
        (error) => {
          console.error('Error fetching user:', error);
        }
      );
    }
    else{
      console.error("Data not valid");
    }
  }


}
