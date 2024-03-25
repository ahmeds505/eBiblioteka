import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaProcitanihKnjigaComponent } from './lista-procitanih-knjiga.component';

describe('ListaProcitanihKnjigaComponent', () => {
  let component: ListaProcitanihKnjigaComponent;
  let fixture: ComponentFixture<ListaProcitanihKnjigaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListaProcitanihKnjigaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListaProcitanihKnjigaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
