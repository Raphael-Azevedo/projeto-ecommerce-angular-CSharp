import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, NgForm, FormBuilder,FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Inventory } from 'src/model/inventory';
import { ApiService } from 'src/services/api.service';

@Component({
  selector: 'app-inventario-editar',
  templateUrl: './inventario-editar.component.html',
  styleUrls: ['./inventario-editar.component.css']
})
export class InventarioEditarComponent implements OnInit {
  id = Number;
  estoqueForm= new FormGroup({
    id: new FormControl(),
    size : new FormControl(),
    amount: new FormControl()
  });

  isLoadingResults = false;
  constructor(private router: Router, private route: ActivatedRoute,
    private api: ApiService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.getEstoqu(this.route.snapshot.params['id']);
  }

  getEstoqu(id:number) {
    this.api.getEstoqu(id).subscribe(data => {
      console.log(data)
      this.id = data.inventory.id;
      this.estoqueForm.setValue({
        id: data.inventory.id,
        size: data.inventory.size,
        amount: data.inventory.amount
      });
    });
  }

  updateEstoque(form: Inventory) {
    console.log(form);
    this.isLoadingResults = true;
    this.api.updateEstoque(this.id, form)
    .subscribe({next:(res => {
      this.isLoadingResults = false;
      this.router.navigate(['/adm/produtos'])
    }),error:(err =>{
      console.log(err);
      this.isLoadingResults = false;})
    });
   }
}
