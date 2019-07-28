import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { InsurancePolicyModel } from '../models/insurance-policy.model';
import { EndPoints } from 'src/app/config/EndPoints';

@Injectable({
  providedIn: 'root'
})
export class InsurancePolicyService {

  API_URL : string;
  constructor(private _http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.API_URL = baseUrl;
   }

   public getAll(){
     return this._http.get<InsurancePolicyModel[]>(this.API_URL + EndPoints.LIST_INSURANCEPOLICY).subscribe(result => {
       return result;
     });
   }
}
