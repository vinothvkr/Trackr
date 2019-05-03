import { Component, OnInit, Input } from '@angular/core';
import { Issue } from '../core/models/issue.model';
import { IssueService } from '../core/services/issue.service';

@Component({
  selector: 'app-issue',
  templateUrl: './issue.component.html',
  styleUrls: ['./issue.component.css']
})
export class IssueComponent implements OnInit {

  @Input() projectId: number;
  issues: Issue[];

  constructor(private issueService: IssueService) { }

  ngOnInit(): void {
    this.getIssues();
  }

  getIssues(): void {
    this.issueService.getIssues(this.projectId)
      .subscribe(issues => this.issues = issues);
  }
}
