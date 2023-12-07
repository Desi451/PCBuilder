import { Component, Input, OnInit } from "@angular/core";


@Component({
  selector: 'app-uni-table',
  templateUrl: './uni-table.component.html',
  styleUrls: ['./uni-table.component.scss'],

})

export class UniTableComponent implements OnInit {
  @Input() data!: any[];
  @Input() columns!: string[];
  page = 1; // Initial page
  pageSize = 3;
  maxSize = 15;
  rotate = true;
  ellipses = true;
  slicedData: any[] = [];

  constructor() { }

  ngOnInit(): void {
    console.log('Data table comp:', this.data);
    console.log('Columns:', this.columns);
    this.updateSlicedData();
  }

  onPageChange(page: number): void {
    this.page = page;
    this.updateSlicedData();
  }

  onEditClick(row: any): void {
    // Handle edit action for the given row
    console.log('Edit clicked for row:', row);
  }

  onDeleteClick(row: any): void {
    // Handle delete action for the given row
    console.log('Delete clicked for row:', row);
  }

  onViewClick(row: any): void {
    // Handle view action for the given row
    console.log('View clicked for row:', row);
  }

  private updateSlicedData(): void {
    const startIndex = (this.page - 1) * this.pageSize;
    const endIndex = startIndex + this.pageSize;
    this.slicedData = this.data.slice(startIndex, endIndex);
  }
}
