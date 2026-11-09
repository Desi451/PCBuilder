import { ChangeDetectorRef, Component, OnInit, ChangeDetectionStrategy } from "@angular/core";
import { ToastrService } from "ngx-toastr";
import { CaseService } from "src/app/core/service/case.service";
import { casePc, CaseSizes } from "src/app/shared/models/case.model";

@Component({
  selector: 'app-case-list',
  templateUrl: './case-list.component.html',
  styleUrls: ['./case-list.component.scss'],
  changeDetection: ChangeDetectionStrategy.Eager,
  standalone: false
})
export class CaseListComponent implements OnInit {
  caseList: casePc[] = [];
  isDataLoaded = false;
  constructor(
    public _caseService: CaseService,
    private cdr: ChangeDetectorRef,// Inject ChangeDetectorRef
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this._caseService.getCases().subscribe(
      (cases: casePc[]) => {
        this.caseList = cases;
        this.caseList = cases.map((caseItem) => {
          return {
            ...caseItem,
            caseSize: getCaseSizeName(caseItem.caseSizeId),
          };
        });
        this.isDataLoaded = true;
        this.cdr.detectChanges();
      },
      (error) => {
        this.toastr.error('Error fetching Cases', 'Server Error');
      }
    );
  }
}

function getCaseSizeName(enumValue: number): string {
  const keys = Object.keys(CaseSizes).filter((x) => CaseSizes[x as keyof typeof CaseSizes] === enumValue);
  return keys[0];
}
