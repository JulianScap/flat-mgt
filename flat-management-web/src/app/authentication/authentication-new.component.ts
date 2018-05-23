import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService } from './authentication.service';

@Component({
  templateUrl: './authentication-new.component.html'
})
export class AuthenticationNewComponent implements OnInit {
  errorMessages: string[];

  authForm: FormGroup;
  flatmateForm: FormGroup;
  flatForm: FormGroup;

  login: AbstractControl;
  password: AbstractControl;
  confirmPassword: AbstractControl;
  fullName: AbstractControl;
  nickName: AbstractControl;
  birthDate: AbstractControl;
  flatTenant: AbstractControl;

  name: AbstractControl;
  address: AbstractControl;

  constructor(private fb: FormBuilder, private authService: AuthenticationService) { }

  ngOnInit(): void {
    this.flatmateForm = this.fb.group({
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

    this.flatForm = this.fb.group({
      name: ['', [Validators.required, Validators.maxLength(200)]],
      address: ['', [Validators.required, Validators.maxLength(1000)]]
    });

    this.name = this.flatForm.get('name');
    this.address = this.flatForm.get('address');

    this.authForm = this.fb.group({
      flatmateForm: this.flatmateForm,
      flatForm: this.flatForm
    });
  }

  save(): void {
    this.flatForm.updateValueAndValidity();
    this.flatmateForm.updateValueAndValidity();
    this.authForm.updateValueAndValidity();

    if (this.authForm.valid) {
      this.authService.createNewUserAndFlat(this.flatForm.value, this.flatmateForm.value)
        .subscribe(data => this.errorMessages = [JSON.stringify(data)]);
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
