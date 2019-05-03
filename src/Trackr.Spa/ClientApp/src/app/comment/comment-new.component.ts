import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Comment } from '../core/models/comment.model';
import { CommentService } from '../core/services/comment.service';

@Component({
  selector: 'app-comment-new',
  templateUrl: './comment-new.component.html',
  styleUrls: ['./comment-new.component.css']
})
export class CommentNewComponent implements OnInit {
  commentForm: FormGroup;
  isSubmitted = false;
  isLoading = false;
  comment: Comment;

  constructor(
    private route: ActivatedRoute,
    private commentService: CommentService
  ) { }

  ngOnInit() {
    this.commentForm = new FormGroup({
      'content': new FormControl('', Validators.required)
    });
  }

  get f() { return this.commentForm.controls; }

  onSubmit() {
    this.isSubmitted = true;

    if (this.commentForm.invalid) {
      return;
    }

    this.isLoading = true;
    const projectId = +this.route.snapshot.paramMap.get('projectId');
    const issueId = +this.route.snapshot.paramMap.get('id');
    this.comment = {
      id: 0,
      content: this.f.content.value,
      issueId: issueId,
      projectId: projectId,
      createdOn: new Date()
    };
    this.commentService.postComment(this.comment)
      .subscribe();
  }
}
