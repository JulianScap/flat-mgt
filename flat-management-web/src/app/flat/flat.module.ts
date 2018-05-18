import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FlatPickerComponent } from './flat-picker.component';
import { FlatRoutingModule } from './flat-routing.module';

@NgModule({
  imports: [
    CommonModule,
    FlatRoutingModule
  ],
  declarations: [
    FlatPickerComponent
  ]
})
export class FlatModule { }
