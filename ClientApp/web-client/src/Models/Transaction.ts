import axios from "axios";
import { ITransaction } from "./ITransaction";

export async function getAll():Promise<ITransaction[]>{
    return (await axios.get('/Transaction/All')).data;
}

export async function getId():Promise<ITransaction>{
    return (await axios.get('/Transaction/Get/1')).data;
}