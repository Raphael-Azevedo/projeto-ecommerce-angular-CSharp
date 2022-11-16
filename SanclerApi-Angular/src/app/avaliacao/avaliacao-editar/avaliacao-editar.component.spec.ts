import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AvaliacaoEditarComponent } from './avaliacao-editar.component';

describe('AvaliacaoEditarComponent', () => {
  let component: AvaliacaoEditarComponent;
  let fixture: ComponentFixture<AvaliacaoEditarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AvaliacaoEditarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AvaliacaoEditarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
