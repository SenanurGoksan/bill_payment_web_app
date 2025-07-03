
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { FaturaService } from 'src/app/services/fatura.service';
import { BillApiService } from 'src/app/services/bill-api.service';
import { ActivatedRoute } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';


@Component({
  selector: 'app-fatura',
  templateUrl: './fatura.component.html',
  styleUrls: ['./fatura.component.css']
})
export class FaturaComponent implements OnInit {
  public faturaForm!: FormGroup;
  constructor(
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private fatura: FaturaService,
    private router: Router,
    private billApiService: BillApiService,
    private toast: NgToastService

  ) {}

  ngOnInit() {
    
    // Fatura formunu başlat
    this.faturaForm = this.fb.group({
      kurumId: ['', Validators.required],
      kurumAdi: ['', Validators.required],
      firstName: ['', Validators.required],
      lastName:['', Validators.required],
      userId: ['', Validators.required],
      tutar: ['', Validators.required]
    });
  
  }
  submitForm() {
    if (this.faturaForm.valid) {
      const formData = {
        kurumId: this.faturaForm.get('kurumId')?.value,
        kurumAdi: this.faturaForm.get('kurumAdi')?.value,
        firstName: this.faturaForm.get('firstName')?.value,
        lastName: this.faturaForm.get('lastName')?.value,
        userId: this.faturaForm.get('userId')?.value,
        tutar: this.faturaForm.get('tutar')?.value
      };

      this.fatura.addFatura(formData).subscribe({
        next: (res) => {
          console.log(res.message);
          this.faturaForm.reset();
          this.toast.success({detail:"Fatura Başarıyla Oluşturuldu.", summary:res.message,duration:5000});
          this.router.navigate(['/fatura']);
        },
        error: (err) => {
          this.toast.success({detail:"HATA!", summary:"Bir Şeyler Yanlış Gitti!",duration:5000});
          console.log(err);
        }
      });
    }
  }
}


