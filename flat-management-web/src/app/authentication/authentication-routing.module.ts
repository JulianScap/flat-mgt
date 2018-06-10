import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { AuthenticationNewComponent } from "./authentication-new.component";
import { AuthenticationComponent } from "./authentication.component";

@NgModule({
  imports: [RouterModule.forChild([
    {
      path: 'authentication/new',
      component: AuthenticationNewComponent
    },
    {
      path: 'authentication/:success',
      component: AuthenticationComponent
    },
    {
      path: 'authentication',
      component: AuthenticationComponent
    }
  ])],
  exports: [RouterModule]
})
export class AuthenticationRoutingModule { }
