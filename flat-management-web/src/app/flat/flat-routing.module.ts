import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";

import { FlatPickerComponent } from "./flat-picker.component";
import { AuthenticatedGuard } from "../shared/guards/authenticated.guard";

@NgModule({
    imports:[RouterModule.forChild([
        {
          path: 'flat/picker',
          canActivate: [ AuthenticatedGuard ],
          component: FlatPickerComponent
        }
      ])],
    exports:[RouterModule]
})
export class FlatRoutingModule { }
