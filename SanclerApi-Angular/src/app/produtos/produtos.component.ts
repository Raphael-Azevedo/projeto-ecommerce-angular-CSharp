import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { ApiService } from 'src/services/api.service';
import { Produto } from 'src/model/produto';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-produtos',
  templateUrl: './produtos.component.html',
  styleUrls: ['./produtos.component.css']
})
export class ProdutosComponent implements OnInit {
  displayedColumns: string[] = [ 'nome','sku', 'imagem','price','acao'];
  dataSource: Produto[] = []!;
  isLoadingResults = true;

  constructor(private api: ApiService, private router: Router) { }

  ngOnInit(): void {
    this.api.getProdutos()
    .subscribe({next:( res => {
      this.dataSource = res;
      console.log(this.dataSource);
      this.isLoadingResults = false;
    }),error: (err => {
      console.log(err);
      this.isLoadingResults = false;})
   });
  }
  deleteProduto(id:number) {
    this.isLoadingResults = true;
    this.api.deleteProduto(id)
    .subscribe({next:(res => {
      this.isLoadingResults = false;
      this.router.navigate(['/adm/produtos']);
      location.reload();
    }),error:(err =>{
      console.log(err);
      this.isLoadingResults = false;})
    });
  }
}
