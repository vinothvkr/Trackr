import { Component, OnInit, Input } from '@angular/core';
import { Comment } from '../core/models/comment.model'
import { CommentService } from '../core/services/comment.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.css']
})
export class CommentComponent implements OnInit {
  comments: Comment[];

  constructor(
    private commentService: CommentService,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.getComments();
  }

  getComments(): void {
    const projectId = +this.route.snapshot.paramMap.get('projectId');
    const issueId = +this.route.snapshot.paramMap.get('id');
    this.commentService.getComments(projectId, issueId)
      .subscribe(comments => this.comments = comments);
  }
}
