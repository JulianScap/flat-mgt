import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  templateUrl: './authentication-new.component.html'
})
export class AuthenticationNewComponent implements OnInit {
  errorMessages: string[];

  authForm: FormGroup;
  userForm: FormGroup;
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

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.userForm = this.fb.group({
      login: ['', [Validators.required, Validators.maxLength(100)]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', Validators.required],
      fullName: ['', [Validators.required, Validators.maxLength(500)]],
      nickName: ['', Validators.maxLength(100)],
      birthDate: '',
      flatTenant: true
    }, { validator: passwordMatcher });

    this.login = this.userForm.get('login');
    this.password = this.userForm.get('password');
    this.confirmPassword = this.userForm.get('confirmPassword');
    this.fullName = this.userForm.get('fullName');
    this.nickName = this.userForm.get('nickName');
    this.birthDate = this.userForm.get('birthDate');
    this.flatTenant = this.userForm.get('flatTenant');

    this.flatForm = this.fb.group({
      name: ['', [Validators.required, Validators.maxLength(200)]],
      address: ['', [Validators.required, Validators.maxLength(1000)]],
    });

    this.name = this.flatForm.get('name');
    this.address = this.flatForm.get('address');

    this.authForm = this.fb.group({
      userForm: this.userForm,
      flatForm: this.flatForm
    });
  }

  save(): void {

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
