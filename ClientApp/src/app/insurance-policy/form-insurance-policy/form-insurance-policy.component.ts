import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { InsurancePolicyModel } from 'src/app/shared/models/insurance-policy.model';
import { RiskTypeModel } from 'src/app/shared/models/risk-type.model';
import { RiskType } from 'src/app/shared/enums/risk-type.enum';
import { RiskTypeService } from 'src/app/shared/services/risk-type.service';

@Component({
  selector: 'app-form-insurance-policy',
  templateUrl: './form-insurance-policy.component.html',
  styleUrls: ['./form-insurance-policy.component.css']
})
export class FormInsurancePolicyComponent implements OnInit {
  @Input() insuranceRecord: InsurancePolicyModel;
  @Output() saveInsurance: EventEmitter<InsurancePolicyModel> = new EventEmitter();

  insuranceForm: FormGroup;
  riskTypes: RiskTypeModel[] = [];
  submitted: boolean = false;

  constructor(private formBuilder: FormBuilder, private _riskTypeService: RiskTypeService) { }

  ngOnInit() {
    this.setForm();
    this.loadRiskType();
  }

  onSubmit({ value }: { value: InsurancePolicyModel }) {
    this.submitted = true;
    console.log(value);
    this.saveInsurance.emit(value);
  }

  setForm() {
    this.insuranceForm = this.formBuilder.group({
      name: [this.insuranceRecord.name.trim(), Validators.required],
      description: [this.insuranceRecord.description.trim(), Validators.required],
      initDate: [this.insuranceRecord.initDate, Validators.required],
      price: [this.insuranceRecord.price, Validators.required],
      riskTypeId: [this.insuranceRecord.riskTypeId, Validators.required],
      coverageMonth: [this.insuranceRecord.coverageMonth, Validators.required],
    });
  }

  loadRiskType() {
    this._riskTypeService.getAll().subscribe(res => {
      this.riskTypes = res;
    });
  }
}
