import { Component, OnInit } from '@angular/core';
import { FormGroup, AbstractControl, FormBuilder, Validators } from '@angular/forms';

import { AuthenticationService } from './authentication.service';
import { IResult } from '../shared/result';


@Component({
  templateUrl: './authentication.component.html'
})
export class AuthenticationComponent implements OnInit {
  loginForm: FormGroup;

  login: AbstractControl;
  password: AbstractControl;

  errorMessages: string[];

  //#region init methods
  constructor(private formBuilder: FormBuilder,
    private authenticationService: AuthenticationService
  ) {
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
    let now: Date = new Date();
    let passwordHash: string;

    this.errorMessages = null;

    this.authenticationService
      .authenticate(this.login.value, this.password.value)
      .subscribe(result => this.handleLogin(result));
  }

  handleLogin(result: IResult): void {
    if (result.success) {
      // redirection vers la page de selection d'appart qui n'existe pas encore
    } else {
      this.errorMessages = result.messages;
    }
  }

  setDevValues_click(): void {
    this.loginForm.setValue({
      login: 'Julian',
      password: 'Julian'
    });
  }

  clear_click(): void {
    this.loginForm.setValue({
      login: '',
      password: ''
    });
  }
}
