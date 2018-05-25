import { Component, Input, OnInit } from "@angular/core";
import { FormArray, FormBuilder, FormGroup, Validators } from "@angular/forms";

@Component({
  selector: 'fm-flatmate-form',
  templateUrl: './flatmate-form.component.html'
})
export class FlatmateFormComponent implements OnInit {
  @Input() flatmateForm: FormArray;
  @Input() parentForm: FormGroup;
  @Input() editMode: boolean;

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void {
  }

  buildFlatmate(): FormGroup {
    return this.formBuilder.group({
      fullName: ['', [Validators.required, Validators.maxLength(500)]],
      nickName: ['', Validators.maxLength(100)],
      birthDate: '',
      flatTenant:  '',
      login: ['', [Validators.required, Validators.maxLength(100)]],
      flatId: 0,
      flatmateId: 0
    });
  }

  addFlatmate(): void {
    this.flatmateForm.push(this.buildFlatmate());
  }

  removeFlatmate(index: number): void {
    this.flatmateForm.removeAt(index);
  }
}
