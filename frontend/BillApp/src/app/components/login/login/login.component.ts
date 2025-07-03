import { Component } from '@angular/core';
import {Observable} from 'rxjs';
import {BillApiService} from 'src/app/services/bill-api.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import {OnInit } from '@angular/core';
import { NgToastService } from 'ng-angular-popup';
 
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public loginForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private bireysel: BillApiService, 
    private router: Router,
    private toast: NgToastService
  ) {}

  ngOnInit() {
    this.loginForm = this.fb.group({
      password: ['', Validators.required], 
      email: ['', Validators.required]

    });
  }
  
  onSubmit() {
    if (this.loginForm.valid) {
      const formData = {
        parola: this.loginForm.get('password')?.value,
        email: this.loginForm.get('email')?.value,

      };
  
      this.bireysel.login(formData).subscribe({
        next: (res) => {
          console.log(res.message);
          this.loginForm.reset();
          this.bireysel.storeToken(res.token)
          this.toast.success({detail:"Kullanıcı Girişi Başarılı!", summary:res.message,duration:5000});
          this.router.navigate(['/dashboard'])
        },
        error: (err) => {
          this.toast.success({detail:"ERROR", summary:"Bir Şeyler Yanlış Gitti!",duration:5000});
          console.log(err);
        },
      });
  }}}
  
  
  
  