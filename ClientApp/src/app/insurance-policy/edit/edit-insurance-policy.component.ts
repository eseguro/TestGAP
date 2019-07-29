import { Component, OnInit } from '@angular/core';
import { InsurancePolicyModel } from 'src/app/shared/models/insurance-policy.model';
import { ActivatedRoute, Router } from '@angular/router';
import { InsurancePolicyService } from 'src/app/shared/services/insurance-policy.service';

@Component({
  selector: 'app-edit-insurance-policy',
  templateUrl: './edit-insurance-policy.component.html',
  styleUrls: ['./edit-insurance-policy.component.css']
})
export class EditInsurancePolicyComponent implements OnInit {
  insurance: InsurancePolicyModel;
  idParam: number;
  constructor(private _insurancePolicyService: InsurancePolicyService,
    private _route: ActivatedRoute,
    private _router: Router) { }

  ngOnInit() {
    this.idParam = Number(this._route.snapshot.paramMap.get('id'));
    this.findEditInsurance(this.idParam);
  }

  save(insurance: InsurancePolicyModel) {
    if (insurance.initDate == undefined)
      insurance.initDate = this.insurance.initDate;
    this._insurancePolicyService.put(insurance).subscribe(resp => {
      this._router.navigate(['/insurance']);
    });
  }

  findEditInsurance(id: number) {
    this._insurancePolicyService.getById(id).subscribe(resp => {
      this.insurance = resp;
    });
  }
}
