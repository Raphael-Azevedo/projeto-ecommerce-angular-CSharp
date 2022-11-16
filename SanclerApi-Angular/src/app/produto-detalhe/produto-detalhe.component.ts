import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormGroupDirective, FormBuilder,FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ApiService } from 'src/services/api.service';
import { Comments } from 'src/model/comments';
import { CommentContainer } from 'src/model/commentContainer';

@Component({
  selector: 'app-produto-detalhe',
  templateUrl: './produto-detalhe.component.html',
  styleUrls: ['./produto-detalhe.component.css']
})
export class ProdutoDetalheComponent implements OnInit {
  id = Number;
  isLoadingResults = false;
  constructor(private router: Router, private route: ActivatedRoute,
    private api: ApiService, private formBuilder: FormBuilder) { }
title = String;
price : any;
descriptions = String;
inventory : any;
size : any[] = [];
moments: CommentContainer[] = []!;
commentForm!: FormGroup;
  ngOnInit(): void {
    this.getProduto(this.route.snapshot.params['id']);
    this.getEstoqu(this.route.snapshot.params['id']);
    this.getComentario(this.route.snapshot.params['id']);
    this.commentForm = new FormGroup({
      text: new FormControl('', [Validators.required]),
      username: new FormControl('', [Validators.required]),
    });
  }

  getProduto(id:number) {
    this.api.getProduto(id).subscribe(data => {
      this.id = data.product.id;
      this.title = data.product.title;
      this.price = String(data.product.price);
      this.descriptions = data.product.descriptions
    });
  }
  getEstoqu(id:number) {
    this.api.getEstoqu(id).subscribe(res => {
      this.inventory = res;
    });
  }
  getComentario(id:number) {
    this.api.getComentarioFront(id).subscribe(items => {
      const data = items
      this.moments = data;
    });
  }
  async onSubmit(formDirective: FormGroupDirective) {
    if(this.commentForm.invalid) {
      return ;
    }

  const data: Comment = this.commentForm.value;

  this.commentForm.reset();
  formDirective.resetForm();
}
get text() {
  return this.commentForm.get('text')!;
}
get username() {
  return this.commentForm.get('username')!;
}
}

