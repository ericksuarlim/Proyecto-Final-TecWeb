import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DealerService } from 'src/app/services/dealer.service';
import { Dealer } from 'src/app/Model/dealer';

@Component({
  selector: 'app-showdealer',
  templateUrl: './showdealer.component.html',
  styleUrls: ['./showdealer.component.css']
})
export class ShowdealerComponent implements OnInit {


  dealer: Dealer;
  isDeleted: boolean =false;
  constructor(private dealerService:DealerService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    const dealerId = this.route.snapshot.paramMap.get("dealerId");
    console.log(dealerId);
    this.dealerService.getDealer(dealerId).subscribe(d => {
      this.dealer = d;
    }); 
  }

  DeleteDealer(dealertoDelete:Dealer){
    this.isDeleted =true;
    this.dealerService.deleteDealer(dealertoDelete).subscribe(); 

  }

}
