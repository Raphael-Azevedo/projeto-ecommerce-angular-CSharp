import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AvaliacaoNovoComponent } from './avaliacao-novo.component';

describe('AvaliacaoNovoComponent', () => {
  let component: AvaliacaoNovoComponent;
  let fixture: ComponentFixture<AvaliacaoNovoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AvaliacaoNovoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AvaliacaoNovoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
