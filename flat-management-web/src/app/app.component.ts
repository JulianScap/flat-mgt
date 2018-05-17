import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  template: `
<nav class="navbar navbar-expand-lg navbar-light bg-light">
  <a class="navbar-brand">Flat Management</a>
</nav>
<div class='container' style='padding:1.5rem;'><router-outlet></router-outlet></div>`
})
export class AppComponent { }
