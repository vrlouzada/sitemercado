import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Product } from '../model/product.model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient) { }

  public getAll() : Observable<Product[]>{
    console.log('Buscando...');
    return this.http.get<Product[]>(`https://localhost:44304/product/getall`);
  }

  public update(item): Observable<boolean>{
    console.log('Atualizando...');
    return this.http.put<boolean>(`https://localhost:44304/product/update`, item);
  }

  public create(item): Observable<Product>{
    console.log('Criando...');
    return this.http.post<Product>(`https://localhost:44304/product/insert`, item);
  }

  public remove(item): Observable<boolean>{
    console.log('Removendo...');
    return this.http.put<boolean>(`https://localhost:44304/product/delete`, item);      
  }
}
