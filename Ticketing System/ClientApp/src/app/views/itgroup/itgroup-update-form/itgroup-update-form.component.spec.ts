import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ItgroupUpdateFormComponent } from './itgroup-update-form.component';

describe('ItgroupUpdateFormComponent', () => {
  let component: ItgroupUpdateFormComponent;
  let fixture: ComponentFixture<ItgroupUpdateFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ItgroupUpdateFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ItgroupUpdateFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
