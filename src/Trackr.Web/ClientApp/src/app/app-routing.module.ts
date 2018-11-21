import { NgModule } from '@angular/core';
import { RouterModule, Routes, Route } from '@angular/router';

import { ProjectsComponent } from './project/project.component';
import { ProjectDetailComponent } from './project/project-detail.component';
import { IssueDetailComponent } from './issue/issue-detail.component';
import { LoginComponent } from './login/login.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'projects', component: ProjectsComponent },
  { path: 'projects/:id', component: ProjectDetailComponent },
  { path: 'projects/:projectId/issues/:id', component: IssueDetailComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
