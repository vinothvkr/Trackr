import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AccountService } from '../core/services/account.service';
import { MatSnackBar } from '@angular/material';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  signupForm: FormGroup;
  returnUrl = '/';
  isSubmitted = false;
  isLoading = false;

  constructor(
    private accountService: AccountService,
    private snackBar: MatSnackBar,
    private router: Router
  ) { }

  ngOnInit() {
    this.signupForm = new FormGroup({
      'email': new FormControl('', Validators.required),
      'password': new FormControl('', Validators.required),
      'confirmPassword': new FormControl('', Validators.required)
    });
  }

  get f() { return this.signupForm.controls; }

  onSubmit() {
    this.isSubmitted = true;

    if (this.signupForm.invalid) {
      return;
    }

    this.isLoading = true;
    this.accountService.signup(this.f.email.value, this.f.password.value, this.f.confirmPassword.value)
      .subscribe(
      data => {
        this.router.navigate(['/']);
        this.snackBar.open('Account has been created', 'Login', { duration: 10000 });
      },
      error => {
        this.isLoading = false;
        this.snackBar.open('Something went wrong. Please try again', 'Retry', { duration: 10000 });
      });
  }

}
