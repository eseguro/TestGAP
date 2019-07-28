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
 ngOnInit(){}

 save(insurance: InsurancePolicyModel){
  console.log('guarda', insurance);

 }

}
