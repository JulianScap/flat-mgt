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
    //this.flatService.getFlatsForAccount().subscribe(result => this.flats = result);
  }
}
