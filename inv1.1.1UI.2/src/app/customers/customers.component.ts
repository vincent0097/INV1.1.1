import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})


export class CustomersComponent {

  cusRegister(data: NgForm) {  
    console.log(data.value)
    if(1){
      alert("data saved")
    }
  }
}
