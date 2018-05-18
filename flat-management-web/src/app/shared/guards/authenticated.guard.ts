import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { SessionManager } from '../services/session-manager.service';

@Injectable()
export class AuthenticatedGuard implements CanActivate {
  constructor(private sessionManager: SessionManager) { }

  canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
    return this.sessionManager.isAuthenticated();
  }
}
