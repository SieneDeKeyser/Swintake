import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectionStepsComponent } from './selection-steps.component';

describe('SelectionStepsComponent', () => {
  let component: SelectionStepsComponent;
  let fixture: ComponentFixture<SelectionStepsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SelectionStepsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SelectionStepsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
