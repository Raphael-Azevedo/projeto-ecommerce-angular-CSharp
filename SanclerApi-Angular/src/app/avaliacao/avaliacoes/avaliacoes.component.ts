import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { ApiService } from 'src/services/api.service';
import { FormGroup, Validators, NgForm, FormBuilder,FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Assessment } from 'src/model/assessment';

@Component({
  selector: 'app-avaliacoes',
  templateUrl: './avaliacoes.component.html',
  styleUrls: ['./avaliacoes.component.css']
})
export class AvaliacoesComponent implements OnInit {

  displayedColumns: string[] = [ 'product','userId', 'evaluation','acao'];
  dataSource: Assessment[] = []!;
  isLoadingResults = true;
  id = Number;
  constructor(private router: Router, private route: ActivatedRoute,
    private api: ApiService, private formBuilder: FormBuilder) { }

    ngOnInit(): void {
      this.api.getAvaliacoes(this.route.snapshot.params['id'])
      .subscribe({next:( res => {
        this.dataSource = res;
        console.log(this.dataSource);
        this.isLoadingResults = false;
      }),error: (err => {
        console.log(err);
        this.isLoadingResults = false;})
     });
    }

  deleteAvaliacao(id:number) {
    this.isLoadingResults = true;
    this.api.deleteAvaliacao(id)
    .subscribe({next:(res => {
      this.isLoadingResults = false;
      //location.reload();
    }),error:(err =>{
      console.log(err);
      this.isLoadingResults = false;})
    });
  }
}
