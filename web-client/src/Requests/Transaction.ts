import axios from "axios";
import { ITransaction } from "../Models/ITransaction";
import { IType } from "../Models/IType";

export async function getAll():Promise<ITransaction[]>{
   return (await axios.get('/Transaction/History')).data;
}

export async function getId(id:number):Promise<ITransaction>{
    return (await axios.get(`/Transaction/${id}`)).data;
}

export async function getTypes():Promise<IType[]>{
    return (await axios.get('/Type/All')).data;
}

export async function postTransaction(transaction:ITransaction) {
    try {
        await axios.post('/Transaction', transaction);
      } catch (e) {
        console.log(`Request failed: ${e}`);
      }
}

export async function editTransaction(id:number, transaction:ITransaction) {
  try {
      await axios.put(`/Transaction/Put/${id}`, transaction);
    } catch (e) {
      console.log(`Request failed: ${e}`);
    }
}

export async function deleteTransaction(id:number) {
  try {
      await axios.delete(`/Transaction/Delete/${id}`);
    } catch (e) {
      console.log(`Request failed: ${e}`);
    }
}