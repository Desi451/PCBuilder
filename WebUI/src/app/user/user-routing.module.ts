import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { EditProfileComponent } from "./edit-profile/edit-profile.component";
import { LoginComponent } from "./login/login.component";
import { RegisterComponent } from "./register/register.component";
import { ResetPasswordComponent } from "./reset-password/reset-password.component";

const routes: Routes = [
  {
      path: 'login',
      component: LoginComponent
  },
  {
    path: 'register',
    component: RegisterComponent
  },
  {
    path: 'resetpass',
    component: ResetPasswordComponent
  },
  {
    path: 'editprofile',
    component: EditProfileComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
