import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DodajZeljenuKnjiguComponent } from './dodaj-zeljenu-knjigu.component';

describe('DodajZeljenuKnjiguComponent', () => {
  let component: DodajZeljenuKnjiguComponent;
  let fixture: ComponentFixture<DodajZeljenuKnjiguComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DodajZeljenuKnjiguComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DodajZeljenuKnjiguComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
