import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {
  errorMessages: string[];
  flatForm: FormGroup;

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.flatForm = this.formBuilder.group({
      name: ['', [Validators.required, Validators.maxLength(200)]],
      address: ['', [Validators.required, Validators.maxLength(1000)]]
    });
  }
}
