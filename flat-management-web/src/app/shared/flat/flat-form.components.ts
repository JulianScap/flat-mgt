import { Component, EventEmitter, Input, OnInit, Output } from "@angular/core";
import { AbstractControl, FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Observable } from "rxjs/Observable";
import { IFlat } from "../entities/flat";
import { IMessage } from "../entities/message";
import { FlatService } from "../services/flat.service";
import { FlatComponentMode } from "./flatComponentMode.enum";

@Component({
  selector: 'fm-flat-form',
  templateUrl: './flat-form.component.html'
})
export class FlatFormComponent implements OnInit {
  @Output() messageOut: EventEmitter<IMessage[]>;
  @Output() flatFormReadyOut: EventEmitter<FormGroup>;
  @Input() mode: FlatComponentMode;

  get showControls(): boolean {
    return this.mode == FlatComponentMode.Edit;
  }

  flatForm: FormGroup;
  editMode: boolean;
  address: AbstractControl;
  name: AbstractControl;

  constructor(private flatService: FlatService, private formBuilder: FormBuilder) {
    this.messageOut = new EventEmitter<IMessage[]>();
    this.flatFormReadyOut = new EventEmitter<FormGroup>();
  }

  ngOnInit(): void {
    if (this.mode == FlatComponentMode.Create) {
      this.editMode = true;
    }

    this.flatForm = this.formBuilder.group({
      name: ['', [Validators.required, Validators.maxLength(200)]],
      address: ['', [Validators.maxLength(1000)]],
      flatId: 0
    });

    this.name = this.flatForm.get('name');
    this.address = this.flatForm.get('address');

    this.flatFormReadyOut.emit(this.flatForm);

    if (this.mode == FlatComponentMode.Edit) {
      this.loadFlat();
    }
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
        data => {
          if (data[0].validationResult.isValid) {
            this.messageOut.emit([{ isError: false, text: "Flat successfully updated" }]);
          } else {
            this.messageOut.emit(data[0].validationResult.messages);
          }
        },
        () => this.messageOut.emit([{ isError: true, text: "A server error occured" }]),
        () => this.editMode = false)
  }

  undoFlatEdit(): void {
    this.editMode = false;
    if (this.mode == FlatComponentMode.Edit) {
      this.loadFlat();
    }
  }
}
