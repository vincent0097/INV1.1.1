import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { CustomersService } from '../customers.service';
import { Purchases } from './purchases';

@Component({
  selector: 'app-purchases',
  templateUrl: './purchases.component.html',
  styleUrls: ['./purchases.component.css']
})
export class PurchasesComponent implements OnInit{

  public isUpdate=false;
  public purchases: Purchases;
  public purchaseslist:Purchases[] | undefined;
  constructor( private customersService: CustomersService){
    this.purchases=new Purchases();
  }
    
  
  ngOnInit(): void {
    this.getPurchases();
  }

  onClick(){
    console.log();
  }
  editPurchase(data:Purchases){
     this.purchases=data;
     this.isUpdate=true;
  }
  deletePurchase(data: Number){
    console.log(data)
    this.customersService.DeletePurchases(data).subscribe(
      (response:any) =>{

        if(response=="Deleted Successfully"){
          this.getPurchases()
          alert("Purchase Deleted")
          
        }
      },
      (error: HttpErrorResponse) => {
        alert(error.message);
      }
    );

  }

  onSubmit(data: NgForm) { 
    this.purchases=data.value; 
    if(this.isUpdate){
      this.customersService.updatePurchases(this.purchases).subscribe(
        (response:any) =>{
  
          if(response=="Updated Successfully"){
            this.getPurchases()
            this.isUpdate=false;
            alert("Purchase Updated")
            
          }
        },
        (error: HttpErrorResponse) => {
          alert("failed to update: "+error.message);
        }
      );
    }else{
        this.purchases.PurchaseID=0;
        this.customersService.createPurchases(this.purchases).subscribe(
          (response:any) =>{
    
            if(response=="Added Successfully"){
              this.getPurchases()
              alert("Purchase saved")
              
            }
          },
          (error: HttpErrorResponse) => {
            alert("failed to create: "+error.message);
          }
        );
      }
  }


  public getPurchases(): void{
    this.customersService.getPurchases().subscribe(
      (response:Purchases[]) =>{
        this.purchaseslist = response;
        console.log(this.purchaseslist)
      },
      (error: HttpErrorResponse) => {
        alert(error.message);
      }
    );
  }
}
