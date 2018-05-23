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
    this.flatService.get().subscribe(result => this.flats = result);
  }

  delete(flat: IFlat): void {
    let index: number = this.flats.findIndex(f => f.flatId === flat.flatId);

    if (confirm(`Are you sure you want to delete the flat ${flat.name} (${flat.address}) and all the flatmates information? (this cannot be undone)`)) {
      this.flatService.delete([flat])
        .subscribe(() => {
          this.flats.splice(index, 1);
        });
    }
  }
}
