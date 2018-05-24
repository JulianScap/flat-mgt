import { Component, Input, OnInit } from "@angular/core";
import { AbstractControl, FormBuilder, Validators, FormGroup } from "@angular/forms";
import { IFlat } from "../entities/flat";

@Component({
  selector: 'fm-flat-form',
  templateUrl: './flat-form.component.html'
})
export class FlatFormComponent implements OnInit {
  @Input() flatForm: FormGroup;
  @Input() editMode: boolean;

  address: AbstractControl;
  name: AbstractControl;

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.name = this.flatForm.get('name');
    this.address = this.flatForm.get('address');
  }
}
