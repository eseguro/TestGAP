import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { InsurancePolicyModel } from 'src/app/shared/models/insurance-policy.model';
import { RiskTypeModel } from 'src/app/shared/models/risk-type.model';
import { RiskTypeService } from 'src/app/shared/services/risk-type.service';
import * as _moment from 'moment';
import { default as _rollupMoment } from 'moment';

const moment = _rollupMoment || _moment;

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
  formattedDate: string;
  patternNumbers = /^[0-9]*$/;

  constructor(private formBuilder: FormBuilder, private _riskTypeService: RiskTypeService) { }

  ngOnInit() {
    this.setForm();
    this.loadRiskType();
  }

  onSubmit({ value }: { value: InsurancePolicyModel }) {
    this.submitted = true;
    value.initDate = this.formattedDate;
    this.saveInsurance.emit(value);
  }

  setForm() {
    this.insuranceForm = this.formBuilder.group({
      name: new FormControl(this.insuranceRecord.name, [Validators.required]),
      description: new FormControl(this.insuranceRecord.description, [Validators.required]),
      initDate: new FormControl(this.insuranceRecord.initDate,[ Validators.required]),
      price: new FormControl(this.insuranceRecord.price,[ Validators.pattern(this.patternNumbers), Validators.required]),
      riskTypeId: new FormControl(this.insuranceRecord.riskTypeId,[ Validators.min(1), Validators.required]),
      coverageMonth: new FormControl(this.insuranceRecord.coverageMonth,[ Validators.pattern(this.patternNumbers), Validators.required])
    });

    this.onChanges();
  }

  loadRiskType() {
    this._riskTypeService.getAll().subscribe(res => {
      this.riskTypes = res;
    });
  }

  onChanges(): void {
    this.insuranceForm.get('initDate').valueChanges.subscribe(val => {
      if (val)
        this.formattedDate = moment(val).utc().format();
    });
  }
}
