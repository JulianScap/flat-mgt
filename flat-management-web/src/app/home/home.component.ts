import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs/Observable';
import { IFlatmate } from '../shared/entities/flatmate';
import { IMessage } from '../shared/entities/message';
import { FlatmateService } from '../shared/services/flatmate.service';

@Component({
  templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {
  homeForm: FormGroup;
  flatForm: FormGroup;
  flatmateForm: FormArray;

  editFlatmates: boolean;
  messages: IMessage[];

  constructor(private formBuilder: FormBuilder,
    private flatmateService: FlatmateService
  ) {
    this.editFlatmates = false;

  }

  onMessage(messages: IMessage[]) {
    this.messages = messages;
  }

  ngOnInit() {
    this.flatmateForm = this.formBuilder.array([]);

    this.homeForm = this.formBuilder.group(
      {
        flatForm: this.flatForm,
        flatmateForm: this.flatmateForm
      });

    this.loadFlatmate();
  }

  //#region Flatmate
  loadFlatmate(): Observable<IFlatmate[]> {
    let result: Observable<IFlatmate[]> = this.flatmateService.getAll();
    result.subscribe(flatmates => this.initFlatmateForm(flatmates));
    return result;
  }

  initFlatmateForm(flatmates: IFlatmate[]): void {
    while (this.flatmateForm.length != 0) {
      this.flatmateForm.removeAt(0);
    }

    for (let i = 0; i < flatmates.length; i++) {
      let flatmate: IFlatmate = flatmates[i];
      this.flatmateForm.push(this.buildFlatmate(flatmate));
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
    this.editFlatmates = false;
    this.loadFlatmate();
  }
  //#endregion

}
