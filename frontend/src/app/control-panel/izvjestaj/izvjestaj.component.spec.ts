import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IzvjestajComponent } from './izvjestaj.component';

describe('IzvjestajComponent', () => {
  let component: IzvjestajComponent;
  let fixture: ComponentFixture<IzvjestajComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ IzvjestajComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(IzvjestajComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
