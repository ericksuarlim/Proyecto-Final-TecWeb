import { Component, OnInit } from '@angular/core';
import { Feedback } from 'src/app/Model/feedback';
import { FeedbackService } from 'src/app/services/feedback.service';

@Component({
  selector: 'app-listfeedback',
  templateUrl: './listfeedback.component.html',
  styleUrls: ['./listfeedback.component.css']
})
export class ListfeedbackComponent implements OnInit {

  feedbacks: Feedback[];
  service: FeedbackService;
  constructor( service: FeedbackService) {
    this.service =service;
   }

  ngOnInit(): void {
    
    this.feedbacks = this.service.getfeedbacks();
  }




}
