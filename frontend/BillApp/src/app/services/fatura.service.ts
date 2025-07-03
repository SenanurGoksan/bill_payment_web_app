import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FaturaService {
 readonly FaturaUrl="https://localhost:7245/api/";

  constructor(private http:HttpClient) { }

    getFatura():Observable<any[]>{
      return this.http.get<any>(this.FaturaUrl + '/fatura');
    }
    
    getFaturaByNo(faturaNo: string): Observable<any> {
      return this.http.get<any>(this.FaturaUrl+ 'Fatura/deneme?faturaNo='+faturaNo);
    }
  
    
    addFatura(data: any):Observable<any> {
      return this.http.post<any>(this.FaturaUrl+ 'Fatura/create',data);
    }
      /*return this.http.post<any>(`${this.FaturaUrl}fatura`,data)
    };*/
  
    updateFatura(id:number|string,data:any){
      return this.http.put(this.FaturaUrl+'/fatura/${id}',data);
}

  deleteFatura(faturaNo: string){ 
    return this.http.delete(this.FaturaUrl+'Fatura?faturaNo='+faturaNo);
  }
  faturaOde(faturaNo: string) {
    return this.http.post(`${this.FaturaUrl}/fatura/${faturaNo}`, {});
  }
  storeFaturaNo(faturaNoValue: string){
    localStorage.setItem('faturaNo', faturaNoValue)
  }
  
  getFaturaNo(){
    return localStorage.getItem('faturaNo')
  }
}
