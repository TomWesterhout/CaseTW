import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CursusInstantieAddComponent } from './cursus-instantie-add.component';

describe('CursusInstantieAddComponent', () => {
  let component: CursusInstantieAddComponent;
  let fixture: ComponentFixture<CursusInstantieAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CursusInstantieAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CursusInstantieAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
