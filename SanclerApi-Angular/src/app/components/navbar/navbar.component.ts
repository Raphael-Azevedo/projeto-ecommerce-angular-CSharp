import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, NgForm, FormBuilder, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from 'src/services/api.service';
import { Usuario } from 'src/model/usuario';


@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  token : any;
  loginForm= new FormGroup({
    email : new FormControl(""),
    password : new FormControl(""),
    dataSource : new FormControl(Usuario),
  });
  dataSource : any;
  isLoadingResults = false;

  constructor(private router: Router, private api: ApiService,
     private formBuilder: FormBuilder) { }

  ngOnInit() {
     this.loginForm = this.formBuilder.group({
    'email' : [null, Validators.required],
    'password' : [null, Validators.required]
  });
  this.token = localStorage.getItem("jwt")
  }

  addLogin(form: Usuario) {
    this.isLoadingResults = true;
    this.api.Login(form)
    .subscribe({next:(res => {
      console.log(res);
      this.dataSource = res;
      localStorage.setItem("jwt", this.dataSource.token);
      this.isLoadingResults = false;
      this.router.navigate(['/']);
      location.reload();
    }),error:(err =>{
      console.log(err);
      this.isLoadingResults = false;})
    });
  }
}
