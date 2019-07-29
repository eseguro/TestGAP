import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';

import { CoverageTypeModel } from 'src/app/shared/models/coverage-type.model';
import { InsurancePolicyCoveringModel } from 'src/app/shared/models/insurance-policy-covering.model';
import { RiskType } from 'src/app/shared/enums/risk-type.enum';

import { CoverageTypeService } from 'src/app/shared/services/coverage-type.service';
import { InsurancePolicyService } from 'src/app/shared/services/insurance-policy.service';
import { InsurancePolicyCoveringService } from 'src/app/shared/services/insurance-policy-covering.service';

@Component({
  selector: 'app-insurance-policy-covering',
  templateUrl: './insurance-policy-covering.component.html',
  styleUrls: ['./insurance-policy-covering.component.css']
})
export class InsurancePolicyCoveringComponent implements OnInit {

  coveringForm: FormGroup
  idParam: number = 0;
  error: boolean = false;
  errorMessage: string = '';
  coverageTypeList: CoverageTypeModel[] = [];
  currentPolicyCovering: InsurancePolicyCoveringModel[] = [];
  patternNumbers = /^[0-9]*$/;

  constructor(private formBuilder: FormBuilder,
    private _coverageTypeService: CoverageTypeService,
    private _insurancePolicyCoveringService: InsurancePolicyCoveringService,
    private _route: ActivatedRoute,
    private _router: Router) { }

  ngOnInit() {
    this.idParam = Number(this._route.snapshot.paramMap.get('id'));
    this.loadCurrentPolicyCoverage(this.idParam);
    this.loadCoverageType();
    this.setForm();
  }

  setForm() {
    this.coveringForm = this.formBuilder.group({
      insurancePolicyId: new FormControl(this.idParam, [Validators.required]),
      coverageTypeId: new FormControl(0, [Validators.required]),
      percentage: new FormControl(0, [Validators.pattern(this.patternNumbers), Validators.required])
    });
  }

  loadCurrentPolicyCoverage(id: number) {
    this._insurancePolicyCoveringService.getAll(id).subscribe(resp => {
      this.currentPolicyCovering = resp;
    })
  }

  loadCoverageType() {
    this._coverageTypeService.getAll().subscribe(res => {
      this.coverageTypeList = res;
    });
  }

  onSubmit({ value }: { value: InsurancePolicyCoveringModel }) {
    this.error = false;
    this._insurancePolicyCoveringService.post(value).subscribe(res => {      
      this.loadCurrentPolicyCoverage(this.idParam);
    }, error => {
      this.error = true;
      this.errorMessage = error.error;
    });
  }

}
