import { Component, OnInit } from '@angular/core';
import { Car } from 'src/app/Model/car';
import { ActivatedRoute } from '@angular/router';
import { CarService } from 'src/app/services/car.service';

@Component({
  selector: 'app-showcar',
  templateUrl: './showcar.component.html',
  styleUrls: ['./showcar.component.css']
})
export class ShowcarComponent implements OnInit {

  car:Car;
  isDeleted:boolean= false;
  constructor(private carService:CarService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    const carId = this.route.snapshot.paramMap.get("carId");
    const dealerId = this.route.snapshot.paramMap.get("dealerId");
    
    this.carService.getCar(carId,dealerId).subscribe(c => {
      this.car = c;
    }); 
  }

  DeleteCar(cartoDelete:Car){
    this.isDeleted=true;
    this.carService.deleteCar(cartoDelete).subscribe();
  }


}
