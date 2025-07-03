import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Observable } from 'rxjs';
import {Router} from '@angular/router';


@Injectable({
  providedIn: 'root'
})
export class BillApiService {

  readonly BillApiUrl="https://localhost:7245/api/";

  constructor(private http:HttpClient , private router: Router) { }

    getBireyselList():Observable<any[]>{
      return this.http.get<any>(this.BillApiUrl + 'bireysel');
    }
    addBireysel(data: any){
      return this.http.post<any>(`${this.BillApiUrl}bireysel`,data)
    };

    
    login(data: any): Observable<any> {
      return this.http.post<any>(this.BillApiUrl+ 'Bireysel/auth',data);
    }
  
  
    updateBireysel(id:number|string,data:any){
      return this.http.put(this.BillApiUrl+'/bireysel/${id}',data);
}

  deleteBireysel(id:number|string){
    return this.http.delete(this.BillApiUrl+'/bireysel/${id}');
  }
  

  //Kurumsal

  getKurumsalList():Observable<any[]>{
    return this.http.get<any>(this.BillApiUrl + '/kurumsal');
  }
  getKurumsalById(id: number): Observable<any> {
    return this.http.get<any>(`${this.BillApiUrl}kurumsal/${id}`); // Değişkeni çift tırnak içine alın
  }
  /*
  getKurumsalByID(id:number):any {
    return this.http.get(environment.apiURL + '/Kurumsal/'+id).toPromise();
  }*/

  
  addKurumsal(data: any): Observable<any> {
    return this.http.post<any>(this.BillApiUrl+ 'Kurumsal/login',data);
  }

  updateKurumsal(id:number|string,data:any){
    return this.http.put(this.BillApiUrl+'/kurumsal/${id}',data);
}

deleteKurumsal(id:number|string){
  return this.http.delete(this.BillApiUrl+'/kurumsal/${id}');
}

storeToken(tokenValue: string){
  localStorage.setItem('token', tokenValue)
}

getToken(){
  return localStorage.getItem('token')
}

isLoggedIn(): boolean{
  return !!localStorage.getItem('token')
}

signOut(){
  localStorage.clear();
  this.router.navigate(['/Giris/Bireysel'])
}
getRole(){
  return localStorage.getItem('role')
}
storeRole(roleValue: string){
  localStorage.setItem('role', roleValue)
}





}

