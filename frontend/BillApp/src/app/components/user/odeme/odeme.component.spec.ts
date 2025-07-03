import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OdemeComponent } from './odeme.component';

describe('OdemeComponent', () => {
  let component: OdemeComponent;
  let fixture: ComponentFixture<OdemeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [OdemeComponent]
    });
    fixture = TestBed.createComponent(OdemeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
