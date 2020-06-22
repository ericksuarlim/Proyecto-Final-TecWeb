import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DealerlistComponent } from './components/dealerlist/dealerlist.component';
import { AddcompanyComponent } from './components/pages/addcompany/addcompany.component';
import { EditdealerComponent } from './components/pages/editdealer/editdealer.component';
import { ShowdealerComponent } from './components/pages/showdealer/showdealer.component';


const routes: Routes = [
  {path:'' , component: DealerlistComponent},
  {path:'addcompany' , component: AddcompanyComponent},
  {path:'editdealer' , component: EditdealerComponent},
  { path: 'dealers/:dealerId', component: ShowdealerComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
