import { RiskTypeModel } from "./risk-type.model";

export class InsurancePolicyModel {
	constructor(){}
	insurancePolicyId: number;
	name: string;
	description: string;
	initDate: string;
	coverageMonth: number;
	price: number;
	riskTypeId: number;
	riskType: RiskTypeModel;
}
