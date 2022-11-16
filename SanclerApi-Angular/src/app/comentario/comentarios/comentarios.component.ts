import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { ApiService } from 'src/services/api.service';
import { FormGroup, Validators, NgForm, FormBuilder,FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Comments } from 'src/model/comments';

@Component({
  selector: 'app-comentarios',
  templateUrl: './comentarios.component.html',
  styleUrls: ['./comentarios.component.css']
})
export class ComentariosComponent implements OnInit {
  displayedColumns: string[] = [ 'product','userId', 'comment','acao'];
  dataSource: Comments[] = []!;
  isLoadingResults = true;
  id = Number;
  constructor(private router: Router, private route: ActivatedRoute,
    private api: ApiService, private formBuilder: FormBuilder) { }

    ngOnInit(): void {
      this.api.getComentarios(this.route.snapshot.params['id'])
      .subscribe({next:( res => {
        this.dataSource = res;
        console.log(this.dataSource);
        this.isLoadingResults = false;
      }),error: (err => {
        console.log(err);
        this.isLoadingResults = false;})
     });
    }

  deleteComentario(id:number) {
    this.isLoadingResults = true;
    this.api.deleteComentario(id)
    .subscribe({next:(res => {
      this.isLoadingResults = false;
      location.reload();
    }),error:(err =>{
      console.log(err);
      this.isLoadingResults = false;})
    });
  }
}
