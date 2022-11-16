import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, NgForm, FormBuilder,FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ApiService } from 'src/services/api.service';
import { Produto } from 'src/model/produto';

@Component({
  selector: 'app-produto-editar',
  templateUrl: './produto-editar.component.html',
  styleUrls: ['./produto-editar.component.css']
})
export class ProdutoEditarComponent implements OnInit {
  id = Number;
  produtoForm= new FormGroup({
    id: new FormControl(),
    title : new FormControl(""),
    descriptions : new FormControl(""),
    sku : new FormControl(""),
    price : new FormControl(1),
  });

  isLoadingResults = false;
  constructor(private router: Router, private route: ActivatedRoute,
    private api: ApiService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.getProduto(this.route.snapshot.params['id']);
  }

  getProduto(id:number) {
    this.api.getProduto(id).subscribe(data => {
      console.log(data)
      this.id = data.product.id;
      this.produtoForm.setValue({
        id: data.product.id,
        title: data.product.title,
        descriptions: data.product.descriptions,
        sku: data.product.sku,
        price: data.product.price
      });
    });
  }

  updateProduto(form: Produto) {
    console.log(form);
    this.isLoadingResults = true;
    this.api.updateProduto(this.id, form)
    .subscribe({next:(res => {
      this.isLoadingResults = false;
      this.router.navigate(['/adm/produtos'])
    }),error:(err =>{
      console.log(err);
      this.isLoadingResults = false;})
    });
   }
}

