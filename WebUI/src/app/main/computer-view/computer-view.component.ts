import { Component, OnInit, ChangeDetectionStrategy } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { ComputerService } from "src/app/core/service/computer.service";
import { CaseSizes } from "src/app/shared/models/case.model";
import { computerForm } from "src/app/shared/models/computer.model";

@Component({
  selector: 'app-computer-view',
  templateUrl: './computer-view.component.html',
  styleUrls: ['./computer-view.component.scss'],
  changeDetection: ChangeDetectionStrategy.Eager,
  standalone: false
})
export class ComputerViewComponent implements OnInit {
  getCaseSizeName(arg0: number) {
    const keys = Object.keys(CaseSizes).filter((x) => CaseSizes[x as keyof typeof CaseSizes] === arg0);
    return keys[0];
  }

  res: computerForm = new computerForm();
  caseSizeName = '';
  id: number;

  constructor(
    private _route: ActivatedRoute,
    private _router: Router,
    private _computerService: ComputerService,
    private toastr: ToastrService,
  ) {
    this.id = this._route.snapshot.params['id'];
  }
  ngOnInit(): void {
    this._computerService.getFullData(this.id).subscribe(
      (res: computerForm) => {
        this.res = res;
        this.caseSizeName = this.getCaseSizeName(res.case.caseSizeId);
      },
      (error) => {
        this.toastr.error('Error fetching PC configuration', 'Server Error');
      }
    );
  }
}

