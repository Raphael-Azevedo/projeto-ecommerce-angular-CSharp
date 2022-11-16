import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { ApiService } from 'src/services/api.service';
import { FormGroup, Validators, NgForm, FormBuilder,FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Inventory } from 'src/model/inventory';

@Component({
  selector: 'app-inventario',
  templateUrl: './inventario.component.html',
  styleUrls: ['./inventario.component.css']
})
export class InventarioComponent implements OnInit {
  displayedColumns: string[] = [ 'product','size', 'amount','acao'];
  dataSource: Inventory[] = []!;
  isLoadingResults = true;
  id = Number;
  constructor(private router: Router, private route: ActivatedRoute,
    private api: ApiService, private formBuilder: FormBuilder) { }

    ngOnInit(): void {
      this.api.getEstoque(this.route.snapshot.params['id'])
      .subscribe({next:( res => {
        this.dataSource = res;
        console.log(this.dataSource);
        this.isLoadingResults = false;
      }),error: (err => {
        console.log(err);
        this.isLoadingResults = false;})
     });
    }

  deleteEstoque(id:number) {
    this.isLoadingResults = true;
    this.api.deleteEstoque(id)
    .subscribe({next:(res => {
      this.isLoadingResults = false;
      location.reload();
    }),error:(err =>{
      console.log(err);
      this.isLoadingResults = false;})
    });
  }
}
