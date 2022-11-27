import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { CustomersService } from '../customers.service';
import { Inventory } from './inventory';

@Component({
  selector: 'app-inventory',
  templateUrl: './inventory.component.html',
  styleUrls: ['./inventory.component.css']
})
export class InventoryComponent implements OnInit{

  public isUpdate=false;
  public inventory: Inventory;
  public inventorylist:Inventory[] | undefined;
  constructor( private CustomersService: CustomersService){
    this.inventory=new Inventory();
  }
    
  
  ngOnInit(): void {
    this.getInventory();
  }

  onClick(){
    console.log();
  }
  editInventory(data:Inventory){
     this.inventory=data;
     this.isUpdate=true;
  }
  deleteInventory(data: Number){
    console.log(data)
    this.CustomersService.DeleteInventory(data).subscribe(
      (response:any) =>{

        if(response=="Deleted Successfully"){
          this.getInventory()
          alert("Inventory Deleted")
          
        }
      },
      (error: HttpErrorResponse) => {
        alert(error.message);
      }
    );

  }

  onSubmit(data: NgForm) { 
    this.inventory=data.value; 
    if(this.isUpdate){
      this.CustomersService.updateInventory(this.inventory).subscribe(
        (response:any) =>{
  
          if(response=="Updated Successfully"){
            this.getInventory()
            this.isUpdate=false;
            alert("Inventory Updated")
            
          }
        },
        (error: HttpErrorResponse) => {
          alert("failed to update: "+error.message);
        }
      );
    }else{
        this.inventory.ProductID=0;
        this.CustomersService.createInventory(this.inventory).subscribe(
          (response:any) =>{
    
            if(response=="Added Successfully"){
              this.getInventory()
              alert("Inventory saved")
              
            }
          },
          (error: HttpErrorResponse) => {
            alert("failed to create: "+error.message);
          }
        );
      }
  }


  public getInventory(): void{
    this.CustomersService.getInventory().subscribe(
      (response:Inventory[]) =>{
        this.inventorylist = response;
        console.log(this.inventorylist)
      },
      (error: HttpErrorResponse) => {
        alert(error.message);
      }
    );
  }
}
