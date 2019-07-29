import { Component, OnInit } from '@angular/core';
import { InsurancePolicyModel } from 'src/app/shared/models/insurance-policy.model';

@Component({
  selector: 'app-edit-insurance-policy',
  templateUrl: './edit-insurance-policy.component.html',
  styleUrls: ['./edit-insurance-policy.component.css']
})
export class EditInsurancePolicyComponent implements OnInit {
  insurance : InsurancePolicyModel = {insurancePolicyId: 1, name: 'Hydrogen', price: 10079, description: 'H', initDate: '12/09/2019', coverageMonth: 10, riskType: null, riskTypeId : 1, insurancePolicyCovering: null };
  constructor() { }

  ngOnInit() {
  }
  save(insurance: InsurancePolicyModel){
    console.log('guarda', insurance);
   
  }
}
