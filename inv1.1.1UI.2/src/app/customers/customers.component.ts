
import { HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { CustomersService } from '../customers.service';
import { Customers } from './customers';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})


export class CustomersComponent  implements OnInit{

  public isUpdate=false;
  public customers: Customers;
  public customerslist:Customers[] | undefined;
  constructor( private customersService: CustomersService){
    this.customers=new Customers();
  }
    
  
  ngOnInit(): void {
    this.getCustomers();
  }

  onClick(){
    console.log();
  }
  editCustomer(data:Customers){
     this.customers=data;
     this.isUpdate=true;
  }
  deleteCustomer(data: Number){
    console.log(data)
    this.customersService.DeleteCustomers(data).subscribe(
      (response:any) =>{

        if(response=="Deleted Successfully"){
          this.getCustomers()
          alert("Customer Deleted")
          
        }
      },
      (error: HttpErrorResponse) => {
        alert(error.message);
      }
    );

  }

  onSubmit(data: NgForm) { 
    this.customers=data.value; 
    if(this.isUpdate){
      this.customersService.updateCustomers(this.customers).subscribe(
        (response:any) =>{
  
          if(response=="Updated Successfully"){
            this.getCustomers()
            this.isUpdate=false;
            alert("Customer Updated")
            
          }
        },
        (error: HttpErrorResponse) => {
          alert("failed to update: "+error.message);
        }
      );
    }else{
        this.customers.CustomerID=0;
        this.customersService.createCustomers(this.customers).subscribe(
          (response:any) =>{
    
            if(response=="Added Successfully"){
              this.getCustomers()
              alert("Customer saved")
            }
          },
          (error: HttpErrorResponse) => {
            alert("failed to create: "+error.message);
          }
        );
      }
  }


  public getCustomers(): void{
    this.customersService.getCustomers().subscribe(
      (response:Customers[]) =>{
        this.customerslist = response;
        console.log(this.customerslist)
      },
      (error: HttpErrorResponse) => {
        alert(error.message);
      }
    );
  }
}
