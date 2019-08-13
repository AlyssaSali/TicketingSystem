import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ItgroupComponent } from './itgroup.component';

describe('ItgroupComponent', () => {
  let component: ItgroupComponent;
  let fixture: ComponentFixture<ItgroupComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ItgroupComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ItgroupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
