import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FlatService } from '../shared/services/flat.service';
import { FlatmateService } from '../shared/services/flatmate.service';
import { IFlat } from '../shared/entities/flat';
import { Observable } from 'rxjs/Observable';

@Component({
  templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {

  errorMessages: string[];
  flatForm: FormGroup;
  editFlat: boolean;

  constructor(private formBuilder: FormBuilder,
    private flatService: FlatService,
    private flatmateService: FlatmateService
  ) {
    this.editFlat = false;
  }

  ngOnInit() {
    this.flatForm = this.formBuilder.group({
      name: ['', [Validators.required, Validators.maxLength(200)]],
      address: ['', [Validators.maxLength(1000)]],
      flatId: 0
    });

    this.loadFlat();
  }

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
        null,
        null,
        () => this.editFlat = false)
  }

  undoFlatEdit(): void {
    this.editFlat = false;
    this.loadFlat();
  }
}
