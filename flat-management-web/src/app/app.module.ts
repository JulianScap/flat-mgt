import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router'

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { AuthenticationComponent } from './authentication/authentication.component';
import { SharedModule } from './shared/shared.module';

@NgModule({
  declarations: [
    AppComponent,
    AuthenticationComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    SharedModule,
    AppRoutingModule
  ],

  bootstrap: [ AppComponent ]
})
export class AppModule { }
