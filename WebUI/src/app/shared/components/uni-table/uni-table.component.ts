import { Component, Input, OnInit } from "@angular/core";


@Component({
  selector: 'app-uni-table',
  templateUrl: './uni-table.component.html',
  styleUrls: ['./uni-table.component.scss'],

})

export class UniTableComponent implements OnInit{
  @Input() data!: any[];
  @Input() columns!: string[];

  constructor() {}

  ngOnInit(): void {
    console.log('Data table comp:', this.data);
    console.log('Columns:', this.columns);
  }
}
