import { Component } from '@angular/core';
import { SessionManager } from './shared/services/session-manager.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  constructor(private session: SessionManager, private router: Router) {

  }

  logout(): void {
    this.session.clearSession();
    this.router.navigate(['/authentication']);
  }

  isAuthenticated(): boolean {
    return this.session.isAuthenticated();
  }
}
