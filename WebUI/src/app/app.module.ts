import { provideHttpClient, withInterceptorsFromDi, withXhr } from "@angular/common/http";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { ToastrModule } from "ngx-toastr";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { FeaturesModule } from "./features/features.module";
import { ComputerModule } from "./main/computer.module";
import { UserModule } from "./user/user.module";

@NgModule({ declarations: [
        AppComponent
    ],
    bootstrap: [AppComponent], imports: [BrowserModule,
        AppRoutingModule,
        FeaturesModule,
        UserModule,
        ToastrModule.forRoot(),
        BrowserAnimationsModule,
        ComputerModule,
        NgbModule,
        FormsModule], providers: [provideHttpClient(withXhr(), withInterceptorsFromDi())] })
export class AppModule { }
