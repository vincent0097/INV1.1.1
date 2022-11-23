import { Component } from '@angular/core';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.css']
})
export class AboutComponent {
  onClick(data: NgForm ){
    console.log(value);
  }
  onSubmit(){
      /*console.log("Form Submitted!");*/
      
  }
}