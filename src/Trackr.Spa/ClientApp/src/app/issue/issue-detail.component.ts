import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router'
import { Location } from '@angular/common';
import { IssueService } from '../core/services/issue.service';
import { Issue } from '../core/models/issue.model';

@Component({
  selector: 'app-issue-detail',
  templateUrl: './issue-detail.component.html',
  styleUrls: ['./issue-detail.component.css']
})
export class IssueDetailComponent implements OnInit {

  issue: Issue;

  constructor(
    private issueService: IssueService,
    private route: ActivatedRoute,
    private location: Location
  ) { }

  ngOnInit() {
    this.getIssue();
  }

  getIssue(): void {
    const projectId = +this.route.snapshot.paramMap.get('projectId');
    const id = +this.route.snapshot.paramMap.get('id');
    this.issueService.getIssue(projectId, id)
      .subscribe(issue => this.issue = issue);
  }
}
