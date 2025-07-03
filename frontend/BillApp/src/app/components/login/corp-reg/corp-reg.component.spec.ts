import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CorpRegComponent } from './corp-reg.component';

describe('CorpRegComponent', () => {
  let component: CorpRegComponent;
  let fixture: ComponentFixture<CorpRegComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CorpRegComponent]
    });
    fixture = TestBed.createComponent(CorpRegComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
