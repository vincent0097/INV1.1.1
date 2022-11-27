import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { CustomersService } from '../customers.service';
import { Suppliers } from './suppliers';


@Component({
  selector: 'app-suppliers',
  templateUrl: './suppliers.component.html',
  styleUrls: ['./suppliers.component.css']
})
export class SuppliersComponent implements OnInit{

  public isUpdate=false;
  public suppliers: Suppliers;
  public supplierslist:Suppliers[] | undefined;
  constructor( private customersService: CustomersService){
    this.suppliers=new Suppliers();
  }
    
  
  ngOnInit(): void {
    this.getSuppliers();
  }

  onClick(){
    console.log();
  }
  editSupplier(data:Suppliers){
     this.suppliers=data;
     this.isUpdate=true;
  }
  deleteSupplier(data: Number){
    console.log(data)
    this.customersService.DeleteSuppliers(data).subscribe(
      (response:any) =>{

        if(response=="Deleted Successfully"){
          this.getSuppliers()
          alert("Supplier Deleted")
          
        }
      },
      (error: HttpErrorResponse) => {
        alert(error.message);
      }
    );

  }

  onSubmit(data: NgForm) { 
    this.suppliers=data.value; 
    if(this.isUpdate){
      this.customersService.updateSuppliers(this.suppliers).subscribe(
        (response:any) =>{
  
          if(response=="Updated Successfully"){
            this.getSuppliers()
            this.isUpdate=false;
            alert("Supplier Updated")
            
          }
        },
        (error: HttpErrorResponse) => {
          alert("failed to update: "+error.message);
        }
      );
    }else{
        this.suppliers.SupplierID=0;
        this.customersService.createSuppliers(this.suppliers).subscribe(
          (response:any) =>{
    
            if(response=="Added Successfully"){
              this.getSuppliers()
              alert("Supplier saved")
              
            }
          },
          (error: HttpErrorResponse) => {
            alert("failed to create: "+error.message);
          }
        );
      }
  }


  public getSuppliers(): void{
    this.customersService.getSuppliers().subscribe(
      (response:Suppliers[]) =>{
        this.supplierslist = response;
        console.log(this.supplierslist)
      },
      (error: HttpErrorResponse) => {
        alert(error.message);
      }
    );
  }
}
