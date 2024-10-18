import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModule, NgbPaginationModule } from '@ng-bootstrap/ng-bootstrap';


import { AppComponent } from './app.component';
import { TicketFormComponent } from './ticket-form/ticket-form.component';
import { RouterOutlet } from '@angular/router';
import { TicketListComponent } from './ticket-list/ticket-list.component';
import { provideHttpClient } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';

@NgModule({
  declarations: [
    AppComponent,
    TicketListComponent,
    TicketFormComponent
  ],
  imports: [
    BrowserModule,
    NgbPaginationModule ,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule, 
    NgbModule,
 
  ],
  providers: [provideHttpClient()],
  bootstrap: [AppComponent],
})
export class AppModule { }