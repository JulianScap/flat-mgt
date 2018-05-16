import { Component, OnInit } from '@angular/core';
import { FormGroup, AbstractControl, FormsModule, FormBuilder, Validators, ValidatorFn } from '@angular/forms';

import { AuthenticationService } from './authentication.service';


@Component({
  templateUrl: './authentication.component.html'
})
export class AuthenticationComponent implements OnInit {
  loginForm: FormGroup;

  login: AbstractControl;
  password: AbstractControl;

  busy: boolean;

  //#region init methods
  constructor(private formBuilder: FormBuilder,
              private authenticationService: AuthenticationService
  ) {
    this.busy = false;
  }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      login: ['', Validators.required],
      password: ['', Validators.required]
    });

    this.login = this.loginForm.get('login');
    this.password = this.loginForm.get('password');
  }
  //#endregion

  login_click(): void {
    try {
      this.busy = true;
      let now: Date = new Date();
      let passwordHash: string;

      this.authenticationService.Authenticate(this.login.value, this.password.value);
    } finally {
      this.busy = false;
    }
  }

  clear_click(): void {
    this.loginForm.setValue({
      login: '',
      password: ''
    });
  }
}
