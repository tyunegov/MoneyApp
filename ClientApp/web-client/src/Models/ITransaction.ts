import { IType } from './IType';

export interface ITransaction {
    id: number;
    amount: string;
    description:string;
    date: Date;
    type: IType;
}
