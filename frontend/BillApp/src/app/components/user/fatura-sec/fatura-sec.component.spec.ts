import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FaturaSecComponent } from './fatura-sec.component';

describe('FaturaSecComponent', () => {
  let component: FaturaSecComponent;
  let fixture: ComponentFixture<FaturaSecComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FaturaSecComponent]
    });
    fixture = TestBed.createComponent(FaturaSecComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
