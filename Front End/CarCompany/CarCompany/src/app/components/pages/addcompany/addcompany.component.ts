import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Dealer } from 'src/app/Model/dealer';
import { DealerService } from 'src/app/services/dealer.service';


@Component({
  selector: 'app-addcompany',
  templateUrl: './addcompany.component.html',
  styleUrls: ['./addcompany.component.css']
})
export class AddcompanyComponent implements OnInit {


  name: string;
  address: string;
  phone: number;
  fundation: string;
  show:boolean=false;
  dealer:Dealer;
    

  constructor(private dealerService:DealerService) { }


  ngOnInit(): void {
  }

  onSubmit(){
    var dealertoSend= new Dealer();
    dealertoSend.name=this.name;
    dealertoSend.address= this.address;
    dealertoSend.phone= this.phone;
    dealertoSend.fundation= this.fundation;
   this.dealerService.createDealer(dealertoSend).subscribe(d =>{this.dealer=d});
   this.show=true;

  }

}
