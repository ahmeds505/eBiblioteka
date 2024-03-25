import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../moj-config";

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css']
})
export class ShoppingCartComponent implements OnInit {

  cartPodaci: any;

  constructor(private http:HttpClient) { }

  ngOnInit(): void {
    this.getShoppingCart();
  }

  getShoppingCart(){
    this.http.get(MojConfig.adresa_servera_localhost + "/ShoppingCart/GetShoppingCart", MojConfig.http_opcije())
      .subscribe((x:any) => {
        this.cartPodaci = x;
      });
  }
}
