import { IType } from './IType';

export interface ITransaction {
    amount: string;
    description:string;
    date: Date;
    type: IType;
}
