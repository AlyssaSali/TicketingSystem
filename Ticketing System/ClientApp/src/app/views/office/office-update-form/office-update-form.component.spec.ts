import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OfficeUpdateFormComponent } from './office-update-form.component';

describe('OfficeUpdateFormComponent', () => {
  let component: OfficeUpdateFormComponent;
  let fixture: ComponentFixture<OfficeUpdateFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OfficeUpdateFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OfficeUpdateFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
