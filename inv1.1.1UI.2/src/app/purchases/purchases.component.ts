import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Purchases } from './purchases';

@Component({
  selector: 'app-purchases',
  templateUrl: './purchases.component.html',
  styleUrls: ['./purchases.component.css']
})
export class PurchasesComponent {
  public purchases:Purchases;
  constructor(){
    this.purchases=new Purchases();
  }

  onClick(){
    console.log();
  }

  onSubmit(data: NgForm) { 
    this.purchases=data.value; 
    console.log(this.purchases)
    if(1){
      alert("data saved")
    }
  }

}
