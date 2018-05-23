import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { FlatmateRoutingModule } from './flatmate-routing.module';
import { FlatmateDetailComponent } from './flatmate-detail.component';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    FlatmateRoutingModule
  ],
  declarations: [
    FlatmateDetailComponent
  ]
})
export class FlatmateModule { }
