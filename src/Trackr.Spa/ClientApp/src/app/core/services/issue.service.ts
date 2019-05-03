import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Issue } from '../models/issue.model';
import { IssueType } from '../models/issue-type.model';
import { environment } from '../../../environments/environment';


@Injectable({
  providedIn: 'root'
})
export class IssueService {
  private issuesUrl = environment.apiUrl + '/projects';

  constructor(
    private http: HttpClient
  ) { }

  getIssues(projectid: number): Observable<Issue[]> {
    const url = `${this.issuesUrl}/${projectid}/issues`;
    return this.http.get<Issue[]>(url);
  }

  getIssue(projectid: number, id: number): Observable<Issue> {
    const url = `${this.issuesUrl}/${projectid}/issues/${id}`;
    return this.http.get<Issue>(url);
  }

  getIssueTypes(): Observable<IssueType[]> {
    const url = environment.apiUrl + '/issuetypes';
    return this.http.get<IssueType[]>(url);
  }

  postIssue(issue: Issue): Observable<Issue> {
    const url = `${this.issuesUrl}/${issue.projectId}/issues`;
    return this.http.post<Issue>(url, issue);
  }
}
