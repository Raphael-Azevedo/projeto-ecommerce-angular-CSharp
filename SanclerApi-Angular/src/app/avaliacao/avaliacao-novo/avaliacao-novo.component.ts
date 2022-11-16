import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, NgForm, FormBuilder,  FormControl  } from '@angular/forms';
import { Router } from '@angular/router';
import { Assessment } from 'src/model/assessment';
import { ApiService } from 'src/services/api.service';


@Component({
  selector: 'app-avaliacao-novo',
  templateUrl: './avaliacao-novo.component.html',
  styleUrls: ['./avaliacao-novo.component.css']
})
export class AvaliacaoNovoComponent implements OnInit {
  avaliacaoForm= new FormGroup({
    assessment : new FormControl(""),
  });


  isLoadingResults = false;

  constructor(private router: Router, private api: ApiService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
  }
  addAvaliacao(form: Assessment) {
    this.isLoadingResults = true;
    this.api.addAvaliacao(form)
      .subscribe({next:(res => {
        this.isLoadingResults = false;
        this.router.navigate(['/adm/produtos']);
      }),error:(err =>{
        console.log(err);
        this.isLoadingResults = false;})
      });
  }
}
