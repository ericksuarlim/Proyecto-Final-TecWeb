import { Component, OnInit } from '@angular/core';
import { Car } from 'src/app/Model/car';
import { CarService } from 'src/app/services/car.service';

@Component({
  selector: 'app-addcar',
  templateUrl: './addcar.component.html',
  styleUrls: ['./addcar.component.css']
})
export class AddcarComponent implements OnInit {

  brand: string;
  model: string;
  price: number;
  year: number;
  dealerId:number; 
  show: boolean=false;
  car:Car;

  constructor(private carService:CarService) { }

  ngOnInit(): void {
  }

  onSubmit(){
    var cartoSend= new Car();
    cartoSend.brand=this.brand;
    cartoSend.model= this.model;
    cartoSend.price= this.price;
    cartoSend.year= this.year;
    cartoSend.dealerId= this.dealerId;
    this.carService.createCar(cartoSend).subscribe(c =>{this.car=c});
    this.show=true;
  }

}
