import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { SessionManager } from '../shared/services/session-manager.service';
import { IAuthenticationResult } from './authentication-result';
import { AuthenticationService } from './authentication.service';
import { IMessage } from '../shared/entities/message';

@Component({
  templateUrl: './authentication.component.html'
})
export class AuthenticationComponent implements OnInit {
  loginForm: FormGroup;

  login: AbstractControl;
  password: AbstractControl;

  message: IMessage[];

  //#region init methods
  constructor(private formBuilder: FormBuilder,
    private authenticationService: AuthenticationService,
    private sessionManager: SessionManager,
    private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    if (this.route.snapshot.paramMap.has('success')) {
      this.message = [{ text: 'New flat and tenant successfully created', isError: false }];
    }

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

    this.message = null;

    this.authenticationService
      .authenticate(this.login.value, this.password.value)
      .subscribe(result => this.handleLogin(result));
  }

  handleLogin(result: IAuthenticationResult): void {
    if (result.validationResult.isValid) {
      this.sessionManager.setUser(result.token, this.login.value, result.userInfo);
      this.router.navigate(['/home']);
    } else {
      this.sessionManager.clearSession();
      this.message = result.validationResult.messages;
    }
  }

  setDevValues_click(): void {
    this.loginForm.setValue({
      login: 'Julian',
      password: 'Julian'
    });
  }
}
