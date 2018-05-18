import { NgModule } from "@angular/core";
import { CryptoService } from "../shared/services/crypto.service";
import { SharedModule } from "../shared/shared.module";
import { AuthenticationComponent } from "./authentication.component";
import { AuthenticationService } from "./authentication.service";

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
