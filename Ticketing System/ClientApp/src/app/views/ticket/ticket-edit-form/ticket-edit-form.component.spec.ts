import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TicketEditFormComponent } from './ticket-edit-form.component';

describe('TicketEditFormComponent', () => {
  let component: TicketEditFormComponent;
  let fixture: ComponentFixture<TicketEditFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TicketEditFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TicketEditFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
