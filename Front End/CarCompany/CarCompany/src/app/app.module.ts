import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule} from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DealerlistComponent } from './components/dealerlist/dealerlist.component';
import { DealerComponent } from './components/dealer/dealer.component';
import { HeaderComponent } from './components/header/header.component';
import { AddcompanyComponent } from './components/pages/addcompany/addcompany.component';
import { EditdealerComponent } from './components/pages/editdealer/editdealer.component';
import { ShowdealerComponent } from './components/pages/showdealer/showdealer.component';

@NgModule({
  declarations: [
    AppComponent,
    DealerlistComponent,
    DealerComponent,
    HeaderComponent,
    AddcompanyComponent,
    EditdealerComponent,
    ShowdealerComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
