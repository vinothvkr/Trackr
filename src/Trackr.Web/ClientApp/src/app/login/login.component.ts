import { Component, OnInit } from '@angular/core';
import { User } from '../core/models/user.model';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../core/services/auth.service';
import { Router } from '@angular/router';
import { first } from 'rxjs/operators';
import { MatSnackBar } from '@angular/material'

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  returnUrl = '/';
  isSubmitted = false;
  isLoading = false;

  constructor(
    private authService: AuthService,
    private router: Router,
    private snackBar: MatSnackBar
  ) { }

  ngOnInit() {
    this.authService.logout();
    this.loginForm = new FormGroup({
      'email': new FormControl('', Validators.required),
      'password': new FormControl('', Validators.required),
    });
  }

  get f() { return this.loginForm.controls; }

  onSubmit() {
    this.isSubmitted = true;

    if (this.loginForm.invalid) {
      return;
    }

    this.isLoading = true;
    this.authService.login(this.f.email.value, this.f.password.value)
      .pipe(first())
      .subscribe(
      data => {
        this.snackBar.open('You are logged in', '', { duration: 5000 });
        this.router.navigate([this.returnUrl]);
      },
      error => {
        this.loginForm.controls.password.setValue('');
        this.isLoading = false;
        this.snackBar.open(error, 'Retry', { duration: 10000 });
      });
  }

}
