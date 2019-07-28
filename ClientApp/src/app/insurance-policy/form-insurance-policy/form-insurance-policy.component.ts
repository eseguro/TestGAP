import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { InsurancePolicyModel } from 'src/app/shared/models/insurance-policy.model';
import { RiskTypeModel } from 'src/app/shared/models/risk-type.model';
import { RiskType } from 'src/app/shared/enums/risk-type.enum';

@Component({
  selector: 'app-form-insurance-policy',
  templateUrl: './form-insurance-policy.component.html',
  styleUrls: ['./form-insurance-policy.component.css']
})
export class FormInsurancePolicyComponent implements OnInit {
  @Input()insuranceRecord : InsurancePolicyModel;
  @Output() saveInsurance: EventEmitter<InsurancePolicyModel> = new EventEmitter(); 
  insuranceForm: FormGroup;
  insurance: InsurancePolicyModel;
  riskTypes: RiskTypeModel[]  = [
    {riskTypeId: 1, description: 'bajo'},
    {riskTypeId: 2, description: 'medio'},
    {riskTypeId: 3, description: 'medio-alto'},
    {riskTypeId: 4, description: 'alto'}

  ];
  submitted: boolean = false ;
    constructor(private formBuilder: FormBuilder) { }

    ngOnInit() { 
      console.log(this.insuranceRecord.riskType)
        this.insurance = {
          insurancePolicyId: (this.insuranceRecord && this.insuranceRecord.insurancePolicyId) || 0,
          name: (this.insuranceRecord && this.insuranceRecord.name) || '',
          description: (this.insuranceRecord && this.insuranceRecord.description) || '',
          initDate: (this.insuranceRecord && this.insuranceRecord.initDate) || new Date().toDateString(),
          price:(this.insuranceRecord && this.insuranceRecord.price) || 0,
          riskType: (this.insuranceRecord && this.insuranceRecord.riskType) || {riskTypeId: 4, description:'alto'},
          coverageMonth: (this.insuranceRecord && this.insuranceRecord.coverageMonth) || 0
        };

        this.insuranceForm = this.formBuilder.group({
            name: [this.insurance.name.trim(), Validators.required ],
            description: [this.insurance.description.trim(), Validators.required ],
            initDate:[this.insurance.initDate, Validators.required ],
            price:[this.insurance.price, Validators.required ],
            riskType: [this.insurance.riskType, Validators.required ],
            coverageMonth: [this.insurance.coverageMonth, Validators.required ],
        });
    }

    onSubmit({ value }: { value: InsurancePolicyModel }) {
      this.submitted = true;
      console.log(value);
      this.saveInsurance.emit(value);
    }


}
