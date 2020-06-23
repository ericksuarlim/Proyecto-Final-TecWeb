import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { Dealer } from 'src/app/Model/dealer';
import { DealerService } from 'src/app/services/dealer.service';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-dealer',
  templateUrl: './dealer.component.html',
  styleUrls: ['./dealer.component.css']
})
export class DealerComponent implements OnInit {

  dealer:Dealer;
  @Input() dealerInput: Dealer;
  @Output() dealertoDelete: EventEmitter<Dealer> = new EventEmitter();
  
  constructor(private dealerService:DealerService,private route: ActivatedRoute,
    private router: Router) { }

 
  
  ngOnInit(): void {

  }

  DeleteDealer(){
    this.dealertoDelete.emit(this.dealerInput);
  
  }

  ClickSeeMore()
  {
    this.router.navigateByUrl(`/dealers/${this.dealerInput.id}/cars`);
  }

  ClickEdit(){
    this.router.navigateByUrl(`/dealers/${this.dealerInput.id}/editdealer`);

  }




}
