import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NumberplateInformationComponent } from './numberplate-information.component';

describe('NumberplateInformationComponent', () => {
  let component: NumberplateInformationComponent;
  let fixture: ComponentFixture<NumberplateInformationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NumberplateInformationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NumberplateInformationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
