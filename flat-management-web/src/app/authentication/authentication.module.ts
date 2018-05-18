import { NgModule } from "@angular/core";
import { SharedModule } from "../shared/shared.module";
import { AuthenticationComponent } from "./authentication.component";
import { AuthenticationService } from "./authentication.service";
import { CryptoService } from "../shared/services/crypto.service";
import { CorsHttpClient } from "../shared/services/corshttpclient.service";

@NgModule({
    imports: [
        SharedModule
    ],
    declarations: [
        AuthenticationComponent
    ],
    providers: [
        AuthenticationService,
        CryptoService,
        CorsHttpClient
    ]
})

export class AuthenticationModule { }
