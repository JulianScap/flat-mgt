import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { AuthenticationComponent } from './authentication/authentication.component';

@NgModule({
    imports:[
        RouterModule.forRoot([
            { path: 'authentication', component: AuthenticationComponent },
            { path: '', redirectTo: 'authentication', pathMatch: 'full' },
            { path: '**', redirectTo: 'authentication', pathMatch: 'full' }
        ],
        { useHash: false })
    ],
    exports: [ RouterModule ]
})
export class AppRoutingModule { }
