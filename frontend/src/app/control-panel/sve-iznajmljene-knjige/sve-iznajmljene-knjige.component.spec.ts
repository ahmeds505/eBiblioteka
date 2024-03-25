import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SveIznajmljeneKnjigeComponent } from './sve-iznajmljene-knjige.component';

describe('SveIznajmljeneKnjigeComponent', () => {
  let component: SveIznajmljeneKnjigeComponent;
  let fixture: ComponentFixture<SveIznajmljeneKnjigeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SveIznajmljeneKnjigeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SveIznajmljeneKnjigeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
