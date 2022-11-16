import { Produto } from "./produto"

export class CommentContainer
{
  comments = {
    id : Number,
    product : Produto,
    userId : String,
    comment : String,
    username : String};
  links = String;
}
