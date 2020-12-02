import { ProductComponent } from './../componentes/product/product.component';
import { AuthComponent } from './../componentes/auth/auth.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    component: AuthComponent,
  },
    {
        path: 'produtos',
        component: ProductComponent,
    }
   
];

@NgModule({
    imports: [
        RouterModule.forRoot(routes)
    ],
    exports: [
        RouterModule
    ],
    declarations: []
})
export class AppRoutingModule { }