import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CursusInstantieComponent } from './cursus-instantie.component';

describe('CursusInstantieComponent', () => {
  let component: CursusInstantieComponent;
  let fixture: ComponentFixture<CursusInstantieComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CursusInstantieComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CursusInstantieComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
