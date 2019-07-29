import { InsurancePolicyModel } from "./insurance-policy.model";
import { CoverageTypeModel } from "./coverage-type.model";

export class InsurancePolicyCoveringModel {
    insurancePolicyCoveringId: number;
    coverageTypeId: number;
    insurancePolicyId : number;
    percentage: number;

    coverageType: CoverageTypeModel;
}