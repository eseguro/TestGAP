import { RiskTypeModel } from "./risk-type.model";

export class InsurancePolicyModel {
  insurancePolicyId: number;
	name: string;
	description: string;
	initDate: string;
	coverageMonth: number;
	price: number;
	riskType: RiskTypeModel
}
