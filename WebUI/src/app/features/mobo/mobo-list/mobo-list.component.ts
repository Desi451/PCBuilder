import { ChangeDetectorRef, Component, OnInit } from "@angular/core";
import { MoboService } from "src/app/core/service/mobo.service";
import { mobo } from "src/app/shared/models/mobo.model";

@Component({
  selector: 'app-mobo-list',
  templateUrl: './mobo-list.component.html',
  styleUrls: ['./mobo-list.component.scss']
})
export class MoboListComponent implements OnInit {
  list: mobo[] = [];
  isDataLoaded = false;
  constructor(
    public _moboService: MoboService,
    private cdr: ChangeDetectorRef // Inject ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    this._moboService.getMobos().subscribe(
      (brands: mobo[]) => {
        this.list = brands;
        this.isDataLoaded = true;
        console.log(this.list);
        this.cdr.detectChanges();
      },
      (error) => {
        console.error('Error fetching brands:', error);
      }
    );
  }
}
