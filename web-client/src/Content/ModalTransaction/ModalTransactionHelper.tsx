import { useState } from "react";
import ModalTransaction from "./ModalTransaction";

export enum ErrMessage{
    DateIsEmpty="Необходимо заполнить дату", 
    AmountIsEmpty="Необходимо ввести сумму",
    TypeIsEmpty="Необходимо указать тип операции"
}

export enum Title{
    Change="Изменить", 
    Add="Добавить"
}
