import {Issue} from '../models/issue.model'

export class Project {
  id: number;
  name: string;
  description: string;
  issues: Issue;
}
