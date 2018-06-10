import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { FlatFormComponent } from './flat/flat-form.components';
import { FlatmateFormComponent } from './flatmate/flatmate-form.components';
import { AuthenticatedGuard } from './guards/authenticated.guard';
import { MessageComponent } from './message/message.component';
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
    FlatFormComponent,
    FlatmateFormComponent
  ],
  exports: [
    CommonModule,
    ReactiveFormsModule,
    MessageComponent,
    FlatFormComponent,
    FlatmateFormComponent
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
