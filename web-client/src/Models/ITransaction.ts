import { IType } from './IType';

export class ITransaction {
    id?: number;
    amount?: number;
    description?:string;
    date?: Date;
    type?: IType;
}
