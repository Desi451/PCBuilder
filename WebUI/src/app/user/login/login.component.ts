import { Component, OnInit } from "@angular/core";
import { FormGroup, FormsModule, ReactiveFormsModule } from "@angular/forms";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  standalone: true,
  imports: [ReactiveFormsModule, FormsModule]
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;

  ngOnInit(): void {
    throw new Error("Method not implemented.");
  }



  executeForm() {

  }


}
