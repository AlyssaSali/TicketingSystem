import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OfficeAddFormComponent } from './office-add-form.component';

describe('OfficeAddFormComponent', () => {
  let component: OfficeAddFormComponent;
  let fixture: ComponentFixture<OfficeAddFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OfficeAddFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OfficeAddFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
