import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Comment } from '../models/comment.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CommentService {
  private apiUrl = 'api';

  constructor(
    private http: HttpClient
  ) { }

  getComments(projectId: number, issueId: number): Observable<Comment[]> {
    const url = `${this.apiUrl}/projects/${projectId}/issues/${issueId}/comments`;
    return this.http.get<Comment[]>(url)
  }

  postComment(comment: Comment): Observable<Comment> {
    const url = `${this.apiUrl}/projects/${comment.projectId}/issues/${comment.issueId}/comments`;
    return this.http.post<Comment>(url, comment);
  }
}
