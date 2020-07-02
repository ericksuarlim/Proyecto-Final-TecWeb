import { Component, OnInit } from '@angular/core';
import { Car } from 'src/app/Model/car';
import { ActivatedRoute } from '@angular/router';
import { CarService } from 'src/app/services/car.service';

@Component({
  selector: 'app-migratecar',
  templateUrl: './migratecar.component.html',
  styleUrls: ['./migratecar.component.css']
})
export class MigratecarComponent implements OnInit {

  car:Car;
  idtomigrate: number;
  olddealer: string;
  show:boolean=false;


  constructor(private carService:CarService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    const carId = this.route.snapshot.paramMap.get("carId");
    const dealerId = this.route.snapshot.paramMap.get("dealerId");
    this.olddealer = dealerId;
    this.carService.getCar(carId,dealerId).subscribe(c => {
      this.car = c;
    }); 
  }

  onSubmit(){

    var cartoCreate= new Car();
    cartoCreate.brand=this.car.brand;
    cartoCreate.model= this.car.model;
    cartoCreate.price= this.car.price;
    cartoCreate.year= this.car.year;
    cartoCreate.dealerId= this.idtomigrate;
    this.carService.createCar(cartoCreate).subscribe(c =>{this.car=c});

    
    this.carService.deleteCar(this.car).subscribe(); 

    this.show=true;
    
  }

}
