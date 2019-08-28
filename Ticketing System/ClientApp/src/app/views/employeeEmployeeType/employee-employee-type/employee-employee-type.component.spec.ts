import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeEmployeeTypeComponent } from './employee-employee-type.component';

describe('EmployeeEmployeeTypeComponent', () => {
  let component: EmployeeEmployeeTypeComponent;
  let fixture: ComponentFixture<EmployeeEmployeeTypeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EmployeeEmployeeTypeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmployeeEmployeeTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
