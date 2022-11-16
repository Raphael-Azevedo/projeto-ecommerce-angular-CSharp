import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, NgForm, FormBuilder,  FormControl  } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from 'src/services/api.service';
import { Inventory } from 'src/model/inventory';


@Component({
  selector: 'app-inventario-novo',
  templateUrl: './inventario-novo.component.html',
  styleUrls: ['./inventario-novo.component.css']
})
export class InventarioNovoComponent implements OnInit {
  estoqueForm= new FormGroup({
    size : new FormControl(""),
    amount : new FormControl(""),
  });


  isLoadingResults = false;

  constructor(private router: Router, private api: ApiService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
  }
  addEstoque(form: Inventory) {
    this.isLoadingResults = true;
    this.api.addEstoque(form)
      .subscribe({next:(res => {
        this.isLoadingResults = false;
        this.router.navigate(['/adm/produtos']);
      }),error:(err =>{
        console.log(err);
        this.isLoadingResults = false;})
      });
  }
}
