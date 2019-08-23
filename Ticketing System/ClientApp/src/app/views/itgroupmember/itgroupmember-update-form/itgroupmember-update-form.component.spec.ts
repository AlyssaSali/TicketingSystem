import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ItgroupmemberUpdateFormComponent } from './itgroupmember-update-form.component';

describe('ItgroupmemberUpdateFormComponent', () => {
  let component: ItgroupmemberUpdateFormComponent;
  let fixture: ComponentFixture<ItgroupmemberUpdateFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ItgroupmemberUpdateFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ItgroupmemberUpdateFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
