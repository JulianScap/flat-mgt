import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { SessionManager } from '../shared/services/session-manager.service';
import { IAuthenticationResult } from './authentication-result';
import { AuthenticationService } from './authentication.service';

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
              private authenticationService: AuthenticationService,
              private sessionManager: SessionManager,
              private _router: Router) { }

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

  handleLogin(result: IAuthenticationResult): void {
    if (result.validationResult.isValid) {
      // redirection vers la page de selection d'appart qui n'existe pas encore
      this.sessionManager.setUser(result.token, result.userInfo);
      this._router.navigate(['/flat/list']);
    } else {
      this.errorMessages = result.validationResult.messages;
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
