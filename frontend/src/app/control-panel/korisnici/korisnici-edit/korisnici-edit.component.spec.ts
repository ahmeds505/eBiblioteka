import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KorisniciEditComponent } from './korisnici-edit.component';

describe('KorisniciEditComponent', () => {
  let component: KorisniciEditComponent;
  let fixture: ComponentFixture<KorisniciEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ KorisniciEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(KorisniciEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
