import { IType } from './IType';

export interface ITransaction {
    id?: number;
    amount?: number;
    description?:string;
    date?: string;
    type?: IType;
}
