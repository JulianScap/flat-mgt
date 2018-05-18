import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { ErrorComponent } from './error/error.component';
import { SessionManager } from './services/session-manager.service';
import { CorsHttpClient } from './services/corshttpclient.service';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  declarations: [
    ErrorComponent
  ],
  exports: [
    CommonModule,
    ReactiveFormsModule,
    ErrorComponent
  ],
  providers:[
    CorsHttpClient,
    SessionManager
  ]
})
export class SharedModule { }
