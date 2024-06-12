import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AssuntoShowComponent } from './assunto-show.component';

describe('AssuntoShowComponent', () => {
  let component: AssuntoShowComponent;
  let fixture: ComponentFixture<AssuntoShowComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AssuntoShowComponent]
    });
    fixture = TestBed.createComponent(AssuntoShowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
