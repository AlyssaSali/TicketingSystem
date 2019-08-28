import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeEmployeeTypeAddFormComponent } from './employee-employee-type-add-form.component';

describe('EmployeeEmployeeTypeAddFormComponent', () => {
  let component: EmployeeEmployeeTypeAddFormComponent;
  let fixture: ComponentFixture<EmployeeEmployeeTypeAddFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EmployeeEmployeeTypeAddFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmployeeEmployeeTypeAddFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
