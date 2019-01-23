import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CampaignDropdownComponent } from './campaign-dropdown.component';

describe('CampaignDropdownComponent', () => {
  let component: CampaignDropdownComponent;
  let fixture: ComponentFixture<CampaignDropdownComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CampaignDropdownComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CampaignDropdownComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
