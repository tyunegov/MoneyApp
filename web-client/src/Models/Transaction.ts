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

export async function postTransaction(transaction:ITransaction) {
    try {
        await axios.post('/Transaction/Post', transaction);
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