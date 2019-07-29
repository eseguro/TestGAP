import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatPaginator } from '@angular/material/';
import { MatDialog } from '@angular/material';
import { InsurancePolicyModel } from '../../shared/models/insurance-policy.model';
import { InsurancePolicyService } from 'src/app/shared/services/insurance-policy.service';
import { ConfirmationDialogComponent } from 'src/app/shared/components/confirmation-dialog/confirmation-dialog.component';

@Component({
  selector: 'app-list-insurance-policy',
  templateUrl: './list-insurance-policy.component.html',
  styleUrls: ['./list-insurance-policy.component.css']
})
export class ListInsuranceComponent implements OnInit {

  displayedColumns: string[] = ['coverage', 'id', 'name', 'description', 'initDate', 'coverageMonth', 'price', 'riskType', 'edit', 'delete'];
  dataSource: MatTableDataSource<InsurancePolicyModel>;
  idDelete: number;

  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(private _insurancePolicyService: InsurancePolicyService,
    public dialog: MatDialog) { }

  ngOnInit() {
    this.loadTable();
  }

  loadTable(){
    this._insurancePolicyService.getAll().subscribe(data => {
      this.dataSource = new MatTableDataSource<InsurancePolicyModel>(data);
      this.dataSource.paginator = this.paginator;
    });
  }

  openDialog(insurancePolicyId: number): void {
    this.idDelete = insurancePolicyId;
    const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      data: "Do you confirm the deletion of this data?"
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.deleteRecord(this.idDelete);
      }
    });
  }

  deleteRecord(id: number) {
    this._insurancePolicyService.delete(id).subscribe(resp => {
      this.loadTable();
    });
  }
}


