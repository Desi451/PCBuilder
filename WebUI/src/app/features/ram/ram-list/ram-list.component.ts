import { ChangeDetectorRef, Component, OnInit } from "@angular/core";
import { RamService } from "src/app/core/service/ram.service";
import { ram } from "src/app/shared/models/ram.model";

@Component({
  selector: 'app-ram-list',
  templateUrl: './ram-list.component.html',
  styleUrls: ['./ram-list.component.scss']
})
export class RamListComponent implements OnInit {
  list: ram[] = [];
  isDataLoaded = false;
  constructor(
    public _ramService: RamService,
    private cdr: ChangeDetectorRef // Inject ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    this._ramService.getRams().subscribe(
      (brands: ram[]) => {
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
