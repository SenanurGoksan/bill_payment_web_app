import { Inject } from '@angular/core';
import { Injectable } from '@angular/core';

import { CanActivate, Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';
import {BillApiService} from 'src/app/services/bill-api.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(@Inject(BillApiService) private user: BillApiService, private router: Router, private toast: NgToastService) {}

  canActivate(): boolean {
    if (this.user.isLoggedIn()) {
      return true;
    } else {
      this.toast.error({ detail: "ERROR", summary: "Please Login First!" });
      this.router.navigate(['/Giris/Bireysel']);
      return false;
    }
  }/*
  canActivate(): boolean {
    const userRole = this.user.getRole();
  
    if (userRole === 'admin') {
      return true;
    } else if (userRole === 'user') {
      return true;
    } else {
      this.router.navigate(['/Giris/Bireysel']);
      return false;
    }
  }  */
}
