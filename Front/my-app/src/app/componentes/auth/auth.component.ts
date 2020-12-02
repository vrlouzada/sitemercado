import { AuthService } from 'src/app/services/auth.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Login } from 'src/app/login';
import { first } from 'rxjs/operators';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css']
})
export class AuthComponent implements OnInit {

    loginForm : FormGroup;
    login: Login;
    loading = false;
    submitted = false;
    error = "";
  
  constructor( private crudServices: AuthService,   private formBuilder: FormBuilder,  private router: Router) { }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  get f() {return this.loginForm.controls}

  onSubmit(){
    this.crudServices.login(this.f.username.value, this.f.password.value)
    .pipe(first())
    .subscribe    
    (
      data =>{
        console.log('Response Login', data);
        this.router.navigate(['/produtos']);
      }, 
      error =>{
        console.error('Erro Login', error)
      })

  }

}
