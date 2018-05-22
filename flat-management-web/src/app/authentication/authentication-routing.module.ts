import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { AuthenticationComponent } from "./authentication.component";
import { AuthenticationNewComponent } from "./authentication-new.component";

@NgModule({
  imports: [RouterModule.forChild([
    {
      path: 'authentication',
      component: AuthenticationComponent
    },
    {
      path: 'authentication/new',
      component: AuthenticationNewComponent
    }
  ])],
  exports: [RouterModule]
})
export class AuthenticationRoutingModule { }
