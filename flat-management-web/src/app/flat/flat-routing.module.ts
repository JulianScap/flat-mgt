import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { AuthenticatedGuard } from "../shared/guards/authenticated.guard";
import { FlatDetailComponent } from "./flat-detail.component";
import { FlatListComponent } from "./flat-list.component";

@NgModule({
  imports: [RouterModule.forChild([
    {
      path: 'flat/list',
      canActivate: [AuthenticatedGuard],
      component: FlatListComponent
    },
    {
      path: 'flat/detail',
      canActivate: [AuthenticatedGuard],
      component: FlatDetailComponent
    }
  ])],
  exports: [RouterModule]
})
export class FlatRoutingModule { }
