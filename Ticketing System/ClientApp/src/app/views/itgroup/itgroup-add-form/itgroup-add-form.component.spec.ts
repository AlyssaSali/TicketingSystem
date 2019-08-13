import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ItgroupAddFormComponent } from './itgroup-add-form.component';

describe('ItgroupAddFormComponent', () => {
  let component: ItgroupAddFormComponent;
  let fixture: ComponentFixture<ItgroupAddFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ItgroupAddFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ItgroupAddFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
