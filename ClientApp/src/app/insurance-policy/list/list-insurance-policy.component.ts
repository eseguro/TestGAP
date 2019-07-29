import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatPaginator } from '@angular/material/';
import { InsurancePolicyModel } from '../../shared/models/insurance-policy.model';
import { InsurancePolicyService } from 'src/app/shared/services/insurance-policy.service';

@Component({
  selector: 'app-list-insurance-policy',
  templateUrl: './list-insurance-policy.component.html',
  styleUrls: ['./list-insurance-policy.component.css']
})
export class ListInsuranceComponent implements OnInit {

  displayedColumns: string[] = ['id', 'name', 'description', 'initDate', 'coverageMonth', 'price', 'riskType', 'edit', 'delete'];
  dataSource: MatTableDataSource<InsurancePolicyModel>;
  idDelete: 0;

  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(private _insurancePolicyService: InsurancePolicyService) { }

  ngOnInit() {
    this._insurancePolicyService.getAll().subscribe(data => {
      this.dataSource = new MatTableDataSource<InsurancePolicyModel>(data);
      this.dataSource.paginator = this.paginator;
    })

  }
}


