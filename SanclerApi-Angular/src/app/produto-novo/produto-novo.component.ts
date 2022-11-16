import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, NgForm, FormBuilder,  FormControl  } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from 'src/services/api.service';
import { Produto } from 'src/model/produto';

@Component({
  selector: 'app-produto-novo',
  templateUrl: './produto-novo.component.html',
  styleUrls: ['./produto-novo.component.css']
})
export class ProdutoNovoComponent implements OnInit {
  produtoForm= new FormGroup({
    title : new FormControl(""),
    descriptions : new FormControl(""),
    sku : new FormControl(""),
    price : new FormControl(1),
  });


  isLoadingResults = false;

  constructor(private router: Router, private api: ApiService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
  }
  addProduto(form: Produto) {
    this.isLoadingResults = true;
    this.api.addProduto(form)
      .subscribe({next:(res => {
        this.isLoadingResults = false;
        this.router.navigate(['/adm/produtos']);
      }),error:(err =>{
        console.log(err);
        this.isLoadingResults = false;})
      });
  }
}
