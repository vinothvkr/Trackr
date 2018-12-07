import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IssueNewComponent } from './issue-new.component';

describe('IssueNewComponent', () => {
  let component: IssueNewComponent;
  let fixture: ComponentFixture<IssueNewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IssueNewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IssueNewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
