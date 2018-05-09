import { Component, OnInit } from '@angular/core';
import { FormGroup, AbstractControl, FormsModule, FormBuilder, Validators, ValidatorFn } from '@angular/forms';

@Component({
  templateUrl: './authentication.component.html'
})
export class AuthenticationComponent implements OnInit {
  loginForm: FormGroup;

  login: AbstractControl;
  password: AbstractControl;

  busy: boolean;

  //#region init methods
  constructor(private formBuilder: FormBuilder) {
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

      console.log(JSON.stringify(this.loginForm.value));
      
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
