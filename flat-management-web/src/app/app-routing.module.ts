import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { AuthenticationComponent } from './authentication/authentication.component';
import { FlatComponent } from './flat/flat.component';
import { AuthenticatedGuard } from './shared/guards/authenticated.guard';

@NgModule({
    imports: [
        RouterModule.forRoot([
            { path: 'authentication', component: AuthenticationComponent },
            { path: 'flat', component: FlatComponent, canActivate: [AuthenticatedGuard] },
            { path: '', redirectTo: 'authentication', pathMatch: 'full' },
            { path: '**', redirectTo: 'authentication', pathMatch: 'full' }
        ],
            { useHash: false })
    ],
    exports: [RouterModule]
})
export class AppRoutingModule { }
