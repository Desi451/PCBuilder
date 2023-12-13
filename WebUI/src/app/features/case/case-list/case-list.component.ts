import { ChangeDetectorRef, Component, OnInit } from "@angular/core";
import { CaseService } from "src/app/core/service/case.service";
import { casePc } from "src/app/shared/models/case.model";

@Component({
  selector: 'app-case-list',
  templateUrl: './case-list.component.html',
  styleUrls: ['./case-list.component.scss']
})
export class CaseListComponent implements OnInit {
  caseList: casePc[] = [];
  isDataLoaded = false;
  constructor(
    public _caseService: CaseService,
    private cdr: ChangeDetectorRef // Inject ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    this._caseService.getCases().subscribe(
      (brands: casePc[]) => {
        this.caseList = brands;
        this.isDataLoaded = true;
        this.cdr.detectChanges();
      },
      (error) => {
        console.error('Error fetching brands:', error);
      }
    );
  }
}
