import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FiltersearchComponent } from './filtersearch.component';

describe('FiltersearchComponent', () => {
  let component: FiltersearchComponent;
  let fixture: ComponentFixture<FiltersearchComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FiltersearchComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FiltersearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
