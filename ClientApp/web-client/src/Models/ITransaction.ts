import { IType } from './IType';

export interface ITransaction {
    id?: number;
    amount?: number;
    description?:string;
    date?: Date;
    type?: IType;
}
