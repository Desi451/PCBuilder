import { Component } from "@angular/core";
import { environment } from "src/environments/environment";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  constructor() {
    console.log(environment.production); // Logs false for development environment
  }

  isOffcanvasOpen = true;

  title = 'PCBuilder';

  closeOffcanvas() {
    this.isOffcanvasOpen = false;
  }
}
