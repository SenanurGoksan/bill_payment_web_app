
    import { Component, OnInit } from '@angular/core';
    import { FormBuilder, FormGroup, Validators } from '@angular/forms';
    import { Router } from '@angular/router';
    import { FaturaService } from 'src/app/services/fatura.service';
    import { BillApiService } from 'src/app/services/bill-api.service';
    import { NgToastService } from 'ng-angular-popup';

    
    @Component({
      selector: 'app-odeme',
      templateUrl: './odeme.component.html',
      styleUrls: ['./odeme.component.css']
    })
    export class OdemeComponent implements OnInit {
      public odemeForm!: FormGroup;
      public fatura: any;
      faturaNo: string;
    
      constructor(
        private fb: FormBuilder, 
        private faturaService: FaturaService,
        private router: Router,
        private billApiService: BillApiService ,
        private toast: NgToastService

      ) {
        this.faturaNo = ''; // Başlangıçta boş bir faturaNo tanımlıyoruz
      }
    
      getFaturaInfo() {
        if (this.faturaNo) {
          this.faturaService.getFaturaByNo(this.faturaNo).subscribe(
            data => {
              this.fatura = data;
            },
            (err) => {
              this.toast.success({ detail: "HATA!", summary: "Bu Numaraya Ait Fatura Bulunmamaktadır.", duration: 5000 })
              console.error('Fatura bilgileri alınırken bir hata oluştu:', err);
            }
          );
        } else {
          this.fatura = null;
        }
      }
    
      ngOnInit(): void {
        this.odemeForm = this.fb.group({
          faturaId: ['', Validators.required],
          odemeTarihi: ['', Validators.required],
          odemeMiktari: ['', Validators.required]
        });     
      }
    
      faturaOde() {
        if (this.faturaNo) {
          this.faturaService.deleteFatura(this.faturaNo).subscribe(
            (res: any) => { 
              console.log(`Fatura No: ${this.faturaNo} ödendi ve silindi.`);
              this.odemeForm.reset();
              this.toast.success({ detail: "Fatura Ödeme İşlemi Başarılı.", summary: res.message, duration: 5000 });
              this.router.navigate(['/odeme']);
            },
            (err) => {
              this.toast.success({ detail: "HATA!", summary: "Bir Şeyler Yanlış Gitti!", duration: 5000 });
              console.log(err);
            }
          );
        }
      }
      
      
    }
    
