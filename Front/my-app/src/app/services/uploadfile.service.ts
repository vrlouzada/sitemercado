import { HttpClient, HttpEvent, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ImageModel } from '../model/image.model';


@Injectable({
  providedIn: 'root'
})
export class UploadfileService {


  constructor(private http: HttpClient) { }

  public upload(file: File, id: any): Observable<HttpEvent<any>>{
    const formData: FormData = new FormData();
    formData.append('file', file);
    formData.append('idprod', id);
     const req = new HttpRequest('POST', `https://localhost:44304/uploadfile/upload`, formData, {
      reportProgress: true,
      responseType: 'json'
    });

    return this.http.request(req);
  }


  public getImage(item): Observable<ImageModel>{
    return this.http.post<ImageModel>('https://localhost:44304/uploadfile/get',  item)
    .pipe(map(image  =>{
      return image;
    }));    
  }
  
}
