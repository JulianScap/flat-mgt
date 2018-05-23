import { NgModule } from "@angular/core";
import { CryptoService } from "../shared/services/crypto.service";
import { SharedModule } from "../shared/shared.module";
import { AuthenticationComponent } from "./authentication.component";
import { AuthenticationService } from "./authentication.service";
import { RouterModule } from "@angular/router";
import { AuthenticationRoutingModule } from "./authentication-routing.module";
import { AuthenticationNewComponent } from "./authentication-new.component";

@NgModule({
    imports: [
        SharedModule,
        RouterModule,
        AuthenticationRoutingModule
    ],
    
    declarations: [
        AuthenticationComponent,
        AuthenticationNewComponent
    ],

    providers: [
        AuthenticationService,
        CryptoService
    ]
})

export class AuthenticationModule { }
