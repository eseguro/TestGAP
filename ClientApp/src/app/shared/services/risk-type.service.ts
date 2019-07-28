import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RiskTypeModel } from '../models/risk-type.model';
import { EndPoints } from 'src/app/config/EndPoints';

@Injectable({
  providedIn: 'root'
})
export class RiskTypeService {

  API_URL: string;
  constructor(private _http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.API_URL = baseUrl;
  }

  public getAll() {
    return this._http.get<RiskTypeModel[]>(this.API_URL + EndPoints.LIST_RISKTYPE);
  }
}
