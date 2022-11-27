import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { CustomersService } from '../customers.service';
import { Transactions } from './transactions';

@Component({
  selector: 'app-transactions',
  templateUrl: './transactions.component.html',
  styleUrls: ['./transactions.component.css']
})
export class TransactionsComponent implements OnInit {

  public isUpdate=false;
  public transactions: Transactions;
  public transactionslist:Transactions[] | undefined;
  constructor( private customersService: CustomersService){
    this.transactions=new Transactions();
  }

  ngOnInit(): void {
    this.getTransactions();
  }

  onClick(){
    console.log();
  }
  editTransaction(data:Transactions){
    this.transactions=data;
    this.isUpdate=true;
 }
 deleteTransaction(data: Number){
  console.log(data)
  this.customersService.DeleteCustomers(data).subscribe(
    (response:any) =>{

      if(response=="Deleted Successfully"){
        this.getTransactions()
        alert("Transaction Deleted")
        
      }
    },
    (error: HttpErrorResponse) => {
      alert(error.message);
    }
  );

}

  onSubmit(data: NgForm) { 
    this.transactions=data.value; 
    if(this.isUpdate){
      this.customersService.updateTransactions(this.transactions).subscribe(
        (response:any) =>{
  
          if(response=="Updated Successfully"){
            this.getTransactions()
            this.isUpdate=false;
            alert("Transaction Updated")
            
          }
        },
        (error: HttpErrorResponse) => {
          alert("failed to update: "+error.message);
        }
      );
    }else{
        this.transactions.TransactionID=0;
        this.customersService.createTransactions(this.transactions).subscribe(
          (response:any) =>{
    
            if(response=="Added Successfully"){
              this.getTransactions()
              alert("Transaction saved")
              
            }
          },
          (error: HttpErrorResponse) => {
            alert("failed to create: "+error.message);
          }
        );
      }
  }
  public getTransactions(): void{
    this.customersService.getTransactions().subscribe(
      (response:Transactions[]) =>{
        this.transactionslist = response;
        console.log(this.transactionslist)
      },
      (error: HttpErrorResponse) => {
        alert(error.message);
      }
    );
  }
}
