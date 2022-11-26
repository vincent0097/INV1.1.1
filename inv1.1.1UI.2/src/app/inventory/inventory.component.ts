import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Inventory } from './inventory';

@Component({
  selector: 'app-inventory',
  templateUrl: './inventory.component.html',
  styleUrls: ['./inventory.component.css']
})
export class InventoryComponent {
  public inventory:Inventory;
  constructor(){
    this.inventory=new Inventory();
  }

  onClick(){
    console.log();
  }

  onSubmit(data: NgForm) { 
    this.inventory=data.value; 
    console.log(this.inventory)
    if(1){
      alert("data saved")
    }
  }

}
