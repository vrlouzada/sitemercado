import { BasicAuthInterceptor } from './helper/basic-auth.interceptor';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthComponent } from './componentes/auth/auth.component';
import { AppRoutingModule } from './app-routing/app-routing.module';
import { ProductComponent } from './componentes/product/product.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ErrorInterceptor } from './helper/error.interceptor';



@NgModule({
  declarations: [
    AppComponent,
    AuthComponent,
    ProductComponent        
  ],
  imports: [
    BrowserModule, 
    HttpClientModule,
    FormsModule, 
    ReactiveFormsModule,
    AppRoutingModule,
    NgbModule
  ],
  providers: [ {provide: HTTP_INTERCEPTORS, useClass: BasicAuthInterceptor, multi: true},
               {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }],
  
  bootstrap: [AppComponent]
})
export class AppModule { }
