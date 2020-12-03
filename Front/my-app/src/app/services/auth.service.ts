import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from '../model/user.model';
import { AuthResponse } from '../model/authresponse.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private userSubject: BehaviorSubject<User>;
  public user: Observable<User>;

  constructor(private http: HttpClient, private router : Router) { 
    this.userSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('user')));
    this.user = this.userSubject.asObservable();
  }

  public get userValue(): User {
    return this.userSubject.value;
}

  public login(username: string, password: string){
    var user = {
      username: username,
      password: password,
      authdata:  window.btoa(username + ':' + password)
    };
    localStorage.setItem('user', JSON.stringify(user));
    this.userSubject.next(user as any);

    return this.http.post<any>(`https://dev.sitemercado.com.br/api/login`, {username, password })
    .pipe(map(data => {  
      return data;
    }))
  }

  public logout(){
    localStorage.removeItem('user');
    this.userSubject.next(null);
    this.router.navigate(['/']);
  }
}