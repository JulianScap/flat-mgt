import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs/Observable';
import { IFlat } from '../shared/entities/flat';
import { IFlatmate } from '../shared/entities/flatmate';
import { IMessage } from '../shared/entities/message';
import { FlatService } from '../shared/services/flat.service';
import { FlatmateService } from '../shared/services/flatmate.service';

@Component({
  templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {
  messages: IMessage[];

  homeForm: FormGroup;
  flatForm: FormGroup;
  flatmateForm: FormArray;

  editFlat: boolean;
  editFlatmates: boolean;

  constructor(private formBuilder: FormBuilder,
    private flatService: FlatService,
    private flatmateService: FlatmateService
  ) {
    this.editFlat = false;
    this.editFlatmates = false;
  }

  ngOnInit() {
    this.flatForm = this.formBuilder.group({
      name: ['', [Validators.required, Validators.maxLength(200)]],
      address: ['', [Validators.maxLength(1000)]],
      flatId: 0
    });

    this.flatmateForm = this.formBuilder.array([]);

    this.homeForm = this.formBuilder.group(
      {
        flatForm: this.flatForm,
        flatmateForm: this.flatmateForm
      });

    this.loadFlat();
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
      fullName: [flatmate ? flatmate.fullName : '', Validators.required],
      nickName: [flatmate ? flatmate.nickName : '', Validators.required],
      birthDate: [flatmate ? dp.transform(flatmate.birthDate, 'y-MM-dd') : '', Validators.required],
      flatTenant: flatmate ? flatmate.flatTenant : '',
      login: [flatmate ? flatmate.login : '', Validators.required],
      flatId: flatmate ? flatmate.flatId : 0,
      flatmateId: flatmate ? flatmate.flatmateId : 0
    });
  }
  //#endregion

  //#region Flat
  loadFlat(): Observable<IFlat[]> {
    let result: Observable<IFlat[]> = this.flatService.getAll();
    result.subscribe(flats => this.initFlatForm(flats[0]));
    return result;
  }

  initFlatForm(flat: IFlat): void {
    this.flatForm.setValue({
      name: flat.name,
      address: flat.address,
      flatId: flat.flatId
    });
  }

  saveFlatEdit(): void {
    this.flatService.save([this.flatForm.value])
      .subscribe(
        data => {
          if (data[0].validationResult.isValid) {
            this.messages = [{ isError: false, text: "Flat successfully updated" }];
          } else {
            this.messages = data[0].validationResult.messages;
          }
        },
        () => this.messages = [{ isError: true, text: "A server error occured" }],
        () => this.editFlat = false)
  }

  undoFlatEdit(): void {
    this.editFlat = false;
    this.loadFlat();
  }
  //#endregion
}
