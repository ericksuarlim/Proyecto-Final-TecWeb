import { Component, OnInit, Input,EventEmitter, Output } from '@angular/core';

import { Car } from 'src/app/Model/car';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-car',
  templateUrl: './car.component.html',
  styleUrls: ['./car.component.css']
})
export class CarComponent implements OnInit {

  @Input() carInput: Car;
  @Output() cartoDelete: EventEmitter<Car> = new EventEmitter();

  constructor(private route: ActivatedRoute,private router: Router) { }


  ngOnInit(): void {
  }

  
  DeleteCar(){
    this.cartoDelete.emit(this.carInput);

  }

  ClickshowCar(){
    console.log(this.carInput.dealerId);
    console.log(this.carInput.id);
    this.router.navigateByUrl(`/dealers/${this.carInput.dealerId}/cars/${this.carInput.id}`);
  }

  ClickeditCar(){
    this.router.navigateByUrl(`/dealers/${this.carInput.dealerId}/cars/${this.carInput.id}/editcar`);
  }

  ClickmigrateCar(){
    this.router.navigateByUrl(`/dealers/${this.carInput.dealerId}/cars/${this.carInput.id}/migratecar`);
  }



}
