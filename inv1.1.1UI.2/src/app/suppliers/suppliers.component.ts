import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Suppliers } from './suppliers';


@Component({
  selector: 'app-suppliers',
  templateUrl: './suppliers.component.html',
  styleUrls: ['./suppliers.component.css']
})
export class SuppliersComponent {
  public suppliers:Suppliers;
  constructor(){
    this.suppliers=new Suppliers();
  }

  onClick(){
    console.log();
  }

  onSubmit(data: NgForm) { 
    this.suppliers=data.value; 
    console.log(this.suppliers)
    if(1){
      alert("data saved")
    }
  }
  
}
