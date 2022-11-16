import { Produto } from "./produto"

export class InventoryContainer
{
  inventory = {
    id : Number,
    product : Produto,
    amount : Number,
    size : Number};
  links = String;
}
