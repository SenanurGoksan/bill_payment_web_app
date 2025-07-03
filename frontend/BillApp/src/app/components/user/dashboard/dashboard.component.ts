import { Component } from '@angular/core';
import { OnInit } from '@angular/core';
import {BillApiService} from 'src/app/services/bill-api.service';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})

export class DashboardComponent implements OnInit {

  public users:any = [];
  constructor( private bireysel: BillApiService, ) { }

  ngOnInit() {
    this.bireysel.getBireyselList()
    .subscribe(res=>{
    this.users = res;
    });

   /* this.userStore.getFullNameFromStore()
    .subscribe(val=>{
      const fullNameFromToken = this.auth.getfullNameFromToken();
      this.fullName = val || fullNameFromToken
    });

    this.userStore.getRoleFromStore()
    .subscribe(val=>{
      const roleFromToken = this.auth.getRoleFromToken();
      this.role = val || roleFromToken;
    })*/
  }

  logout(){
    this.bireysel.signOut();
    console.log("Çıkış işlemi gerçekleştirildi."); // veya istediğiniz işlemi burada yapabilirsiniz

  }

}