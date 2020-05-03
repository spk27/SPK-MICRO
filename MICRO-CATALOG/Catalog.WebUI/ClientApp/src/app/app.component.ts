import { Component, OnInit } from '@angular/core';
import { ProductsClient, ProductsListDTO } from './catalog-api';
import { map } from 'rxjs/operators';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
  title = 'app';
  products: ProductsListDTO[] = [product];
  count: Number;

  constructor(private _client: ProductsClient) {
    
  }

  ngOnInit() {
  }

  getAll() {
    this._client.getAll().subscribe(vm => {
      this.products = vm.products
      ,this.count = vm.count
    });
  }
}

let product: ProductsListDTO =
{
  "id": 4,
  "name": "Samsung Galaxy A30S",
  "description": "Smartphone Media Gama",
  "price": 735000.000,
  "oldPrice": 850000.000,
  "newPrice": 735000.000,
  "stockQuantity": 3,
  "lowStock": true,
  "onStock": false,
  "isNew": true,
  "medias": [
    {
      "fileName": "Samsung A30s",
      "displayOrder": 0,
      "source": "https://images.samsung.com/is/image/samsung/co-galaxy-a30-a305-sm-a305gzkjcoo-frontblack-157746175?$PD_GALLERY_L_JPG$",
      "caption": "Samsung A30s",
      "mediaType": 1
      ,"init": null
      ,toJSON: null
    },
    {
      "fileName": "Samsung A30s",
      "displayOrder": 1,
      "source": "https://images.samsung.com/is/image/samsung/co-galaxy-a30-a305-sm-a305gzkjcoo-backblack-157746164?$PD_GALLERY_L_JPG$",
      "caption": "Samsung A30s",
      "mediaType": 1
      ,"init": null
      ,toJSON: null
    }
  ]
  ,"init": null
  ,toJSON: null
}
