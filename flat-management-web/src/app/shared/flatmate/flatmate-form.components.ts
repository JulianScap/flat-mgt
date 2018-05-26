import { DatePipe } from "@angular/common";
import { Component, EventEmitter, OnInit, Output } from "@angular/core";
import { FormArray, FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Observable } from "rxjs/Observable";
import { IFlatmate } from "../entities/flatmate";
import { IMessage } from "../entities/message";
import { FlatmateService } from "../services/flatmate.service";

@Component({
  selector: 'fm-flatmate-form',
  templateUrl: './flatmate-form.component.html'
})
export class FlatmateFormComponent implements OnInit {
  @Output() messageOut: EventEmitter<IMessage[]>;

  flatmateFormGroup: FormGroup;
  flatmateFormArray: FormArray;
  editMode: boolean;

  constructor(private formBuilder: FormBuilder, private flatmateService: FlatmateService) {
    this.messageOut = new EventEmitter<IMessage[]>();
  }

  ngOnInit(): void {
    this.flatmateFormArray = this.formBuilder.array([]);

    this.flatmateFormGroup = this.formBuilder.group({
      flatmateFormArray: this.flatmateFormArray
    });

    this.loadFlatmate();
  }


  addFlatmate(): void {
    this.flatmateFormArray.push(this.buildFlatmate());
  }

  removeFlatmate(index: number): void {
    this.flatmateFormArray.removeAt(index);
  }

  loadFlatmate(): Observable<IFlatmate[]> {
    let result: Observable<IFlatmate[]> = this.flatmateService.getAll();
    result.subscribe(flatmates => this.initFlatmateForm(flatmates));
    return result;
  }

  initFlatmateForm(flatmates: IFlatmate[]): void {
    while (this.flatmateFormArray.length != 0) {
      this.flatmateFormArray.removeAt(0);
    }

    for (let i = 0; i < flatmates.length; i++) {
      let flatmate: IFlatmate = flatmates[i];
      this.flatmateFormArray.push(this.buildFlatmate(flatmate));
    }
  }

  buildFlatmate(flatmate?: IFlatmate): FormGroup {
    let dp = new DatePipe(navigator.language);

    return this.formBuilder.group({
      fullName: [flatmate ? flatmate.fullName : '', [Validators.required, Validators.maxLength(500)]],
      nickName: [flatmate ? flatmate.nickName : '', Validators.maxLength(100)],
      birthDate: flatmate ? dp.transform(flatmate.birthDate, 'y-MM-dd') : '',
      flatTenant: flatmate ? flatmate.flatTenant : '',
      login: [flatmate ? flatmate.login : '', [Validators.required, Validators.maxLength(100)]],
      flatId: flatmate ? flatmate.flatId : 0,
      flatmateId: flatmate ? flatmate.flatmateId : 0
    });
  }

  saveFlatmatesEdit(): void {

  }

  undoFlatmatesEdit(): void {
    this.editMode = false;
    this.loadFlatmate();
  }
}
