import { Component, OnInit } from '@angular/core';
import { IFlat } from '../shared/entities/flat';
import { FlatService } from '../shared/services/flat.service';

@Component({
  templateUrl: './flat-list.component.html'
})
export class FlatListComponent implements OnInit {
  flats: IFlat[];


  constructor(private flatService: FlatService) { }

  ngOnInit() {
    this.flatService.getFlats().subscribe(result => this.flats = result);
  }

  delete(flat: IFlat): void {
    if (confirm('Are you sure you want to delete this?')) {

    }
  }
}
