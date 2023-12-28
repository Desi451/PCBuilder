import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RamSpeedFormComponent } from './ram-speed-form.component';

describe('RamSpeedFormComponent', () => {
  let component: RamSpeedFormComponent;
  let fixture: ComponentFixture<RamSpeedFormComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [RamSpeedFormComponent]
    });
    fixture = TestBed.createComponent(RamSpeedFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
