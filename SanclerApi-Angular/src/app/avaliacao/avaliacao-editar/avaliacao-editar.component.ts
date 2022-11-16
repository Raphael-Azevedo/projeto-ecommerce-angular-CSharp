import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, NgForm, FormBuilder,FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Assessment } from 'src/model/assessment';
import { ApiService } from 'src/services/api.service';

@Component({
  selector: 'app-avaliacao-editar',
  templateUrl: './avaliacao-editar.component.html',
  styleUrls: ['./avaliacao-editar.component.css']
})
export class AvaliacaoEditarComponent implements OnInit {
  id = Number;
  avaliacaoForm= new FormGroup({
    id: new FormControl(),
    evaluation : new FormControl(),
  });

  isLoadingResults = false;
  constructor(private router: Router, private route: ActivatedRoute,
    private api: ApiService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.getAvaliacao(this.route.snapshot.params['id']);
  }

  getAvaliacao(id:number) {
    this.api.getAvaliacao(id).subscribe(data => {
      console.log(data)
      this.id = data.Assessment.id;
      this.avaliacaoForm.setValue({
        id: data.Assessment.id,
        evaluation: data.Assessment.evaluation
      });
    });
  }

  updateAvaliacao(form: Assessment) {
    console.log(form);
    this.isLoadingResults = true;
    this.api.updateAvaliacao(this.id, form)
    .subscribe({next:(res => {
      this.isLoadingResults = false;
      this.router.navigate(['/adm/produtos'])
    }),error:(err =>{
      console.log(err);
      this.isLoadingResults = false;})
    });
   }
}
