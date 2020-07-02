import { Component, OnInit } from '@angular/core';
import { Feedback } from 'src/app/Model/feedback';
import { FeedbackService } from 'src/app/services/feedback.service';

@Component({
  selector: 'app-addfeedback',
  templateUrl: './addfeedback.component.html',
  styleUrls: ['./addfeedback.component.css']
})
export class AddfeedbackComponent implements OnInit {

  name: string;
  coment:string;
  show: boolean=false;
  constructor(private service:FeedbackService) { }

  ngOnInit(): void {
  }

  onSubmit()
  {
    var feedbacktosend= new Feedback();
    feedbacktosend.name=this.name;
    feedbacktosend.coment= this.coment;
    this.service.createFeedBack(feedbacktosend);
    this.show=true;

  }

}
