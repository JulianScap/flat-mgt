import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthenticationModule } from './authentication/authentication.module';
import { FlatModule } from './flat/flat.module';
import { FlatmateModule } from './flatmate/flatmate.module';
import { SharedModule } from './shared/shared.module';


@NgModule({
  declarations: [
    AppComponent
  ],

  imports: [
    BrowserModule,
    SharedModule,
    HttpClientModule,
    AuthenticationModule,
    FlatModule,
    FlatmateModule,
    AppRoutingModule
  ],

  bootstrap: [AppComponent]
})
export class AppModule { }
