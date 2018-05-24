import { Component, Input, OnInit } from "@angular/core";
import { AbstractControl, FormGroup } from "@angular/forms";

@Component({
  selector: 'fm-flat-form',
  templateUrl: './flat-form.component.html',
  styleUrls: ['./flat-form.component.css']
})
export class FlatFormComponent implements OnInit {
  @Input() flatForm: FormGroup;
  @Input() editMode: boolean;

  address: AbstractControl;
  name: AbstractControl;

  constructor() { }

  ngOnInit(): void {
    this.name = this.flatForm.get('name');
    this.address = this.flatForm.get('address');
  }
}
