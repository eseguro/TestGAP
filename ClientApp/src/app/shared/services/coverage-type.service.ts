import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CoverageTypeModel } from '../models/coverage-type.model';
import { EndPoints } from 'src/app/config/EndPoints';

@Injectable({
  providedIn: 'root'
})
export class CoverageTypeService {

  API_URL: string;
  constructor(private _http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.API_URL = baseUrl;
  }

  public getAll() {
    return this._http.get<CoverageTypeModel[]>(this.API_URL + EndPoints.LIST_COVERAGETYPE);
  }
}
