import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { authGuard, guestGuard } from "src/app/core/auth/auth.guards";

import { EditProfileComponent } from "./edit-profile/edit-profile.component";
import { LoginComponent } from "./login/login.component";
import { RegisterComponent } from "./register/register.component";

const routes: Routes = [
  {
      path: 'login',
      canActivate: [guestGuard],
      component: LoginComponent
  },
  {
    path: 'register',
    canActivate: [guestGuard],
    component: RegisterComponent
  },
  {
    path: 'profile',
    canActivate: [authGuard],
    component: EditProfileComponent
  },
  {
    path: 'editprofile/:id',
    redirectTo: 'profile'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
