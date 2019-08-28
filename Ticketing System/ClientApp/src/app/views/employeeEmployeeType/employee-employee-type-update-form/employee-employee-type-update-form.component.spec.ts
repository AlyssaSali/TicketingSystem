import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeEmployeeTypeUpdateFormComponent } from './employee-employee-type-update-form.component';

describe('EmployeeEmployeeTypeUpdateFormComponent', () => {
  let component: EmployeeEmployeeTypeUpdateFormComponent;
  let fixture: ComponentFixture<EmployeeEmployeeTypeUpdateFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EmployeeEmployeeTypeUpdateFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmployeeEmployeeTypeUpdateFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
