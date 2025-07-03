import { Component } from '@angular/core';
import {BillApiService} from 'src/app/services/bill-api.service';
import {OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit  {
  title = 'BillApp';
  isUserLoggedIn: boolean = false;

  constructor(private bireysel: BillApiService) {}

  ngOnInit(): void {
    this.checkAuthentication();
  }

  checkAuthentication() {
    this.isUserLoggedIn = this.bireysel.isLoggedIn();
  }
  signOut() {
    this.bireysel.signOut(); 
    this.isUserLoggedIn = false;
  }
}
