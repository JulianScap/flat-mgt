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

  buildFlatmate(flatTenant: boolean): FormGroup {
    return this.formBuilder.group({
      flatmateId: 0,
      fullName: ['', Validators.required],
      nickName: ['', Validators.required],
      birthDate: ['', Validators.required],
      flatTenant: flatTenant
    });
  }

  addFlatmate(): void {
    this.flatmateForm.push(this.buildFlatmate(false));
  }

  removeFlatmate(index: number): void {
    this.flatmateForm.removeAt(index);
  }
}
