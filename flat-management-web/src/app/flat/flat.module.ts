import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { FlatDetailComponent } from './flat-detail.component';
import { FlatListComponent } from './flat-list.component';
import { FlatRoutingModule } from './flat-routing.module';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    FlatRoutingModule
  ],
  declarations: [
    FlatListComponent,
    FlatDetailComponent
  ]
})
export class FlatModule { }
