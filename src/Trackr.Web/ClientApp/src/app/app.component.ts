import { Component } from '@angular/core';
import { AuthService } from './core/services/auth.service';
import { Router, NavigationEnd } from '@angular/router';
import { User } from './core/models/user.model';
import { Location } from '@angular/common';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  currentUrl;
  constructor(
    private authService: AuthService,
    private router: Router,
    private location: Location
  ) {
    router.events.subscribe(e => {
      if (e instanceof NavigationEnd) {
        this.currentUrl = e.url;
      }
    });
  }

  goBack() {
    this.location.back();
  }

  logout() {
    this.authService.logout();
    this.router.navigate(['/']);
  }
}
