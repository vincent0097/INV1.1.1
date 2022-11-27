import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { CustomersService } from '../customers.service';
import { Sales } from './sales';

@Component({
  selector: 'app-sales',
  templateUrl: './sales.component.html',
  styleUrls: ['./sales.component.css']
})
export class SalesComponent implements OnInit{

  public isUpdate=false;
  public sales: Sales;
  public saleslist:Sales[] | undefined;
  constructor( private customersService: CustomersService){
    this.sales=new Sales();
  }
    
  
  ngOnInit(): void {
    this.getSales();
  }

  onClick(){
    console.log();
  }
  editSales(data:Sales){
     this.sales=data;
     this.isUpdate=true;
  }
  deleteSales(data: Number){
    console.log(data)
    this.customersService.DeleteSales(data).subscribe(
      (response:any) =>{

        if(response=="Deleted Successfully"){
          this.getSales()
          alert("Sales Deleted")
          
        }
      },
      (error: HttpErrorResponse) => {
        alert(error.message);
      }
    );

  }

  onSubmit(data: NgForm) { 
    this.sales=data.value; 
    if(this.isUpdate){
      this.customersService.updateSales(this.sales).subscribe(
        (response:any) =>{
  
          if(response=="Updated Successfully"){
            this.getSales()
            this.isUpdate=false;
            alert("Sales Updated")
            
          }
        },
        (error: HttpErrorResponse) => {
          alert("failed to update: "+error.message);
        }
      );
    }else{
        this.sales.SalesID=0;
        this.customersService.createSales(this.sales).subscribe(
          (response:any) =>{
    
            if(response=="Added Successfully"){
              this.getSales()
              alert("Sales saved")
              
            }
          },
          (error: HttpErrorResponse) => {
            alert("failed to create: "+error.message);
          }
        );
      }
  }


  public getSales(): void{
    this.customersService.getSales().subscribe(
      (response:Sales[]) =>{
        this.saleslist = response;
        console.log(this.saleslist)
      },
      (error: HttpErrorResponse) => {
        alert(error.message);
      }
    );
  }
} 