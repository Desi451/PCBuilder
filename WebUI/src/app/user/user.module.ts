import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { NgbCollapseModule, NgbDropdownModule } from "@ng-bootstrap/ng-bootstrap";

import { SharedModule } from "../shared/shared.module";
import { EditProfileComponent } from "./edit-profile/edit-profile.component";
import { LoginComponent } from "./login/login.component";
import { RegisterComponent } from "./register/register.component";
import { UserRoutingModule } from "./user-routing.module";

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    UserRoutingModule,
    NgbCollapseModule,
    NgbDropdownModule,
    ReactiveFormsModule,
    FormsModule
  ],
  declarations: [
    EditProfileComponent,
    LoginComponent,
    RegisterComponent
  ]
})
export class UserModule { }
