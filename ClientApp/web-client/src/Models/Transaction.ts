import axios from "axios";
import { ITransaction } from "./ITransaction";
import { IType } from "./IType";

export async function getAll():Promise<ITransaction[]>{
   return (await axios.get('/Transaction/All')).data;
}

export async function getId():Promise<ITransaction>{
    return (await axios.get('/Transaction/Get/1')).data;
}

export async function getTypes():Promise<IType[]>{
    return (await axios.get('/Type/All')).data;
}