import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailcandidateComponent } from './detailcandidate.component';

describe('DetailcandidateComponent', () => {
  let component: DetailcandidateComponent;
  let fixture: ComponentFixture<DetailcandidateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetailcandidateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetailcandidateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
