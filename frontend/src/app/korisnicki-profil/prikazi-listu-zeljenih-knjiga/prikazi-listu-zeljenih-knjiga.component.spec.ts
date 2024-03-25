import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrikaziListuZeljenihKnjigaComponent } from './prikazi-listu-zeljenih-knjiga.component';

describe('PrikaziListuZeljenihKnjigaComponent', () => {
  let component: PrikaziListuZeljenihKnjigaComponent;
  let fixture: ComponentFixture<PrikaziListuZeljenihKnjigaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrikaziListuZeljenihKnjigaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PrikaziListuZeljenihKnjigaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
