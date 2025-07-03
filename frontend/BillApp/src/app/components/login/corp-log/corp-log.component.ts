import { Component } from '@angular/core';
import {Observable} from 'rxjs';
import {BillApiService} from 'src/app/services/bill-api.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import {OnInit } from '@angular/core';
import { NgToastService } from 'ng-angular-popup';


@Component({
  selector: 'app-corp-log',
  templateUrl: './corp-log.component.html',
  styleUrls: ['./corp-log.component.css']
})
export class CorpLogComponent implements OnInit {
  public corpLogForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private kurumsal: BillApiService, 
    private router: Router,
    private toast: NgToastService

  ) {}

  ngOnInit() {
    this.corpLogForm = this.fb.group({
      kurumAdi: ['', Validators.required],
      password: ['', Validators.required], 
      userMail: ['', Validators.required]

    });
    
   
  }
  
  onSubmit() {
    if (this.corpLogForm.valid) {
      const formData = {
        kurumAdi: this.corpLogForm.get('kurumAdi')?.value,
        password: this.corpLogForm.get('password')?.value,
        adminMail: this.corpLogForm.get('userMail')?.value,

      };
  
      this.kurumsal.addKurumsal(formData).subscribe({
        next: (res) => {
          console.log(res.message);
          this.corpLogForm.reset();
          this.toast.success({detail:"Kullanıcı Girişi Başarılı!.", summary:res.message,duration:5000});
          this.router.navigate(['/dashboard'])
        },
        error: (err) => {
          this.toast.success({detail:"ERROR", summary:"Bir Şeyler Yanlış Gitti!",duration:5000});

          console.log(err);
        },
      });
  }}}


