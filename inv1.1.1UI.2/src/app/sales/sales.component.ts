import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Sales } from './sales';

@Component({
  selector: 'app-sales',
  templateUrl: './sales.component.html',
  styleUrls: ['./sales.component.css']
})
export class SalesComponent {
  public sales:Sales;
  constructor(){
    this.sales=new Sales();
  }

  onClick(){
    console.log();
  }

  onSubmit(data: NgForm) { 
    this.sales=data.value; 
    console.log(this.sales)
    if(1){
      alert("data saved")
    }
  }

}
