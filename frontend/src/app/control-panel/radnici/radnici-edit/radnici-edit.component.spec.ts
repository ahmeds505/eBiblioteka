import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RadniciEditComponent } from './radnici-edit.component';

describe('RadniciEditComponent', () => {
  let component: RadniciEditComponent;
  let fixture: ComponentFixture<RadniciEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RadniciEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RadniciEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
