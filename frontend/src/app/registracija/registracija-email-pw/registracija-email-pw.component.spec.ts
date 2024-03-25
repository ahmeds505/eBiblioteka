import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegistracijaEmailPWComponent } from './registracija-email-pw.component';

describe('RegistracijaEmailPWComponent', () => {
  let component: RegistracijaEmailPWComponent;
  let fixture: ComponentFixture<RegistracijaEmailPWComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegistracijaEmailPWComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RegistracijaEmailPWComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
