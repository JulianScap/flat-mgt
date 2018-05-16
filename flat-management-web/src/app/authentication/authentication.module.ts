import { NgModule } from "@angular/core";
import { SharedModule } from "../shared/shared.module";
import { AuthenticationComponent } from "./authentication.component";
import { AuthenticationService } from "./authentication.service";
import { CryptoService } from "../shared/crypto.service";

@NgModule({
    imports: [
        SharedModule
    ],
    declarations: [
        AuthenticationComponent
    ],
    providers: [
        AuthenticationService,
        CryptoService
    ]
  })
  
  export class AuthenticationModule { }
  