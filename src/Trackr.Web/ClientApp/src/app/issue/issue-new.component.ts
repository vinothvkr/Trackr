import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { IssueService } from '../core/services/issue.service';
import { IssueType } from '../core/models/issue-type.model';
import { Issue } from '../core/models/issue.model';
import { error } from 'protractor';
import { MatSnackBar } from '@angular/material';
import { Location } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-issue-new',
  templateUrl: './issue-new.component.html',
  styleUrls: ['./issue-new.component.css']
})
export class IssueNewComponent implements OnInit {
  issueForm: FormGroup;
  issueTypes: IssueType[];
  isSubmitted = false;
  isLoading = false;
  issue: Issue;

  constructor(
    private issueService: IssueService,
    private snackBar: MatSnackBar,
    private route: ActivatedRoute,
    private location: Location,
    private router: Router
  ) { }

  ngOnInit() {
    this.issueForm = new FormGroup({
      'title': new FormControl('', Validators.required),
      'description': new FormControl('', Validators.required),
      'type': new FormControl('', Validators.required)
    });
    this.getIssueTypes();
  }

  get f() { return this.issueForm.controls; }

  getIssueTypes(): void {
    this.issueService.getIssueTypes()
      .subscribe(issueTypes => this.issueTypes = issueTypes);
  }

  onSubmit() {
    this.isSubmitted = true;

    if (this.issueForm.invalid) {
      return;
    }

    this.isLoading = true;
    const projectId = +this.route.snapshot.paramMap.get('projectId');
    this.issue = {
      id: null,
      title: this.f.title.value,
      description: this.f.description.value,
      issueTypeId: this.f.type.value,
      projectId: projectId
    };
    this.issueService.newIssue(projectId, this.issue)
      .subscribe(
      data => {
        this.router.navigate([`/projects/${projectId}/issues/${data.id}`]);
        this.snackBar.open('Issue has been created', 'Ok', { duration: 10000 });
      },
      error => {
        this.isLoading = false;
        this.snackBar.open('Something went wrong. Please try again', 'Retry', { duration: 10000 });
      });
  }
}
