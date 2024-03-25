import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IznajmljeneKnjigeComponent } from './iznajmljene-knjige.component';

describe('IznajmljeneKnjigeComponent', () => {
  let component: IznajmljeneKnjigeComponent;
  let fixture: ComponentFixture<IznajmljeneKnjigeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ IznajmljeneKnjigeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(IznajmljeneKnjigeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
