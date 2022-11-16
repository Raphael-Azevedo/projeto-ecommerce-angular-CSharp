import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, NgForm, FormBuilder,  FormControl  } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from 'src/services/api.service';
import { Comments } from 'src/model/comments';

@Component({
  selector: 'app-comentario-novo',
  templateUrl: './comentario-novo.component.html',
  styleUrls: ['./comentario-novo.component.css']
})
export class ComentarioNovoComponent implements OnInit {
  commentForm= new FormGroup({
    comment : new FormControl(""),
  });


  isLoadingResults = false;

  constructor(private router: Router, private api: ApiService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
  }
  addComentario(form: Comments) {
    this.isLoadingResults = true;
    this.api.addComentario(form)
      .subscribe({next:(res => {
        this.isLoadingResults = false;
        this.router.navigate(['/adm/produtos']);
      }),error:(err =>{
        console.log(err);
        this.isLoadingResults = false;})
      });
  }
}
