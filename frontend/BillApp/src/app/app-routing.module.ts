import { NgModule } from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {CorporateComponent} from './components/login/corporate/corporate.component';
import { RegisterComponent } from './components/login/register/register.component';
import { LoginComponent } from './components/login/login/login.component';
import { CorpLogComponent } from './components/login/corp-log/corp-log.component';
import { FaturaComponent } from './components/admin/fatura/fatura.component';
import { FaturaSecComponent } from './components/user/fatura-sec/fatura-sec.component';
import { OdemeComponent } from './components/user/odeme/odeme.component';
import { AuthGuard } from './gurads/auth.guard';
import { DashboardComponent } from './components/user/dashboard/dashboard.component';


const routes: Routes =[
  {path:'', redirectTo:'dashboard', pathMatch:'full'},
  {path: 'PaymentTransactions/corporate', component: CorporateComponent},
  {path: 'Giris/Kaydol', component: RegisterComponent},
  {path: 'Giris/Bireysel', component:LoginComponent},
  {path: 'Giris/Kurumsal', component:CorpLogComponent},
  {path : 'fatura', component:FaturaComponent},
  {path : 'hizmet-veren-kurumlar', component:FaturaSecComponent},
  { path: 'odeme', component: OdemeComponent, canActivate:[AuthGuard] },
 {path: 'dashboard', component: DashboardComponent}
 
 
];

@NgModule({
  exports:[RouterModule],
  imports: [RouterModule.forRoot(routes)] 
      
})
export class AppRoutingModule { }
