import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IFlat } from '../shared/entities/flat';
import { IFlatmate } from '../shared/entities/flatmate';
import { FlatService } from '../shared/services/flat.service';
import { FlatmateService } from '../shared/services/flatmate.service';

@Component({
  templateUrl: './flat-detail.component.html'
})
export class FlatDetailComponent implements OnInit {
  errorMessages: string[];

  flatmates: FormArray;
  flatForm: FormGroup;
  name: AbstractControl;
  address: AbstractControl;

  constructor(private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder,
    private flatService: FlatService,
    private flatmateService: FlatmateService) { }

  ngOnInit() {
    this.flatmates = this.formBuilder.array([this.buildFlatmate(true)]);

    this.flatForm = this.formBuilder.group({
      flatId: 0,
      name: ['', Validators.required],
      address: ['', Validators.required],
      flatmates: this.flatmates
    });

    this.name = this.flatForm.get('name');
    this.address = this.flatForm.get('address');

    if (this.route.snapshot.paramMap.has('id')) {
      let id: number = +this.route.snapshot.paramMap.get('id');
      this.flatService.get(id).subscribe(flat => this.initFlatForm(flat));
      this.flatmateService.getByFlatId(id).subscribe(flatmates => this.initFlatmateForm(flatmates));
    }
  }

  initFlatForm(flats: IFlat[]): void {
    if (!flats || flats.length != 1) {
      this.errorMessages = ["Couldn't load the flat"];
    } else {
      let flat: IFlat = flats[0];

      this.flatForm.patchValue({
        flatId: flat.flatId,
        name: flat.name,
        address: flat.address
      });
    }
  }

  initFlatmateForm(flatmates: IFlatmate[]): void {
    if (!flatmates || flatmates.length != 1) {
      this.errorMessages = ["Couldn't load the flatmate list"];
    } else {
      let flatmate: IFlatmate = flatmates[0];
      let dp = new DatePipe(navigator.language);

      this.flatForm.patchValue({
        flatmates: [{
          flatmateId: flatmate.flatmateId,
          fullName: flatmate.fullName,
          nickname: flatmate.nickname,
          birthDate: dp.transform(flatmate.birthDate, 'y-MM-dd'),
          flatTenant: flatmate.flatTenant
        }]
      });
    }
  }

  buildFlatmate(flatTenant: boolean): FormGroup {
    return this.formBuilder.group({
      flatmateId: 0,
      fullName: ['', Validators.required],
      nickname: ['', Validators.required],
      birthDate: ['', Validators.required],
      flatTenant: flatTenant
    });
  }

  addFlatmate(): void {
    this.flatmates.push(this.buildFlatmate(false));
  }

  removeFlatmate(index: number): void {
    this.flatmates.removeAt(index);
  }

  onBack(): void {
    this.router.navigate(['/flat/list']);
  }

  save(): void {
    let newFlat: IFlat;

    newFlat = this.flatForm.value;

    this.flatService.save([newFlat], this.flatmates.value)
      .subscribe(() => this.router.navigate(['/flat/list']),
        error => this.errorMessages = [error]);
  }
}
