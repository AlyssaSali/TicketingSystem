import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ItgroupmemberComponent } from './itgroupmember.component';

describe('ItgroupmemberComponent', () => {
  let component: ItgroupmemberComponent;
  let fixture: ComponentFixture<ItgroupmemberComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ItgroupmemberComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ItgroupmemberComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
