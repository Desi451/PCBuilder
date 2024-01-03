import { Component } from "@angular/core";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  constructor() {
    
  }

  isOffcanvasOpen = false;

  title = 'PCBuilder';

  closeOffcanvas() {
    this.isOffcanvasOpen = false;
  }
}
