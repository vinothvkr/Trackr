import { Component, ViewChild } from '@angular/core';
import { AuthService } from './core/services/auth.service';
import { Router, NavigationEnd } from '@angular/router';
import { User } from './core/models/user.model';
import { Location } from '@angular/common';
import { MatSidenav } from '@angular/material/sidenav';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  @ViewChild('sidenav') sidenav: MatSidenav;
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

  closeSideNav() {
    this.sidenav.close();
  }

  goBack() {
    this.location.back();
  }

  logout() {
    this.closeSideNav();
    this.authService.logout();
    this.router.navigate(['/']);
  }
}
