import { ChangeDetectorRef, Component, OnInit, ChangeDetectionStrategy } from "@angular/core";
import { ToastrService } from "ngx-toastr";
import { ComputerService } from "src/app/core/service/computer.service";
import { CaseSizes } from "src/app/shared/models/case.model";
import { computerView } from "src/app/shared/models/computer.model";

@Component({
  selector: 'app-computer-list',
  templateUrl: './computer-list.component.html',
  styleUrls: ['./computer-list.component.scss'],
  changeDetection: ChangeDetectionStrategy.Eager,
  standalone: false
})
export class ComputerListComponent implements OnInit {
  computerList: computerView[] = [];
  isDataLoaded = false;
  constructor(
    public _computerService: ComputerService,
    private cdr: ChangeDetectorRef,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this._computerService.getViews().subscribe(
      (list: computerView[]) => {
        this.computerList = list;
        this.isDataLoaded = true;
        this.cdr.detectChanges();
      },
      (error) => {
        this.toastr.error('Error fetching Computers', 'Server Error');
      }
    );
  }
}

function getCaseSizeNames(enumValues: number[]): string[] {
  return enumValues.map((enumValue) => {
    const keys = Object.keys(CaseSizes).filter((x) => CaseSizes[x as keyof typeof CaseSizes] === enumValue);
    return keys[0];
  });
}
