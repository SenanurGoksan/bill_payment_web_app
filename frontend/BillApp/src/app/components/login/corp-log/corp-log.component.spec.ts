import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CorpLogComponent } from './corp-log.component';

describe('CorpLogComponent', () => {
  let component: CorpLogComponent;
  let fixture: ComponentFixture<CorpLogComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CorpLogComponent]
    });
    fixture = TestBed.createComponent(CorpLogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
