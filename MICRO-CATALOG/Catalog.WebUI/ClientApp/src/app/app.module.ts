import { BrowserModule } from '@angular/platform-browser';
import { NgModule, Injector, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { createCustomElement } from '@angular/elements';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { MaterialModule } from './materialUI/angularMaterialModule';
import { MatCarouselModule } from '@ngmodule/material-carousel';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BarRatingModule } from "ngx-bar-rating";

import { AppComponent } from './app.component';
import { ElementComponent } from './element/element.component';
import { ProductBoxComponent } from './product-box/product-box.component';
import { CarouselComponent } from './carousel/carousel.component';


@NgModule({
  declarations: [
    AppComponent
    // ,NavMenuComponent
    // ,HomeComponent
    // ,ConfirmationComponent
    // ,LoadingSpinnerComponent
    // ,PageNotFoundComponent
    ,ElementComponent, ProductBoxComponent, CarouselComponent
  ]
  ,imports: [
    BrowserModule
    ,BrowserModule.withServerTransition({ appId: 'ng-cli-universal' })
    ,BrowserAnimationsModule 
    ,HttpClientModule
    ,MaterialModule
    ,MatCarouselModule.forRoot()
    ,BarRatingModule
    // FormsModule,
    // RouterModule.forRoot([
    //   { path: '', component: HomeComponent, pathMatch: 'full' },
    // ]),
    //,SpkCatalogModule
  ]
  // ,providers: [
  //   { provide: HTTP_INTERCEPTORS, useClass: LoadingSpinnerInterceptor, multi: true }
  // ]
  ,providers: []
  ,bootstrap: [AppComponent]
  //,bootstrap: []
  ,entryComponents: [
    // ConfirmationComponent
    // ,LoadingSpinnerComponent
    ElementComponent
  ]
  ,schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { 

  constructor(private injector: Injector) {
    
  }
  
  ngDoBootstrap(){
    // create custom elements from angular components
    const ngCustomElement = createCustomElement(ElementComponent, { injector: this.injector });
    // define in browser registry
    customElements.define('ng-el', ngCustomElement);
  }
  
}
