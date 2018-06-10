import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { AuthenticatedGuard } from "../shared/guards/authenticated.guard";
import { HomeComponent } from "./home.component";

@NgModule({
  imports: [RouterModule.forChild([
    {
      path: 'home',
      canActivate: [AuthenticatedGuard],
      component: HomeComponent
    },
  ])],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
