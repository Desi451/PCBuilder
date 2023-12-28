import { ChangeDetectorRef, Component, OnInit } from "@angular/core";
import { RamService } from "src/app/core/service/ram.service";
import { ram, ramSpeed } from "src/app/shared/models/ram.model";

@Component({
  selector: 'app-ram-list',
  templateUrl: './ram-list.component.html',
  styleUrls: ['./ram-list.component.scss']
})
export class RamListComponent implements OnInit {
  list: ram[] = [];
  speedList: ramSpeed[] = [];
  isDataLoaded = false;
  isSpeedLoaded = false
  constructor(
    public _ramService: RamService,
    private cdr: ChangeDetectorRef // Inject ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    this._ramService.getSpeeds().subscribe(
      (speeds: ramSpeed[]) => {
        this.speedList = speeds;
        this.isDataLoaded = true;
        this.cdr.detectChanges();
      },
      (error) => {
        console.error('Error fetching RAM speeds:', error);
      }
    );

    this._ramService.getRams().subscribe(
      (brands: ram[]) => {
        this.list = brands;
        this.isSpeedLoaded = true;
        this.cdr.detectChanges();
      },
      (error) => {
        console.error('Error fetching brands:', error);
      }
    );
  }
}
