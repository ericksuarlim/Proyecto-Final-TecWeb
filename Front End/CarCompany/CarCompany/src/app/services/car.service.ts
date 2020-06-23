import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Car } from '../Model/car';
import { HttpClient, HttpHeaders } from '@angular/common/http';


const httpOptions = {
  headers : new HttpHeaders({
    'Content-Type':'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class CarService {


  carUrl: string = "https://localhost:44322/api/dealers";
  constructor(private http:HttpClient) { }

  getCars(idCompany:number):Observable<Car[]>{
    return this.http.get<Car[]>( this.carUrl + `/${idCompany}` + `/cars`);
   
  }

  deleteCar(cartoDelete:Car):Observable<Car>{
    
    console.log("Eliminando");
    console.log(cartoDelete.id);
    console.log(cartoDelete.dealerId);
    return this.http.delete<Car>(this.carUrl + `/${cartoDelete.dealerId}` + `/cars` + `/${cartoDelete.id}`);
    
  }

 
  getCar(idCar:string, idDealer:string): Observable<Car>{

    return this.http.get<Car>(`${this.carUrl}/${idDealer}/cars/${idCar}`);
  }

  createCar(car:Car):Observable<Car>{
  
    return this.http.post<any>(`${this.carUrl}/${car.dealerId}/cars`, car, httpOptions);
  }

  updateCar(car:Car):Observable<any>{
    return this.http.put(`${this.carUrl}/${car.dealerId}/cars/${car.id}`, car, httpOptions);
  }


}
