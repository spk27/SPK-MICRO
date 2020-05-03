import { Component, OnInit, Input } from '@angular/core';
import { ProductsListDTO } from '../catalog-api';
import { MatCarousel, MatCarouselComponent } from '@ngmodule/material-carousel';

@Component({
  selector: 'app-product-box',
  templateUrl: './product-box.component.html',
  styleUrls: ['./product-box.component.css']
})
export class ProductBoxComponent implements OnInit {
  @Input() product: ProductsListDTO; 
  rate: Number = 3.5;
  constructor() { }

  ngOnInit() {
  }



}
