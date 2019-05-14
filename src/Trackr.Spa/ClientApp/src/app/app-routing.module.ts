import { NgModule } from '@angular/core';
import { RouterModule, Routes, Route } from '@angular/router';

import { ProjectsComponent } from './project/project.component';
import { ProjectDetailComponent } from './project/project-detail.component';
import { IssueDetailComponent } from './issue/issue-detail.component';
import { AuthGuard } from './core/guards/auth.guard';
import { HomeComponent } from './home/home.component';
import { IssueNewComponent } from './issue/issue-new.component';
import { AuthCallbackComponent } from './auth-callback/auth-callback.component';
import { SignupComponent } from './signup/signup.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'signup', component: SignupComponent },
  { path: 'auth-callback', component: AuthCallbackComponent },
  { path: 'projects', component: ProjectsComponent, canActivate: [AuthGuard] },
  { path: 'projects/:id', component: ProjectDetailComponent, canActivate: [AuthGuard] },
  { path: 'projects/:projectId/issues/new', component: IssueNewComponent, canActivate: [AuthGuard] },
  { path: 'projects/:projectId/issues/:id', component: IssueDetailComponent, canActivate: [AuthGuard] },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
