import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DealerlistComponent } from './components/dealerlist/dealerlist.component';
import { AddcompanyComponent } from './components/pages/addcompany/addcompany.component';
import { EditdealerComponent } from './components/pages/editdealer/editdealer.component';
import { ShowdealerComponent } from './components/pages/showdealer/showdealer.component';
import { CarlistComponent } from './components/carlist/carlist.component';
import { ShowcarComponent } from './components/pages/showcar/showcar.component';
import { AddcarComponent } from './components/pages/addcar/addcar.component';
import { EditcarComponent } from './components/pages/editcar/editcar.component';
import { ListfeedbackComponent } from './components/pages/listfeedback/listfeedback.component';
import { AddfeedbackComponent } from './components/pages/addfeedback/addfeedback.component';
import { MigratecarComponent } from './components/pages/migratecar/migratecar.component';


const routes: Routes = [
  {path:'' , component: DealerlistComponent},
  {path:'addcompany' , component: AddcompanyComponent},
  {path:'dealers/:dealerId/editdealer' , component: EditdealerComponent},
  { path: 'dealers/:dealerId', component: ShowdealerComponent },
  {path:'dealers/:dealerId/cars' , component: CarlistComponent},
  { path: 'dealers/:dealerId/cars/:carId', component: ShowcarComponent },
  {path:'addcar' , component: AddcarComponent},
  {path:'dealers/:dealerId/cars/:carId/editcar' , component: EditcarComponent},
  {path:'listfeedback' , component: ListfeedbackComponent},
  {path:'addfeedback' , component: AddfeedbackComponent},
  {path:'dealers/:dealerId/cars/:carId/migratecar' , component: MigratecarComponent},
  

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
