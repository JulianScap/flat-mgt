import { Component } from '@angular/core';
import { environment } from '../../environments/environment';

@Component({
  templateUrl: './authentication.component.html',
  styleUrls: ['./authentication.component.css']
})

export class AuthenticationComponent {
  name: string;
  flatName: string;

  constructor() {
    this.name = 'Julian';
    this.flatName = '4E';
  }

  login(): void {
    
  }

  clear(): void {
      this.name = '';
      this.flatName = '';
  }
}
