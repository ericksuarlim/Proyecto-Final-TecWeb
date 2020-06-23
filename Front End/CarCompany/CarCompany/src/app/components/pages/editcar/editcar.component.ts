import { Component, OnInit } from '@angular/core';
import { Car } from 'src/app/Model/car';
import { CarService } from 'src/app/services/car.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-editcar',
  templateUrl: './editcar.component.html',
  styleUrls: ['./editcar.component.css']
})
export class EditcarComponent implements OnInit {

  car:Car;
  show:boolean=false;
  constructor(private carService:CarService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    const carId = this.route.snapshot.paramMap.get("carId");
    const dealerId = this.route.snapshot.paramMap.get("dealerId");
    
    this.carService.getCar(carId,dealerId).subscribe(c => {
      this.car = c;
    }); 
    
  }

  onSubmit(car:Car){
    this.carService.updateCar(car).subscribe(c => {
      console.log(c);
    });
    this.show=true;
  }

}
