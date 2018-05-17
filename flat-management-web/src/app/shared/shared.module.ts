import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { ErrorComponent } from './error/error.component';

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
  ]
})
export class SharedModule { }
