import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router} from '@angular/router';
import { RegisterModel } from '../../models/register.model';
import { AuthService } from '../../services/auth.service';
@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.scss']
})
export class RegisterFormComponent implements OnInit {

  constructor(private authService:AuthService,private router:Router) { }

  ngOnInit(): void {
    this.registerForm = new FormGroup({
      email:new FormControl('',[Validators.required,Validators.email]),
      password:new FormControl('',Validators.required),
    })
  }

  registerForm:FormGroup;
  registerModel:RegisterModel;
  

  onSubmit()
  {
    if(this.registerForm.valid)
    {
    this.registerModel = {
      email:this.registerForm.value.email,
      password:this.registerForm.value.password
    }

    this.authService.register(this.registerModel).subscribe(response => {
      if(response.token){
        this.router.navigate(['']);
      }
    });
    }
  }

 
}
