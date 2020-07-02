import { Injectable } from '@angular/core';
import { Feedback } from '../Model/feedback';

@Injectable({
  providedIn: 'root'
})
export class FeedbackService {

  feedbacks: Feedback[];
  constructor() { this.feedbacks=[
    {
      id: 1,
      name: "Juan",
      coment: "Muy buena pagina!"

    },
    {
      id: 2,
      name: "Pepito",
      coment: "Falta trabajo muchachos!"

    }
  ]; }

  getfeedbacks(){
   return this.feedbacks;   
  }
  
  createFeedBack(feedback:Feedback){
    console.log('Feedback llegado',feedback);
    var freeId = this.feedbacks.length +1;
    feedback.id=freeId;
    console.log('Feedback para salir',feedback);
    this.feedbacks.push(feedback);
  }
}
