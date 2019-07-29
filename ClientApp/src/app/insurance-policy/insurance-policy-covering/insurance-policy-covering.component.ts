import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { CoverageTypeService } from 'src/app/shared/services/coverage-type.service';
import { CoverageTypeModel } from 'src/app/shared/models/coverage-type.model';
import { InsurancePolicyCoveringModel } from 'src/app/shared/models/insurance-policy-covering.model';

@Component({
  selector: 'app-insurance-policy-covering',
  templateUrl: './insurance-policy-covering.component.html',
  styleUrls: ['./insurance-policy-covering.component.css']
})
export class InsurancePolicyCoveringComponent implements OnInit {

  coveringForm: FormGroup
  idParam: number = 0;
  riskType: number;
  coverageTypeList: CoverageTypeModel[] = [];
  insurancePolicyCovering: InsurancePolicyCoveringModel;
  currentPolicyCovering: InsurancePolicyCoveringModel[] = [];
  patternNumbers = /^[0-9]*$/;

  constructor(private formBuilder: FormBuilder,
    private _coverageTypeService: CoverageTypeService,
    private _route: ActivatedRoute,
    private _router: Router) { }

  ngOnInit() {
    this.idParam = Number(this._route.snapshot.paramMap.get('id'));
    this.loadCoverageType();
    this.setForm();    
  }

  setForm() {
    this.coveringForm = this.formBuilder.group({
      insurancePolicyId: new FormControl(this.idParam, [Validators.required]),
      coverageTypeId: new FormControl(0, [Validators.required]),
      Percentage: new FormControl(0, [Validators.pattern(this.patternNumbers), Validators.required])
    });
  }

  loadCurrentPolicyCoverage(){

  }

  loadCoverageType() {
    this._coverageTypeService.getAll().subscribe(res => {
      this.coverageTypeList = res;
    });
  }

}
