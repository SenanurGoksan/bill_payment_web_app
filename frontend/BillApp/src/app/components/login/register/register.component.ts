import { Component } from '@angular/core';
import {Observable} from 'rxjs';
import {BillApiService} from 'src/app/services/bill-api.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import {OnInit } from '@angular/core';
import { NgToastService } from 'ng-angular-popup';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})


export class RegisterComponent implements OnInit {
  public signUpForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private bireysel: BillApiService, 
    private router: Router,
    private toast: NgToastService

  ) {}

  ngOnInit() {
    this.signUpForm = this.fb.group({
      firstName: ['', [Validators.required,Validators.minLength(3)]],
      lastName: ['', [Validators.required,Validators.minLength(3)]],
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required]
    });
  }
  onSubmit() {
    if (this.signUpForm.valid) {
      const formData = {
        firstName: this.signUpForm.get('firstName')?.value,
        lastName: this.signUpForm.get('lastName')?.value,
        parola: this.signUpForm.get('password')?.value,
        email:this.signUpForm.get('email')?.value
      };
      
      this.bireysel.addBireysel(formData).subscribe({
        next: (res) => {
          console.log(res.message);
          this.signUpForm.reset();
          this.toast.success({detail:"Kullanıcı Kaydı Başarıyla Gerçekleştirildi.", summary:res.message,duration:5000});
          this.router.navigate(['/Giris/Bireysel']);
        },
        error: (err) => {
          this.toast.success({detail:"ERROR", summary:"Bir Şeyler Yanlış Gitti!",duration:5000});
          console.log(err);
        }
      });
    }
  
  }}
  
  