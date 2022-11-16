import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormGroupDirective, FormBuilder,FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ApiService } from 'src/services/api.service';
import { Produto } from 'src/model/produto';
import { produtoContainer } from 'src/model/produtoContainer';


@Component({
  selector: 'app-cards',
  templateUrl: './cards.component.html',
  styleUrls: ['./cards.component.css']
})
export class CardsComponent implements OnInit {
  dataSource: produtoContainer[] = [];
  isLoadingResults = true;
  constructor(private router: Router, private route: ActivatedRoute,
    private api: ApiService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.api.getProdutosCard()
    .subscribe({next:( res => {
      this.dataSource = res;
      console.log(this.dataSource);
      this.isLoadingResults = false;
    }),error: (err => {
      console.log(err);
      this.isLoadingResults = false;})
   });
  }
}
