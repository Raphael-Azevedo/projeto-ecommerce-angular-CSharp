import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, NgForm, FormBuilder,FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Comments } from 'src/model/comments';
import { ApiService } from 'src/services/api.service';

@Component({
  selector: 'app-comentario-editar',
  templateUrl: './comentario-editar.component.html',
  styleUrls: ['./comentario-editar.component.css']
})
export class ComentarioEditarComponent implements OnInit {
  id = Number;
  comentarioForm= new FormGroup({
    id: new FormControl(),
    comment : new FormControl(),
  });

  isLoadingResults = false;
  constructor(private router: Router, private route: ActivatedRoute,
    private api: ApiService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.getComentario(this.route.snapshot.params['id']);
  }

  getComentario(id:number) {
    this.api.getComentario(id).subscribe(data => {
      console.log(data)
      this.id = data.comments.id;
      this.comentarioForm.setValue({
        id: data.comments.id,
        comment: data.comments.comment
      });
    });
  }

  updateComentario(form: Comments) {
    console.log(form);
    this.isLoadingResults = true;
    this.api.updateComentario(this.id, form)
    .subscribe({next:(res => {
      this.isLoadingResults = false;
      this.router.navigate(['/adm/produtos'])
    }),error:(err =>{
      console.log(err);
      this.isLoadingResults = false;})
    });
   }
}
