import { Component, OnInit } from '@angular/core';
import { CarService } from 'src/app/services/car.service';
import { Car } from 'src/app/Model/car';
import { ActivatedRoute, Router } from '@angular/router';
import { ConstantPool } from '@angular/compiler';

@Component({
  selector: 'app-carlist',
  templateUrl: './carlist.component.html',
  styleUrls: ['./carlist.component.css']
})


export class CarlistComponent implements OnInit {

  cars:Car[];
  carbrandtoSearch: string;
  constructor(private carService:CarService, private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    const dealerId = this.route.snapshot.paramMap.get("dealerId");
    var y: number = +dealerId;
    this.carService.getCars(y).subscribe(cars=>{this.cars=cars});
   
  }



  DeleteCar(cartoDelete:Car){
    this.cars =this.cars.filter(r=>r.id !==cartoDelete.id);
    this.carService.deleteCar(cartoDelete).subscribe();
  }

  onSubmit() {
    console.log(this.carbrandtoSearch);
    this.cars = this.cars.filter(r=>r.brand == this.carbrandtoSearch);
    console.log(this.cars);

  }




}
