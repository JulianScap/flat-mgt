import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { IMessage } from '../shared/entities/message';
import { IValidationResult } from '../shared/entities/validation-result';
import { AuthenticationService } from './authentication.service';

@Component({
  templateUrl: './authentication-new.component.html'
})
export class AuthenticationNewComponent implements OnInit {

  messages: IMessage[];

  flatForm: FormGroup;
  authForm: FormGroup;
  flatmateForm: FormGroup;

  login: AbstractControl;
  password: AbstractControl;
  confirmPassword: AbstractControl;
  fullName: AbstractControl;
  nickName: AbstractControl;
  birthDate: AbstractControl;
  flatTenant: AbstractControl;

  constructor(private formBuilder: FormBuilder, private authService: AuthenticationService, private router: Router) {
  }

  ngOnInit(): void {
    this.flatmateForm = this.formBuilder.group({
      login: ['', [Validators.required, Validators.maxLength(100)]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', Validators.required],
      fullName: ['', [Validators.required, Validators.maxLength(500)]],
      nickName: ['', Validators.maxLength(100)],
      birthDate: '',
      flatTenant: true
    }, { validator: passwordMatcher });

    this.login = this.flatmateForm.get('login');
    this.password = this.flatmateForm.get('password');
    this.confirmPassword = this.flatmateForm.get('confirmPassword');
    this.fullName = this.flatmateForm.get('fullName');
    this.nickName = this.flatmateForm.get('nickName');
    this.birthDate = this.flatmateForm.get('birthDate');
    this.flatTenant = this.flatmateForm.get('flatTenant');

    this.flatForm = this.formBuilder.group({
      name: ['', [Validators.required, Validators.maxLength(200)]],
      address: ['', [Validators.maxLength(1000)]]
    });

    this.authForm = this.formBuilder.group({
      flatmateForm: this.flatmateForm,
      flatForm: this.flatForm
    });
  }

  save(): void {
    if (this.authForm.valid) {
      this.authService.createNewUserAndFlat(this.flatForm.value, this.flatmateForm.value)
        .subscribe(data => this.handleSaveResult(data));
    }
  }

  handleSaveResult(validationResult: IValidationResult): any {
    if (validationResult.isValid) {
      this.router.navigate(['/authentication', 'success']);
    } else {
      this.messages = validationResult.messages;
    }
  }

  setDevValues_click(): void {
    this.authForm.setValue({
      flatmateForm: {
        login: 'bob',
        password: 'password123',
        confirmPassword: 'password123',
        fullName: 'Bob le bricoleur',
        nickName: '',
        birthDate: '',
        flatTenant: true
      },
      flatForm: {
        name: '4E',
        address: '4E MacAulay street'
      }
    });
  }
}

function passwordMatcher(c: AbstractControl): { [key: string]: boolean } | null {
  const password = c.get('password');
  const confirmPassword = c.get('confirmPassword');

  if (password.pristine || confirmPassword.pristine) {
    return null;
  }

  if (password.value !== confirmPassword.value) {
    return { 'match': true };
  }

  return null;
}
