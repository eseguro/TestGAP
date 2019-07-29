import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { InsurancePolicyModel } from 'src/app/shared/models/insurance-policy.model';
import { InsurancePolicyService } from 'src/app/shared/services/insurance-policy.service';


@Component({
  selector: 'app-create-insurance-policy',
  templateUrl: './create-insurance-policy.component.html',
  styleUrls: ['./create-insurance-policy.component.css']
})
export class CreateInsurancePolicyComponent implements OnInit {
  insuranceModel: InsurancePolicyModel = new InsurancePolicyModel();

  constructor(private _insurancePolicyService: InsurancePolicyService,
    private _router: Router) {
  }

  ngOnInit() {
    this.initModel();
  }

  save(insurance: InsurancePolicyModel) {
    this.insuranceModel = insurance;
    this._insurancePolicyService.post(insurance).subscribe(res => {
      if (res) {
        this._router.navigate(['/insurance']);
      }
    })
  }

  initModel() {
    this.insuranceModel.insurancePolicyId = 0;
    this.insuranceModel.name = '';
    this.insuranceModel.description = '';
    this.insuranceModel.initDate = '';
    this.insuranceModel.coverageMonth = 0;
    this.insuranceModel.price = 0;
    this.insuranceModel.riskTypeId = 0;
  }
}
