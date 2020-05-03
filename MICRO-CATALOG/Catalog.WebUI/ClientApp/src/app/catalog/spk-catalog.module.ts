import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
// import { MaterialModule } from '../materialUI/angularMaterialModule';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { ProductsClient } from '../catalog-api';

import { ListProductsComponent } from './list-products/list-products/list-products.component';
import { ProductsAdminComponent } from './products-admin/products-admin.component';



const routes = [
  { path: 'products', component: ProductsAdminComponent}
]

@NgModule({
  declarations: [
    ProductsAdminComponent
    ,ListProductsComponent
  ],
  imports: [
    CommonModule
    ,RouterModule.forChild(routes)
    ,ReactiveFormsModule
    ,FormsModule
    // ,MaterialModule
    ,FontAwesomeModule
  ]
  ,exports: [RouterModule]
  ,providers: [ProductsClient]
})
export class SpkCatalogModule { }
