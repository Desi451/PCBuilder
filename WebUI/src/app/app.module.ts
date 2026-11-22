import { provideHttpClient, withInterceptors, withXhr } from "@angular/common/http";
import { inject, NgModule, provideAppInitializer } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { ToastrModule } from "ngx-toastr";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { AuthStore } from "./core/auth/auth.store";
import { errorInterceptor } from "./core/auth/error.interceptor";
import { FeaturesModule } from "./features/features.module";
import { ComputerModule } from "./main/computer.module";
import { UserModule } from "./user/user.module";

@NgModule({ declarations: [
        AppComponent
    ],
    bootstrap: [AppComponent], imports: [BrowserModule,
        FeaturesModule,
        UserModule,
        ToastrModule.forRoot({ preventDuplicates: true }),
        BrowserAnimationsModule,
        ComputerModule,
        FormsModule,
        AppRoutingModule], providers: [
        provideHttpClient(withXhr(), withInterceptors([errorInterceptor])),
        provideAppInitializer(() => inject(AuthStore).init())
    ] })
export class AppModule { }
