import { Component, OnInit } from '@angular/core';
import { Dealer } from 'src/app/Model/dealer';
import { DealerService } from 'src/app/services/dealer.service';

@Component({
  selector: 'app-dealerlist',
  templateUrl: './dealerlist.component.html',
  styleUrls: ['./dealerlist.component.css']
})
export class DealerlistComponent implements OnInit {

  dealers:Dealer[];
  
  constructor(private dealerService:DealerService) { }

  ngOnInit(): void {
    this.dealerService.getDealers().subscribe(dealers=>{this.dealers=dealers});
  }

  DeleteDealer(dealertoDelete:Dealer){
    this.dealers =this.dealers.filter(r=>r.id !==dealertoDelete.id);
    console.log(this.dealers);
    this.dealerService.deleteDealer(dealertoDelete).subscribe();
  }



}
