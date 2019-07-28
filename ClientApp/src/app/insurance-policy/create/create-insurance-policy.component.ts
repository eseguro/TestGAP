import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { InsurancePolicyModel } from 'src/app/shared/models/insurance-policy.model';
import { RiskType } from 'src/app/shared/enums/risk-type.enum';
import { RiskTypeModel } from 'src/app/shared/models/risk-type.model';

@Component({
  selector: 'app-create-insurance-policy',
  templateUrl: './create-insurance-policy.component.html',
  styleUrls: ['./create-insurance-policy.component.css']
})
export class CreateInsurancePolicyComponent implements OnInit {
  insuranceModel: InsurancePolicyModel = new InsurancePolicyModel();
  ngOnInit() { 
    this.initModel();
  }



  save(insurance: InsurancePolicyModel) {
    console.log('guarda', insurance);

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
