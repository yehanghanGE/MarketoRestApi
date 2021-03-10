import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MarketoLeadsComponent } from './marketo-leads.component';

describe('MarketoLeadsComponent', () => {
  let component: MarketoLeadsComponent;
  let fixture: ComponentFixture<MarketoLeadsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MarketoLeadsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MarketoLeadsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
