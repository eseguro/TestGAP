import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatPaginator } from '@angular/material/';
import { InsurancePolicyModel } from '../../shared/models/insurance-policy.model';

@Component({
  selector: 'app-list-insurance-policy',
  templateUrl: './list-insurance-policy.component.html',
  styleUrls: ['./list-insurance-policy.component.css']
})
export class ListInsuranceComponent implements OnInit {

  displayedColumns: string[] = ['id', 'name', 'description', 'initDate', 'coverage', 'price', 'riskType'];
  dataSource: MatTableDataSource<InsurancePolicyModel>;
 
  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor() { }
  
  ngOnInit() {
    this.dataSource = new MatTableDataSource<InsurancePolicyModel>(ELEMENT_DATA);
    this.dataSource.paginator = this.paginator;
  }
}

const ELEMENT_DATA: InsurancePolicyModel[] = [
  {insurancePolicyId: 1, name: 'Hydrogen', price: 10079, description: 'H', initDate: '12/09/2019', coverageMonth: 10, riskyType: 1},
  {insurancePolicyId: 2, name: 'Helium', price: 40026, description: 'He', initDate: '12/09/2019', coverageMonth: 10, riskyType: 1},
  {insurancePolicyId: 3, name: 'Lithium', price: 6941, description: 'Li', initDate: '12/09/2019', coverageMonth: 10, riskyType: 1},
  {insurancePolicyId: 4, name: 'Beryllium', price: 90122, description: 'Be', initDate: '12/09/2019', coverageMonth: 10, riskyType: 1},
  {insurancePolicyId: 5, name: 'Boron', price: 10811, description: 'B', initDate: '12/09/2019', coverageMonth: 10, riskyType: 1},
  {insurancePolicyId: 6, name: 'Carbon', price: 120107, description: 'C', initDate: '12/09/2019', coverageMonth: 10, riskyType: 1},
  {insurancePolicyId: 7, name: 'Nitrogen', price: 140067, description: 'N', initDate: '12/09/2019', coverageMonth: 10, riskyType: 1},
  {insurancePolicyId: 8, name: 'Oxygen', price: 159994, description: 'O', initDate: '12/09/2019', coverageMonth: 10, riskyType: 1},
  {insurancePolicyId: 9, name: 'Fluorine', price: 189984, description: 'F', initDate: '12/09/2019', coverageMonth: 10, riskyType: 1},
  {insurancePolicyId: 10, name: 'Neon', price: 201797, description: 'Ne', initDate: '12/09/2019', coverageMonth: 10, riskyType: 1},
  {insurancePolicyId: 11, name: 'Sodium', price: 229897, description: 'Na', initDate: '12/09/2019', coverageMonth: 10, riskyType: 1},
  {insurancePolicyId: 12, name: 'Magnesium', price: 24305, description: 'Mg', initDate: '12/09/2019', coverageMonth: 10, riskyType: 1},
  {insurancePolicyId: 13, name: 'Aluminum', price: 269815, description: 'Al', initDate: '12/09/2019', coverageMonth: 10, riskyType: 1},
  {insurancePolicyId: 14, name: 'Silicon', price: 280855, description: 'Si', initDate: '12/09/2019', coverageMonth: 10, riskyType: 1},
  {insurancePolicyId: 15, name: 'Phosphorus', price: 309738, description: 'P', initDate: '12/09/2019', coverageMonth: 10, riskyType: 1},
  {insurancePolicyId: 16, name: 'Sulfur', price: 32065, description: 'S', initDate: '12/09/2019', coverageMonth: 10, riskyType: 1},
  {insurancePolicyId: 17, name: 'Chlorine', price: 35453, description: 'Cl', initDate: '12/09/2019', coverageMonth: 10, riskyType: 1},
  {insurancePolicyId: 18, name: 'Argon', price: 39948, description: 'Ar', initDate: '12/09/2019', coverageMonth: 10, riskyType: 1},
  {insurancePolicyId: 19, name: 'Potassium', price: 390983, description: 'K', initDate: '12/09/2019', coverageMonth: 10, riskyType: 1},
  {insurancePolicyId: 20, name: 'Calcium', price: 40078, description: 'Ca', initDate: '12/09/2019', coverageMonth: 10, riskyType: 1},
];
