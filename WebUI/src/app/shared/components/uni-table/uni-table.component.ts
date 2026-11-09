import { Component, Input, OnInit, ChangeDetectionStrategy } from "@angular/core";
import { Router } from "@angular/router";
import { AuthService } from "src/app/core/auth/auth.service";

@Component({
  selector: 'app-uni-table',
  templateUrl: './uni-table.component.html',
  styleUrls: ['./uni-table.component.scss'],
  changeDetection: ChangeDetectionStrategy.Eager,
  standalone: false
})
export class UniTableComponent implements OnInit {
  @Input() data!: any[];
  @Input() columns!: string[];
  @Input() formLink!: string;
  @Input() viewLink!: string;
  page = 1; // init page
  pageSize = 10;
  maxSize = 15;
  rotate = true;
  ellipses = true;
  slicedData: any[] = [];
  searchTerm = '';
  sortColumn: string | null = null;
  sortDirection: 'asc' | 'desc' = 'asc';
  loading = true;

  userId: number = 0;
  username: string = '';
  userRank: number = 0;

  constructor(private _router: Router,
    private _authService: AuthService) { }

  ngOnInit(): void {
    this.refreshUserInfo();
    this.updateSlicedData();
  }

  refreshUserInfo() {
    this._authService.getUserInfo().subscribe(response => {
      console.log(response);
      if (response.userId) {
        this.userId = response.userId;
        this.username = response.username;
        this.userRank = response.userRank;
        console.log("tab: " + response.userRank);
      }
    });
  }

  onPageChange(page: number): void {
    this.page = page;
    this.updateSlicedData();
  }

  onEditClick(row: any): void {
    this._router.navigateByUrl(this.formLink + "/" + row.id);
  }

  onViewClick(row: any): void {
    this._router.navigateByUrl(this.viewLink + "/" + row.id);
  }

  onAddClick(): void {
    this._router.navigateByUrl(this.formLink);
  }

  onSearchTermChange(): void {
    this.page = 1;
    this.updateSlicedData();
  }

  onSortColumnClick(column: string): void {
    if (this.sortColumn === column) {
      this.sortDirection = this.sortDirection === 'asc' ? 'desc' : 'asc';
    } else {
      this.sortColumn = column;
      this.sortDirection = 'asc';
    }

    this.updateSlicedData();
  }

  updateSlicedData(): void {
    const startIndex = (this.page - 1) * this.pageSize;
    const endIndex = startIndex + this.pageSize;

    const filteredData = this.data.filter(row => {
      return this.columns.some(column => {
        const cellValue = String(row[column]);
        return cellValue.toLowerCase().includes(this.searchTerm.toLowerCase());
      });
    });

    if (this.sortColumn) {
      filteredData.sort((a, b) => {
        let valueA = "";
        let valueB = "";
        if (this.sortColumn != null) {
          valueA = String(a[this.sortColumn]);
          valueB = String(b[this.sortColumn]);
        }

        if (this.sortDirection === 'asc') {
          return valueA.localeCompare(valueB);
        } else {
          return valueB.localeCompare(valueA);
        }
      });
    }

    this.slicedData = filteredData.slice(startIndex, endIndex);
    this.loading = false;
  }
}
