import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.css']
})
export class AboutComponent {
  onClick(){
    console.log();
  }
  onSubmit(about:NgForm){
      console.log(about.value);
      
  }

}