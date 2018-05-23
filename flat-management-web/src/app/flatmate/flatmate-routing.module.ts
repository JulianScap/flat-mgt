import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { AuthenticatedGuard } from "../shared/guards/authenticated.guard";
import { FlatmateDetailComponent } from "./flatmate-detail.component";

@NgModule({
  imports: [RouterModule.forChild([
    {
      path: 'flatmate/details/:id',
      canActivate: [AuthenticatedGuard],
      component: FlatmateDetailComponent
    },
    {
      path: 'flatmate/new',
      canActivate: [AuthenticatedGuard],
      component: FlatmateDetailComponent
    }
  ])],
  exports: [RouterModule]
})
export class FlatmateRoutingModule { }
