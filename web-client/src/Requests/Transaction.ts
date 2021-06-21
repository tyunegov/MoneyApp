import axios from "axios";
import { ITransaction } from "../Models/ITransaction";
import { IType } from "../Models/IType";
import moment from 'moment';
import { Report } from "../Models/Report";
import { OPERATION_FAILED, OPERATION_SUCCESS } from "./RequestHelper";

let _startDate:Date = moment().startOf('month').format('YYYY-MM-DD hh:mm') as unknown as Date;
let _endDate:Date = moment().endOf('month').format('YYYY-MM-DD hh:mm') as unknown as Date;

export async function getAll():Promise<ITransaction[]>{
   return (await axios.get('/Transaction/History')).data;
}

export async function getId(id:number):Promise<ITransaction>{
    return (await axios.get(`/Transaction/${id}`)).data;
}

export async function getTypes():Promise<IType[]>{
    return (await axios.get('/Type/All')).data;
}

export async function postTransaction(transaction:ITransaction):Promise<string>{
  try{
    await axios.post('/Transaction', transaction);
    return OPERATION_SUCCESS
  }
  catch(e){
    return `${OPERATION_FAILED} ${e}`;
  }
}

export async function editTransaction(id:number, transaction:ITransaction):Promise<string> {
  try {
      await axios.put(`/Transaction/Put/${id}`, transaction);
      return OPERATION_SUCCESS
    }
    catch(e){
      return `${OPERATION_FAILED} ${e}`;
    }
}

export async function deleteTransaction(id:number) {
  try {
      await axios.delete(`/Transaction/Delete/${id}`);
    } catch (e) {
      console.log(`Request failed: ${e}`);
    }
}

export async function reportPeriod(startDate: Date= _startDate,  endDate: Date= _endDate):Promise<Report>{
  return (await axios.get(`/Transaction/Report/Period?startDate=${startDate}&endDate=${endDate}`)).data;
}