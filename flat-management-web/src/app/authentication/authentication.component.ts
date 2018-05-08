import { Component, OnInit } from '@angular/core';
import { FormGroup, AbstractControl, FormsModule, FormBuilder, Validators, ValidatorFn } from '@angular/forms';

@Component({
  templateUrl: './authentication.component.html',
  styleUrls: ['./authentication.component.css']
})

export class AuthenticationComponent implements OnInit {
  loginForm: FormGroup;

  name: AbstractControl;
  flatName: AbstractControl;

  busy: boolean;

  //#region init methods
  constructor(private formBuilder: FormBuilder) {
    this.busy = false;
  }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      name: ['', Validators.required],
      flatName: ['', Validators.required]
    });

    this.name = this.loginForm.get('name');
    this.flatName = this.loginForm.get('flatName');
  }
  //#endregion

  login(): void {
    try {
      this.busy = true;
    } finally {
      this.busy = false;
    }
  }

  clear(): void {
    this.loginForm.setValue({
      name: '',
      flatName: ''
    });
  }
}
