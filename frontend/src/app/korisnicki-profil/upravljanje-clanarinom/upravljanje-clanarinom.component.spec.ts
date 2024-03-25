import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpravljanjeClanarinomComponent } from './upravljanje-clanarinom.component';

describe('UpravljanjeClanarinomComponent', () => {
  let component: UpravljanjeClanarinomComponent;
  let fixture: ComponentFixture<UpravljanjeClanarinomComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpravljanjeClanarinomComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UpravljanjeClanarinomComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
