import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  templateUrl: './flat-detail.component.html'
})
export class FlatDetailComponent implements OnInit {
  errorMessages: string[];

  flatForm: FormGroup;
  name: AbstractControl;
  address: AbstractControl;

  constructor(private _route: ActivatedRoute, private _router: Router, private formBuilder: FormBuilder) { }

  ngOnInit() {
    // let id = +this._route.snapshot.paramMap.get('id');

    this.flatForm = this.formBuilder.group({
      name: ['', Validators.required],
      address: ['', Validators.required]
    });

    this.name = this.flatForm.get('name');
    this.address = this.flatForm.get('address');
  }

  onBack(): void {
    this._router.navigate(['/flat/list']);
  }

  save(): void {
    console.log("saved");
  }
}
