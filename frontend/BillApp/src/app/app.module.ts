import { NgModule } from '@angular/core'; 
import { NgToastModule } from 'ng-angular-popup'
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { CorporateComponent } from './components/login/corporate/corporate.component';
import { AppRoutingModule } from './app-routing.module';
import { RegisterComponent } from './components/login/register/register.component';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule,ReactiveFormsModule} from '@angular/forms';

import {BillApiService} from './services/bill-api.service';
import { LoginComponent } from './components/login/login/login.component';
import { CorpLogComponent } from './components/login/corp-log/corp-log.component';
import { CorpRegComponent } from './components/login/corp-reg/corp-reg.component';
import { FaturaSecComponent } from './components/user/fatura-sec/fatura-sec.component';
import { FaturaComponent } from './components/admin/fatura/fatura.component';
import { OdemeComponent } from './components/user/odeme/odeme.component';
import { DashboardComponent } from './components/user/dashboard/dashboard.component';

@NgModule({
  declarations: [
    AppComponent,
    CorporateComponent,
    RegisterComponent,
    LoginComponent,
    CorpLogComponent,
    CorpRegComponent,
    FaturaSecComponent,
    FaturaComponent,
    OdemeComponent,
    DashboardComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgToastModule
  ], 
  providers: [BillApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
