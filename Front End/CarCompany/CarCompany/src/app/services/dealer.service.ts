import { Injectable } from '@angular/core';
import{HttpClient, HttpHeaders} from '@angular/common/http';
import { Dealer } from '../Model/dealer';
import { Observable } from 'rxjs';

const httpOptions = {
  headers : new HttpHeaders({
    'Content-Type':'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class DealerService {

  dealerUrl: string = "https://localhost:44322/api/dealers";
  constructor(private http:HttpClient) { }

  getDealers(): Observable<Dealer[]>{
    console.log("getDealerService OK");
    return this.http.get<Dealer[]>(this.dealerUrl);
  }

  deleteDealer(dealer:Dealer): Observable<Dealer>{
    return this.http.delete<Dealer>(this.dealerUrl+ `/${dealer.id}`);
  }

  getDealer(idDealer:string): Observable<Dealer>{
    return this.http.get<Dealer>(`${this.dealerUrl}/${idDealer}`);
  }

  createDealer(dealertoCreate:Dealer):Observable<Dealer>{
    return this.http.post<any>(this.dealerUrl, dealertoCreate, httpOptions);
  }

  updateDealer(dealertoUpdate:Dealer):Observable<any>{
    return this.http.put(`${this.dealerUrl}/${dealertoUpdate.id}`, dealertoUpdate, httpOptions);
  }



  

}
