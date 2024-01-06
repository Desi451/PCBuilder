import { ChangeDetectorRef, Component, OnInit } from "@angular/core";
import { ToastrService } from "ngx-toastr";
import { ComputerService } from "src/app/core/service/computer.service";
import { computer } from "src/app/shared/models/computer.model";

@Component({
  selector: 'app-computer-list',
  templateUrl: './computer-list.component.html',
  styleUrls: ['./computer-list.component.scss']
})
export class ComputerListComponent implements OnInit {
  computerList: computer[] = [];
  isDataLoaded = false;
  constructor(
    public _computerService: ComputerService,
    private cdr: ChangeDetectorRef,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this._computerService.getComputers().subscribe(
      (list: computer[]) => {
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
