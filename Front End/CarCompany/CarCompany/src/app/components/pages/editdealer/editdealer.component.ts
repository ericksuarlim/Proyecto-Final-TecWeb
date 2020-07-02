import { Component, OnInit } from '@angular/core';
import { Dealer } from 'src/app/Model/dealer';
import { DealerService } from 'src/app/services/dealer.service';
import { ActivatedRoute } from '@angular/router';
import { unitOfTime } from 'moment';
import * as moment from 'moment';



@Component({
  selector: 'app-editdealer',
  templateUrl: './editdealer.component.html',
  styleUrls: ['./editdealer.component.css']
})
export class EditdealerComponent implements OnInit {

  dealer:Dealer;
  show:boolean=false;
  numbertoadd: number;
  opcionSeleccionada: string;
  constructor(private dealerService:DealerService, private route: ActivatedRoute) { }

  ngOnInit(): void {

    const dealerId = this.route.snapshot.paramMap.get("dealerId");
    console.log(dealerId);
    this.dealerService.getDealer(dealerId).subscribe(d => {
      this.dealer = d;
    }); 

  
  }

  onSubmit(dealer:Dealer){

    var date = moment(this.dealer.fundation).add(this.numbertoadd,  <unitOfTime.DurationConstructor>this.opcionSeleccionada).format();
    var fecha= date.toString();
    this.dealer.fundation= fecha;
    this.dealerService.updateDealer(dealer).subscribe(d => {
      console.log(d);
    });
    this.show=true;


  }
  

}
