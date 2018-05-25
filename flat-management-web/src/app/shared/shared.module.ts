import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { MessageComponent } from './message/message.component';
import { FlatFormComponent } from './flat/flat-form.components';
import { AuthenticatedGuard } from './guards/authenticated.guard';
import { AuthenticatedCorsHttpClient } from './services/authenticated-cors-http-client.service';
import { CorsHttpClient } from './services/cors-http-client.service';
import { FlatService } from './services/flat.service';
import { FlatmateService } from './services/flatmate.service';
import { SessionManager } from './services/session-manager.service';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  declarations: [
    MessageComponent,
    FlatFormComponent
  ],
  exports: [
    CommonModule,
    ReactiveFormsModule,
    MessageComponent,
    FlatFormComponent
  ],
  providers:[
    CorsHttpClient,
    AuthenticatedCorsHttpClient,
    FlatService,
    FlatmateService,
    SessionManager,
    AuthenticatedGuard
  ]
})
export class SharedModule { }
