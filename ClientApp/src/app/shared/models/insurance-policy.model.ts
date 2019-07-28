import { RiskType } from "../enums/risk-type.enum";

export class InsurancePolicyModel {
  insurancePolicyId: number;
	name: string;
	description: string;
	initDate: string;
	coverageMonth: number;
	price: number;
	riskyType: number
}
