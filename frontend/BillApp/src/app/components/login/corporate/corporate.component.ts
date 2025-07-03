import { Component } from '@angular/core';
import {Observable} from 'rxjs';
import {BillApiService} from 'src/app//services/bill-api.service';
import { OnInit } from '@angular/core';


@Component({
  selector: 'app-corporate',
  templateUrl: './corporate.component.html',
  styleUrls: ['./corporate.component.css']
})
export class CorporateComponent implements OnInit {

    BireyselList$!:Observable<any[]>;
    KurumsalList$! : Observable <any[]>;


  constructor(private service:BillApiService) {
    
  }
  ngOnInit(): void{

  }}


