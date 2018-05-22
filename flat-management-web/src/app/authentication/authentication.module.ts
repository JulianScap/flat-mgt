import { NgModule } from "@angular/core";
import { CryptoService } from "../shared/services/crypto.service";
import { SharedModule } from "../shared/shared.module";
import { AuthenticationComponent } from "./authentication.component";
import { AuthenticationService } from "./authentication.service";
import { RouterModule } from "@angular/router";

@NgModule({
    imports: [
        SharedModule,
        RouterModule
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
