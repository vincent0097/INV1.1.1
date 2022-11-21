import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';


@Component({
  selector: 'app-suppliers',
  templateUrl: './suppliers.component.html',
  styleUrls: ['./suppliers.component.css']
})
export class SuppliersComponent {

  usLogin(data: NgForm) {  
    console.log(data.value)
    if(1){
      alert("successful")
    }
  }
}
