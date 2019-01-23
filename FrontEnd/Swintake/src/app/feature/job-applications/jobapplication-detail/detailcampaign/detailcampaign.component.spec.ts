import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailcampaignComponent } from './detailcampaign.component';

describe('DetailcampaignComponent', () => {
  let component: DetailcampaignComponent;
  let fixture: ComponentFixture<DetailcampaignComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetailcampaignComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetailcampaignComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
