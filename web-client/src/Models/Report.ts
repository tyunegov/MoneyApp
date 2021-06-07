import { IType } from "./IType";

export class Report {
    startDate?: Date;
    endDate?: Date;
    amountGroupType?:{type?:IType,amount?:number}[];
    rest?:number;
}
