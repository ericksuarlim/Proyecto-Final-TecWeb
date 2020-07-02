import { Component, Input, OnInit } from '@angular/core';
import { Feedback } from 'src/app/Model/feedback';

@Component({
  selector: 'app-feedback',
  templateUrl: './feedback.component.html',
  styleUrls: ['./feedback.component.css']
})
export class FeedbackComponent implements OnInit {

  @Input() feedbackInput: Feedback;
  constructor() { }

  ngOnInit(): void {
  }

}
