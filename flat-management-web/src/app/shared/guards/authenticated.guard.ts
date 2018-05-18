import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { SessionManager } from '../services/session-manager.service';

@Injectable()
export class AuthenticatedGuard implements CanActivate {
  constructor(private sessionManager: SessionManager,
    private router: Router) { }

  canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
    if (this.sessionManager.isAuthenticated()) {
      return true;
    }
    else {
      console.log('logged out, exiting');
      this.router.navigate(['/authenticate']);
      return false;
    }
  }
}
