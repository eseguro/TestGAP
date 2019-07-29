import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { EndPoints } from 'src/app/config/EndPoints';
import { InsurancePolicyCoveringModel } from '../models/insurance-policy-covering.model';

@Injectable({
  providedIn: 'root'
})
export class InsurancePolicyCoveringService {

  API_URL: string;
  constructor(private _http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.API_URL = baseUrl;
  }

  public getAll(id: number) {
    return this._http.get<InsurancePolicyCoveringModel[]>(`${this.API_URL}${EndPoints.INSURANCEPOLICYCOVERING}/${id}`);
  }

  public post(model: InsurancePolicyCoveringModel) {
    return this._http.post<InsurancePolicyCoveringModel>(this.API_URL + EndPoints.INSURANCEPOLICYCOVERING, model);
  }
}
