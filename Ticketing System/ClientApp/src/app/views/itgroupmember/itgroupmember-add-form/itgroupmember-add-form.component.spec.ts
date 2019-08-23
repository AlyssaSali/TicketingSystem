import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ItgroupmemberAddFormComponent } from './itgroupmember-add-form.component';

describe('ItgroupmemberAddFormComponent', () => {
  let component: ItgroupmemberAddFormComponent;
  let fixture: ComponentFixture<ItgroupmemberAddFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ItgroupmemberAddFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ItgroupmemberAddFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
