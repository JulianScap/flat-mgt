import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {
  errorMessages: string[];
  flatForm: FormGroup;
  editFlat: boolean;

  constructor(private formBuilder: FormBuilder) {
    this.editFlat = false;
  }

  ngOnInit() {
    this.flatForm = this.formBuilder.group({
      name: ['', [Validators.required, Validators.maxLength(200)]],
      address: ['', [Validators.maxLength(1000)]]
    });
  }

  saveFlatEdit(): void {

  }

  undoFlatEdit(): void {

  }
}
