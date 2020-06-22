import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowdealerComponent } from './showdealer.component';

describe('ShowdealerComponent', () => {
  let component: ShowdealerComponent;
  let fixture: ComponentFixture<ShowdealerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ShowdealerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowdealerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
